using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportButton : MonoBehaviour
{
    [Header("部屋ボタンの場合はここだけを設定")]
    [SerializeField] Phenomenon.Rooms room = default;

    [Header("オブジェクトタイプボタンの場合はここだけを設定")]
    [SerializeField] Phenomenon.ObjectType objectType = default;
    //レポートボタン
    private GameObject reportButton = default;

    private void Start()
    {
        //レポートボタンを検索する
        reportButton = GameObject.Find("Report");
    }
    /// <summary>
    /// 部屋報告ボタン
    /// </summary>
    public void ClickRoomButton()
    {
        reportButton.GetComponent<ReportProcess>().SetReportRoom(room);
    }
    /// <summary>
    /// オブジェクトタイプ報告ボタン
    /// </summary>
    public void ClickTypeButton()
    {
        reportButton.GetComponent<ReportProcess>().SetReportObjectType(objectType);
    }
}
