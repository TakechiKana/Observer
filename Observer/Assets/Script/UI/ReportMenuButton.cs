using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportMenuButton : MonoBehaviour
{
    //レポート画面UI
    [Header("レポート画面オブジェクト")]
    public GameObject reportScreen = default;
    //レポート画面UIAnimation
    //[Header("レポート画面オブジェクトOpenAnimation")]
    //public Animator reportScreenAnim = default;

    public void PointDownButton()
    {
        //表示or非表示にする
        reportScreen.SetActive(!reportScreen.activeSelf);
        //if (reportScreen.activeSelf)
        //{
        //    reportScreenAnim.SetBool("isDisplay", false);
        //    //if(reportScreenAnim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
        //    //{
        //    //    reportScreen.SetActive(false);
        //    //}
        //    return;
        //}
        //reportScreen.SetActive(true);
        //reportScreenAnim.SetBool("isDisplay", true);
    }
}
