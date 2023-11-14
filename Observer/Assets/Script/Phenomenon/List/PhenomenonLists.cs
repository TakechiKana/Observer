using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhenomenonLists : MonoBehaviour
{
    //生成可能異常現象list
    private List<GameObject> ableToCreateList = new List<GameObject>();
    //生成後異常現象list
    private List<GameObject> alreadyCreateList = new List<GameObject>();
    //生成用タイマー
    [SerializeField] private float timer = 15.0f;
    //オブジェクトカウント用変数
    //全体数
    private int allPhenomenonCount = 0;


    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start()
    {
        //異常現象生成用のリスト作成
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //listにゲームオブジェクトを格納していく
            ableToCreateList.Add(this.transform.GetChild(i).gameObject);
        }
        //全体数格納
        allPhenomenonCount = ableToCreateList.Count;
    }


    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) || timer < 0)
        {

            //異常現象発生
            MakePhenomenon();
            //タイマー再設定
            timer = 10.0f;
            //デバッグ
            //DebugMethod();
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
        if(phenoType == Phenomenon.ObjectType.DisappearObject
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
        ///
        ///デバッグ
        ///
        if(ableToCreateList.Count<=0)
        {
            Debug.Log("0Dayo");
            return;
        }
        ///


        //乱数の生成
        int rand = Random.Range(0, ableToCreateList.Count);

        ///デバッグ
        Debug.Log(ableToCreateList[rand]);

        //変数にオブジェクトを格納する
        GameObject gameObj = ableToCreateList[rand];
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

                    ///デバッグ
                    Debug.Log("報告成功");
                    return;
                }
            }
        }
        ///デバッグ
        Debug.Log("報告失敗");
        
        //一致するオブジェクトが無かったら
        return;

    }


    /// <summary>
    /// 異常現象を発生させる
    /// </summary>
    private void FixPhenomenon(GameObject gameObj)
    {
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
        //現象発生フラグを正にする
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
