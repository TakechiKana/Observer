using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportMenuButton : MonoBehaviour
{
    //���|�[�g���UI
    [Header("���|�[�g��ʃI�u�W�F�N�g")]
    public GameObject reportScreen = default;

    public void PointDownButton()
    {
        //�\��or��\���ɂ���
        reportScreen.SetActive(!reportScreen.activeSelf);
    }
}
