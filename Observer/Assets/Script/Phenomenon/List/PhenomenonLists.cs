using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhenomenonLists : MonoBehaviour
{
    //生成可能異常現象list
    private List<GameObject> ableToCreateList = new List<GameObject>();
    //生成後異常現象list
    private List<GameObject> alreadyCreateList = new List<GameObject>();
    [Header("生成用タイマー")]
    [SerializeField] private float timer = 15.0f;
    //タイマー再設定定数
    private const float TIMER_MAX = 10.0f;
    //オブジェクトカウント全体数
    private int allPhenomenonCount = 0;
    //プレイヤーステート、ゲームタイムがアタッチされたオブジェクト
    private GameObject _gameRule = default;
    //カメラマネージャー
    private GameObject _cameraManager = default;
    [Header("レポート後テキスト")]
    [SerializeField] GameObject _afterReportText = default;
    [Header("レポート成功画面")]
    [SerializeField] GameObject _reportSuccessScreen = default;


    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start()
    {
        //ゲームルールオブジェクトの取得
        _gameRule = GameObject.Find("GameRule");
        //カメラマネージャーオブジェクトの取得
        _cameraManager = GameObject.Find("CameraManager");
    }

    /// <summary>
    /// 生成可能オブジェクトリストへ追加
    /// </summary>
    /// <param name="gameObj">リストに追加するGameObject</param>
    public void AddAbleToCreateList(GameObject gameObj)
    {
        ableToCreateList.Add(gameObj);
        allPhenomenonCount += 1;

    }


    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        //ゲームタイムが止まっているとき
        if(!_gameRule.GetComponent<GameTime>().GetGameTimeFlag())
        {
            //処理しない
            return;
        }
        //危険フラグが立っているときは処理しない
        if(_gameRule.GetComponent<PlayerRiskState>().GetIsDanger())
        {
            return;
        }
        //異常発生用タイマーのカウントダウン
        timer -= Time.deltaTime;
        if (/*デバッグ用*/Input.GetKeyDown(KeyCode.Space) || timer < 0)
        {
            //異常現象発生
            MakePhenomenon();
            //タイマー再設定
            timer = TIMER_MAX;
        }
        
    }


    /// <summary>
    /// 通常時、アクティブなオブジェクトか判定する
    /// </summary>
    /// <returns></returns>
    private bool JudgeDoActiveObject(GameObject obj)
    {
        //オブジェクトタイプを格納する。
        Phenomenon.ObjectType phenoType = obj.GetComponent<ObjectTypeManager>().GetObjectType();
        //オブジェクトタイプが、通常時はアクティブであるオブジェクトだった場合
        //消失、ライト
        if(phenoType == Phenomenon.ObjectType.Vanish
            || phenoType == Phenomenon.ObjectType.Light)
        {
            //正を返す
            return true;
        }
        //負を返す
        return false;
    }
    
    
    /// <summary>
    /// 通常時、非アクティブなオブジェクトか判定する
    /// </summary>
    /// <returns></returns>
    private bool JudgeDoInactiveObject(GameObject obj)
    {
        //オブジェクトタイプを格納する。
        Phenomenon.ObjectType phenoType = obj.GetComponent<ObjectTypeManager>().GetObjectType();
        //オブジェクトタイプが、通常時非アクティブであるオブジェクトだった場合
        //消失、ライト
        if(phenoType == Phenomenon.ObjectType.AddObject
            || phenoType == Phenomenon.ObjectType.Light)
        {
            //正を返す
            return true;
        }
        //負を返す
        return false;
    }


    /// <summary>
    /// 異常現象を発生させる
    /// </summary>
    private void MakePhenomenon()
    {
        //乱数の生成
        int rand = Random.Range(0, ableToCreateList.Count);


        //変数にオブジェクトを格納する
        GameObject gameObj = ableToCreateList[rand];
        //異常が今見ているカメラの部屋で発生したら
        if ((int)gameObj.GetComponent<ObjectTypeManager>().GetRooms() 
            == _cameraManager.GetComponent<CameraManager>().GetCamerNo())
        {
            //カメラ切替フラグを設定してノイズを発生させる
            _cameraManager.GetComponent<CameraManager>().SetCameraSwitchFlag();
        }


        //プレイヤーの危険度を設定(加算)する。
        _gameRule.GetComponent<PlayerRiskState>().SetPlayerRiskPoint(gameObj.GetComponent<ObjectTypeManager>().GetRiskValue(),true);

        ///デバッグ
        Debug.Log($"{ableToCreateList[rand].GetComponent<ObjectTypeManager>().GetRooms()}," +
            $"{ableToCreateList[rand].GetComponent<ObjectTypeManager>().GetObjectType()}");

        //発生済み現象をリスト化する
        alreadyCreateList.Add(ableToCreateList[rand]);
        //未発生現象リストから削除する
        ableToCreateList.RemoveAt(rand);

        //オブジェクトが非アクティブの場合
        if(!gameObj.activeSelf)
        {
            //アクティブにする
            gameObj.SetActive(true);
            //発生フラグの処理
            gameObj.gameObject.GetComponent<ObjectTypeManager>().SetIsOutbreakOn();
            return;
        }
        //オブジェクトがアクティブで、非アクティブ対象の場合
        if (JudgeDoActiveObject(gameObj))
        {
            //非アクティブにする
            gameObj.SetActive(false);
            return;
        }
        //現象発生フラグを正にする
        gameObj.GetComponent<ObjectTypeManager>().SetIsOutbreakOn();
        return;
    }


    /// <summary>
    /// 報告オブジェクトが存在するかの判定
    /// </summary>
    /// <param name="room">発生した部屋</param>
    /// <param name="objectType">異常現象のオブジェクトタイプ</param>
    /// <returns></returns>
    public void JudgeReport(Phenomenon.Rooms room,Phenomenon.ObjectType objectType)
    {
        //発生済みの異常現象リストを検索
        for(int i = 0;i < alreadyCreateList.Count;i++)
        {
            //引数roomと一致したら
            if(alreadyCreateList[i].GetComponent<ObjectTypeManager>().GetRooms() == room)
            {
                //かつ、引数objectTypeと一致したら
                if(alreadyCreateList[i].GetComponent<ObjectTypeManager>().GetObjectType() == objectType)
                {
                    //現象修正処理
                    FixPhenomenon(alreadyCreateList[i]);
                    //未発生リストに追加
                    ableToCreateList.Add(alreadyCreateList[i]);
                    //発生中リストから削除
                    alreadyCreateList.RemoveAt(i);
                    //レポート成功画面の表示
                    _reportSuccessScreen.SetActive(true);
                    ///デバッグ
                    //Debug.Log("通報成功");
                    return;
                }
            }
        }
        //レポート失敗テキストの表示
        _afterReportText.GetComponent<AfterRepotText>().SetDisplayMessage(false);
        _afterReportText.SetActive(true);
        ///デバッグ
        //Debug.Log("通報失敗");
        
        //一致するオブジェクトが無かったら
        return;

    }

    /// <summary>
    /// 異常現象を修正する
    /// </summary>
    private void FixPhenomenon(GameObject gameObj)
    {
        //プレイヤーの危険度を設定(減算)する。
        _gameRule.GetComponent<PlayerRiskState>().SetPlayerRiskPoint(gameObj.GetComponent<ObjectTypeManager>().GetRiskValue(), false);
        //オブジェクトが非アクティブの場合
        if (!gameObj.activeSelf)
        {
            //アクティブにする
            gameObj.SetActive(true);
            //発生フラグの処理
            gameObj.gameObject.GetComponent<ObjectTypeManager>().SetIsOutbreakOff();
            return;
        }
        //オブジェクトがアクティブで、非アクティブ対象の場合
        if (JudgeDoInactiveObject(gameObj))
        {
            //非アクティブにする
            gameObj.SetActive(false);
            return;
        }
        //現象発生フラグを消す
        gameObj.GetComponent<ObjectTypeManager>().SetIsOutbreakOff();
        return;
    }

    /// <summary>
    /// デバッグ用関数
    /// </summary>
    void DebugMethod()
    {
        Debug.Log(ableToCreateList.Count);
        Debug.Log(alreadyCreateList.Count);
        Debug.Log(allPhenomenonCount);
    }
}
