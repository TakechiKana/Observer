using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportButton : MonoBehaviour
{
    [Header("部屋ボタンの場合はここだけを設定")]
    [SerializeField] Phenomenon.Rooms room = default;

    [Header("オブジェクトタイプボタンの場合はここだけを設定")]
    [SerializeField] Phenomenon.ObjectType objectType = default;
    
    [Header("選択時の効果音")]
    [SerializeField] AudioClip _audioClip = default;
    //レポートボタン
    private GameObject reportButton = default;
    

    private void Start()
    {
        //レポートボタンを検索する
        reportButton = GameObject.Find("ReportManager");
        //オーディオソースコンポーネントを追加する
        this.gameObject.AddComponent<AudioSource>();
        //オーディオソースのボリューム
        this.gameObject.GetComponent<AudioSource>().volume = 0.5f;
    }
    /// <summary>
    /// 部屋報告ボタン
    /// </summary>
    public void ClickRoomButton()
    {
        reportButton.GetComponent<ReportProcess>().SetReportRoom(room,this.transform.position);
        PlaySE();
    }
    /// <summary>
    /// オブジェクトタイプ報告ボタン
    /// </summary>
    public void ClickTypeButton()
    {
        reportButton.GetComponent<ReportProcess>().SetReportObjectType(objectType,this.transform.position);
        PlaySE();
    }

    private void PlaySE()
    {
        this.GetComponent<AudioSource>().PlayOneShot(_audioClip);
    }
}
