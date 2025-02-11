using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportProcess : MonoBehaviour
{
    //現象のオブジェクトタイプ
    private Phenomenon.ObjectType objectType = 0;
    //現象の部屋
    private Phenomenon.Rooms room = 0;
    [Header("PhenomenonLists.csがアタッチされたオブジェクト")]
    [SerializeField] GameObject phenomenonList = default;
    [Header("エラーメッセージオブジェクト")]
    [SerializeField] GameObject _errorMessageObj = default;
    [Header("レポート中エフェクト用オブジェクト")]
    [SerializeField] GameObject _repotingMessageObj = default;
    [Header("レポートスクリーン")]
    [SerializeField] GameObject _reportScreen = default;
    
    [Header("レポートメニュー")]
    [SerializeField] GameObject _reportMenu = default;
    [Header("カメラの選択中アイコン")] 
    [SerializeField] private GameObject selectedCamera = default;
    [Header("タイプの選択中アイコン")]
    [SerializeField] private GameObject selectedType = default;
    //[Header("選択音")] 
    //[SerializeField] private AudioClip _audioClip1 = default;
    [Header("送信失敗音")]
    [SerializeField] private AudioClip _audioClip2 = default;
    [Header("送信成功音")]
    [SerializeField] private AudioClip _audioClip3 = default;
    public void ReportSend()
    {
        //どちらか片方でも空になっているとき
        if(objectType == default || room == default)
        {
            //報告できない場合、エラーメッセージを表示する。
            _errorMessageObj.SetActive(true);
            //エラー音
            this.GetComponent<AudioSource>().PlayOneShot(_audioClip2);
            return;
        }

        //エラーメッセージが表示されていたら
        if(_errorMessageObj.activeSelf)
        {
            //非表示
            _errorMessageObj.SetActive(false);
        }
        //選択音
        this.GetComponent<AudioSource>().PlayOneShot(_audioClip3);
        //レポートスクリーンとメニュボタンを非表示
        _reportMenu.SetActive(false);
        _reportScreen.SetActive(false);
        //レポート中エフェクトを表示
        _repotingMessageObj.SetActive(true);
    }
    public void ReportJudge()
    {
        //レポートが正しいか判定する
        phenomenonList.GetComponent<PhenomenonLists>().JudgeReport(room, objectType);
        //メニューボタンを表示
        _reportMenu.SetActive(true);
        //内容をリセット
        ReportCansel();
    }

    /// <summary>
    /// レポートをキャンセルする
    /// </summary>
    /// <param name="objType">現象のオブジェクトタイプ</param>
    public void ReportCansel()
    {
        //リセットする
        objectType = default;
        room = default;
        //選択中エフェクトを非表示
        selectedCamera.SetActive(false);
        selectedType.SetActive(false);
    }
    /// <summary>
    /// 報告したいオブジェクトタイプを設定する
    /// </summary>
    /// <param name="objType">現象のオブジェクトタイプ</param>
    public void SetReportObjectType(Phenomenon.ObjectType objType,Vector3 pos)
    {
        objectType = objType;
        //選択中エフェクトを表示
        selectedType.transform.position = pos;
        selectedType.SetActive(true);
    }


    /// <summary>
    /// 報告したい部屋を設定する
    /// </summary>
    /// <param name="_room">現象の部屋</param>
    public void SetReportRoom(Phenomenon.Rooms _room,Vector3 pos)
    {
        room = _room;
        //選択中エフェクトを表示
        selectedCamera.transform.position = pos;
        selectedCamera.SetActive(true);
    }
}
