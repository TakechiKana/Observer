using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportProcess : MonoBehaviour
{
    //現象のオブジェクトタイプ
    private Phenomenon.ObjectType objectType = default;
    //現象の部屋
    private Phenomenon.Rooms room = 0;
    [Header("PhenomenonLists.csがアタッチされたオブジェクト")]
    [SerializeField] GameObject phenomenonList = default;

    public void Report()
    {
        //どちらか片方でも空になっているとき
        if(objectType == default || room == default)
        {
            //報告できない場合、それまでに格納した部屋と種類はクリアにする。
            objectType = default;
            room = default;
            
            //デバッグ
            Debug.Log("Report Miss");
            Debug.Log(objectType);
            Debug.Log(room);


            return;
        }
        //デバッグ
        Debug.Log("Report Correct");
        Debug.Log(objectType);
        Debug.Log(room);

        //レポートが正しいか判定する
        phenomenonList.GetComponent<PhenomenonLists>().JudgeReport(room,objectType);
        objectType = 0;
        room = 0;
    }


    /// <summary>
    /// 報告したいオブジェクトタイプを設定する
    /// </summary>
    /// <param name="objType">現象のオブジェクトタイプ</param>
    public void SetReportObjectType(Phenomenon.ObjectType objType)
    {
        objectType = objType;

        //デバッグ
        Debug.Log("Type Set");
        Debug.Log(objectType);
    }


    /// <summary>
    /// 報告したい部屋を設定する
    /// </summary>
    /// <param name="_room">現象の部屋</param>
    public void SetReportRoom(Phenomenon.Rooms _room)
    {
        room = _room;

        //デバッグ
        Debug.Log("Room Set");
        Debug.Log(room);
    }
}
