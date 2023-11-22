using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportMenuButton : MonoBehaviour
{
    //レポート画面UI
    [Header("レポート画面オブジェクト")]
    public GameObject _reportScreen = default;
    //レポート画面UIAnimation
    //[Header("レポート画面オブジェクトOpenAnimation")]
    //public Animator reportScreenAnim = default;

    private void Start()
    {
        _reportScreen.SetActive(false);
    }

    public void PointDownButton()
    {
        //表示or非表示にする
        _reportScreen.SetActive(!_reportScreen.activeSelf);
    }
}
