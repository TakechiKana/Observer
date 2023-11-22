using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportMenuButton : MonoBehaviour
{
    //���|�[�g���UI
    [Header("���|�[�g��ʃI�u�W�F�N�g")]
    public GameObject _reportScreen = default;
    //���|�[�g���UIAnimation
    //[Header("���|�[�g��ʃI�u�W�F�N�gOpenAnimation")]
    //public Animator reportScreenAnim = default;

    private void Start()
    {
        _reportScreen.SetActive(false);
    }

    public void PointDownButton()
    {
        //�\��or��\���ɂ���
        _reportScreen.SetActive(!_reportScreen.activeSelf);
    }
}
