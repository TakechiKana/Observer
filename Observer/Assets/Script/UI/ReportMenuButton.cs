using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportMenuButton : MonoBehaviour
{
    //レポート画面UI
    [Header("レポート画面オブジェクト")]
    public GameObject reportScreen = default;

    public void PointDownButton()
    {
        //表示or非表示にする
        reportScreen.SetActive(!reportScreen.activeSelf);
    }
}
