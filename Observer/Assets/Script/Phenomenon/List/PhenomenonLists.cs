using System.Collections.Generic;
using UnityEngine;

public class PhenomenonLists : MonoBehaviour
{
    //生成可能異常現象list
    private List<GameObject> _ableToCreateList = new List<GameObject>();
    //生成後異常現象list
    private List<GameObject> _alreadyCreateList = new List<GameObject>();
    //生成後異常現象list
    private List<GameObject> _repotedObjectsList = new List<GameObject>();
    //異常現象list
    static private List<string> _stillAnomalyNameList = new List<string>();
    //プレイヤーステート、ゲームタイムがアタッチされたオブジェクト
    private GameObject _gameManager = default;
    //レポートした数
    static private int _reportedPhenomenonCount = default;
    //発生した異常総数
    static private int _alreadyPhenomenonCount = default;

    //カメラマネージャー
    private GameObject _cameraManager = default;
    [Header("レポート後テキスト")]
    [SerializeField] GameObject _afterReportText = default;
    [Header("レポート成功画面")]
    [SerializeField] GameObject _reportSuccessScreen = default;

    //デバッグフラグ
    private bool _isDebug = false;
    //デバッグフラグ
    //private bool _isComplete = false;
    //フラグマネージャ
    private GameObject _flagManager = default;

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start()
    {
        //少し待ってからフラグマネジャを検索する
        Invoke("FindFlagObject", 0.09f);

        //ゲームルールオブジェクトの取得
        _gameManager = GameObject.Find("GameManager");
        //カメラマネージャーオブジェクトの取得
        _cameraManager = GameObject.Find("CameraManager");

        //レポートした数の初期化
        _reportedPhenomenonCount = 0;
        //異常総数の初期化
        _alreadyPhenomenonCount = 0;

        //配列の初期化
        _repotedObjectsList.Clear();


        //少し待ってからリストをシャッフルする
        Invoke("ShuffleListObject", 2.0f);
    }
    /// <summary>
    /// フラグマネージャーの検索
    /// </summary>
    void FindFlagObject()
    {
        //フラグマネジャをみつける
        _flagManager = GameObject.FindGameObjectWithTag("FlagManager");
        //見つけられなかったら
        if (_flagManager == null)
        {
            //処理終了
            return;
        }
        //デバッグフラグを取得
        _isDebug = _flagManager.GetComponent<FlagManager>().GetIsDebug();
        //コンプリートフラグを取得
        //_isComplete = _flagManager.GetComponent<FlagManager>().GetCompleteMode();
    }

    /// <summary>
    /// 生成可能オブジェクトリストへ追加
    /// </summary>
    /// <param name="gameObj">リストに追加するGameObject</param>
    public void AddAbleToCreateList(GameObject gameObj)
    {
        //異常listへ格納
        _ableToCreateList.Add(gameObj);
    }

    /// <summary>
    /// リストのオブジェクトをシャッフルする。
    /// </summary>
    public void ShuffleListObject()
    {
        if (!_flagManager.GetComponent<FlagManager>().GetGameClear() && (_stillAnomalyNameList.Count == 0))
        {
            for (int i = 0; i < _ableToCreateList.Count; i++)
            {
                _stillAnomalyNameList.Add(_ableToCreateList[i].name);
            }
        }
        //シャッフル
        for (int i = 0; i < _ableToCreateList.Count - 1; i++)
        {
            var j = Random.Range(0, _ableToCreateList.Count); // ランダムで要素番号を１つ選ぶ（ランダム要素）
            var temp = _ableToCreateList[i]; // 一番最後の要素を仮確保（temp）にいれる
            _ableToCreateList[i] = _ableToCreateList[j]; // ランダム要素を一番最後にいれる
            _ableToCreateList[j] = temp; // 仮確保を元ランダム要素に上書き
        }

        //異常総数
        Debug.Log($"生成可能リスト{_ableToCreateList.Count}");
        Debug.Log($"未発見リスト{ _stillAnomalyNameList.Count}");
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {


    }

    /// <summary>
    /// 同じ部屋で既にその現象が起きていないか判別する
    /// </summary>
    /// <param name="gameObj">異常オブジェクト</param>
    private bool SearchSamePhenomenon(GameObject gameObj)
    {
        bool camera = false;
        bool type = false;
        for (int a = 0; a < _alreadyCreateList.Count; a++)
        {
            //部屋(カメラ)を比べる
            if (gameObj.GetComponent<ObjectTypeManager>().GetRooms()
                == _alreadyCreateList[a].GetComponent<ObjectTypeManager>().GetRooms())
            {
                camera = true;
            }
            //オブジェクトタイプを比べる
            if (gameObj.GetComponent<ObjectTypeManager>().GetObjectType()
                == _alreadyCreateList[a].GetComponent<ObjectTypeManager>().GetObjectType())
            {
                type = true;
            }
            //両方同じであれば
            if (camera == true && type == true)
            {
                //trueを返す
                return true;
            }
            //リセット
            camera = false;
            type = false;
        }
        //当てはまるものがなければfalseを返す
        return false;
    }

    /// <summary>
    /// 異常現象を発生させる
    /// </summary>
    public void MakePhenomenon()
    {
        //危険フラグが立っているときは処理しない
        if (_gameManager.GetComponent<PlayerRiskState>().GetIsDanger())

        {
            //処理しない
            return;
        }
        if((_ableToCreateList.Count == 0))
        {
            return;
        }
        //検索用
        bool flag = default;
        //乱数用
        int rand = default;

        do
        {
            //同じ部屋で同じタイプの現象が起きていないか検索する
            flag = SearchSamePhenomenon(_ableToCreateList[0]);
            //同じものがあったら
            if (flag)
            {
                //オブジェクトを最後尾に格納
                _ableToCreateList.Add(_ableToCreateList[0]);
                //先頭オブジェクトを削除する。
                _ableToCreateList.RemoveAt(0);
            }
        }
        //同じものがあればやり直し
        while (flag);

        //変数に発生させる異変オブジェクトを格納する
        GameObject gameObj = _ableToCreateList[0];
        //プレイヤーの危険度を設定(加算)する。
        _gameManager.GetComponent<PlayerRiskState>().SetPlayerRiskPoint(gameObj.GetComponent<ObjectTypeManager>().GetRiskValue(), true);
        //発生した異常の数を加算する。
        _alreadyPhenomenonCount += 1;

        //異常が今見ているカメラの部屋で発生したら
        if ((int)gameObj.GetComponent<ObjectTypeManager>().GetRooms()
            == _cameraManager.GetComponent<CameraManager>().GetCameraNo())
        {
            //カメラ切替フラグを設定してノイズを発生させる
            _cameraManager.GetComponent<CameraManager>().SetCameraNoiseFlag();
        }

        ///デバッグ
        Debug.Log($"{_ableToCreateList[rand].GetComponent<ObjectTypeManager>().GetRooms()}," +
            $"{_ableToCreateList[rand].GetComponent<ObjectTypeManager>().GetObjectType()}");


        //発生済み異変をリストに追加する
        _alreadyCreateList.Add(_ableToCreateList[rand]);
        //未発生異変リストから削除する
        _ableToCreateList.RemoveAt(rand);

        //オブジェクトが非アクティブの場合
        if (!gameObj.activeSelf)
        {
            //アクティブにする
            gameObj.SetActive(true);
            //発生フラグの処理
            gameObj.gameObject.GetComponent<ObjectTypeManager>().SetIsOutbreakOn();
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
    public void JudgeReport(Phenomenon.Rooms room, Phenomenon.ObjectType objectType)
    {
        //発生済みの異常現象リストを検索
        for (int i = 0; i < _alreadyCreateList.Count; i++)
        {
            //異変の種類が違ったら
            if (_alreadyCreateList[i].GetComponent<ObjectTypeManager>().GetObjectType() != objectType)
            {
                //次のループへ
                continue;
            }
            if (_alreadyCreateList[i].GetComponent<ObjectTypeManager>().GetRooms() != room)
            {
                //次のループへ
                continue;
            }
            //現象修正処理
            FixPhenomenon(_alreadyCreateList[i]);
            //生成可能オブジェクトに追加する
            _ableToCreateList.Add(_alreadyCreateList[i]);
            //発生中リストから削除
            _alreadyCreateList.RemoveAt(i);
            
            //レポート成功画面の表示
            _reportSuccessScreen.SetActive(true);
            return;
        }
        //レポート失敗テキストの表示
        _afterReportText.GetComponent<AfterRepotText>().SetDisplayMessage(false);
        _afterReportText.SetActive(true);
    }

    /// <summary>
    /// 異常現象を修正する
    /// </summary>
    private void FixPhenomenon(GameObject gameObj)
    {
        //プレイヤーの危険度を設定(減算)する。
        _gameManager.GetComponent<PlayerRiskState>().SetPlayerRiskPoint(gameObj.GetComponent<ObjectTypeManager>().GetRiskValue(), false);
        //レポートした数を加算する
        _reportedPhenomenonCount += 1;
        //報告済オブジェクトに追加する
        _repotedObjectsList.Add(gameObj);

        //オブジェクトが非アクティブの場合
        if (!gameObj.activeSelf)
        {
            //アクティブにする
            gameObj.SetActive(true);
            //発生フラグの処理
            gameObj.gameObject.GetComponent<ObjectTypeManager>().SetIsOutbreakOff();
            return;
        }
        //現象発生フラグを消す
        gameObj.GetComponent<ObjectTypeManager>().SetIsOutbreakOff();
        //修正後に判定して正だったら
        if (GetIsAllReported())
        {
            //ゲームクリア
            _gameManager.GetComponent<GameTime>().SetGameClearFlag();
        }

    }

    /// <summary>
    /// レポート済異変の数量取得
    /// </summary>
    /// <returns></returns>
    static public int GetReportedPhenomenonCount()
    {
        return _reportedPhenomenonCount;
    }

    /// <summary>
    /// 発生した異変の総数
    /// </summary>
    /// <returns></returns>
    static public int GetAlreadyPhenomenonCount()
    {
        return _alreadyPhenomenonCount;
    }
    ///// <summary>
    ///// 未発見の異変の数
    ///// </summary>
    ///// <returns></returns>
    static public int GetStillReportedAnomalyCount()
    {
        return _stillAnomalyNameList.Count;
    }
    /// <summary>
    /// 全ての異変を報告したか取得する
    /// </summary>
    /// <returns></returns>
    public bool GetIsAllReported()
    {
        //生成可能オブジェクトと発生中オブジェクトがともに0なら
        if ((_ableToCreateList.Count == 0) && (_alreadyCreateList.Count == 0))
        {
            //正
            return true;
        }
        //負
        return false;
    }
    /// <summary>
    /// 全ての異変を報告したか取得する
    /// </summary>
    /// <returns></returns>
    public void SearchAlreadyReportedObject()
    {
        //報告済オブジェクトが0の場合
        if(_repotedObjectsList.Count == 0)
        {
            //処理しない
            return;
        }
        //未発見オブジェクトが0の時
        if(_stillAnomalyNameList.Count == 0)
        {
            //処理しない
            return;
        }
        //
        for (int i = 0; i < _repotedObjectsList.Count; i++)
        {
            //未発見オブジェクトが0になったら
            if(_stillAnomalyNameList.Count == 0)
            {
                _stillAnomalyNameList.Clear();
                //ループ出る
                break;
            }

            int num = _stillAnomalyNameList.IndexOf(_repotedObjectsList[i].name);

            if(num == -1)
            {
                //ループやり直し
                continue;
            }
            //未発見リストから要素を削除
            _stillAnomalyNameList.RemoveAt(num);
            //Debug.Log($"未発見リスト減ったよ{_stillAnomalyNameList.Count}");

        }
    }
}