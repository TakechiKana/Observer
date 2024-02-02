using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTypeManager : MonoBehaviour
{
    [Header("異常現象のへや")]
    public Phenomenon.Rooms room = default;
    [Header("異常現象のオブジェクトタイプ")]
    public Phenomenon.ObjectType objectType = default;
    [Header("発生中か")]
    [SerializeField]
    private bool isOutbreak = false;
    [Header("危険度")]
    [SerializeField]
    private int _riskValue = 1;
    //異常現象リストがアタッチされたゲームオブジェクト
    private GameObject _phenomenonList = default;


    private void Start()
    {
        //PhenomenonObjectsManagerオブジェクトを検索
        _phenomenonList = GameObject.Find("PhenomenonObjectsManager");
        //異常現象生成用のリストに追加
        _phenomenonList.GetComponent<PhenomenonLists>().AddAbleToCreateList(this.gameObject);
        //カメラオブジェクトのとき
        if (objectType == Phenomenon.ObjectType.Camera)
        {
            //CameraMoveコンポーネントを追加する
            this.gameObject.AddComponent<CameraMove>();
        }
        //Moveスクリプトをアタッチするオブジェクトのとき
        if (GetAttachmentMoveScriptObject())
        {
            //Moveコンポーネントを追加する
            this.gameObject.AddComponent<MovementObject>();
        }
        //消えるオブジェクトのとき(Vanish,Light)
        if ((objectType == Phenomenon.ObjectType.Vanish)
            || (objectType == Phenomenon.ObjectType.Light))
        {
            //コンポーネントを追加する
            this.gameObject.AddComponent<Vanish>();
        }
        //非アクティブにするオブジェクトの時
        if (GetHiddenObject())
        {
            //Addコンポーネントを追加する
            this.gameObject.AddComponent<Add>();
            //カメラはAddコンポーネントを破棄する
            if(objectType == Phenomenon.ObjectType.Camera)
            {
                Destroy(GetComponent<Add>());
            }
            //非アクティブにする
            this.gameObject.SetActive(false);
        }
    }
    /// <summary>
    /// Moveスクリプトをアタッチするオブジェクト
    /// </summary>
    /// <returns></returns>
    bool GetAttachmentMoveScriptObject()
    {
        //Move,Door,Camera
        return objectType == Phenomenon.ObjectType.Move || objectType == Phenomenon.ObjectType.Door;
    }

    bool GetHiddenObject()
    {
        return objectType == Phenomenon.ObjectType.AddObject || 
            objectType == Phenomenon.ObjectType.Blood || 
            objectType == Phenomenon.ObjectType.Camera || 
            objectType == Phenomenon.ObjectType.Ghost;
    }

    /// <summary>
    /// 異常現象の発生地(部屋)の取得
    /// </summary>
    /// <returns>部屋</returns>
    public Phenomenon.Rooms GetRooms()
    {
        return room;
    }
    /// <summary>
    /// 異常現象のオブジェクトタイプの取得
    /// </summary>
    /// <returns></returns>
    public Phenomenon.ObjectType GetObjectType()
    {
        return objectType;
    }
    /// <summary>
    /// 危険度の取得
    /// </summary>
    /// <returns>危険度</returns>
    public int GetRiskValue()
    {
        return _riskValue;
    }
    /// <summary>
    /// 異常現象発生中か取得
    /// </summary>
    /// <returns></returns>
    public bool GetIsOutbreak()
    {
        return isOutbreak;
    }
    /// <summary>
    /// 異常現象発生フラグを立てる
    /// </summary>
    public void SetIsOutbreakOn()
    {
        isOutbreak = true;
    }
    /// <summary>
    /// 異常現象発生フラグを消す
    /// </summary>
    public void SetIsOutbreakOff()
    {
        isOutbreak = false;
    }
}
