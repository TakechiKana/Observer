using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportMenuButton : MonoBehaviour
{
    //���|�[�g���UI
    [Header("���|�[�g��ʃI�u�W�F�N�g")]
    public GameObject reportScreen = default;
    //���|�[�g���UIAnimation
    //[Header("���|�[�g��ʃI�u�W�F�N�gOpenAnimation")]
    //public Animator reportScreenAnim = default;

    public void PointDownButton()
    {
        //�\��or��\���ɂ���
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
