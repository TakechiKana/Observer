using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportButton : MonoBehaviour
{
    [Header("�����{�^���̏ꍇ�͂���������ݒ�")]
    [SerializeField] Phenomenon.Rooms room = default;

    [Header("�I�u�W�F�N�g�^�C�v�{�^���̏ꍇ�͂���������ݒ�")]
    [SerializeField] Phenomenon.ObjectType objectType = default;
    //���|�[�g�{�^��
    private GameObject reportButton = default;
    

    private void Start()
    {
        //���|�[�g�{�^������������
        reportButton = GameObject.Find("ReportManager");
    }
    /// <summary>
    /// �����񍐃{�^��
    /// </summary>
    public void ClickRoomButton()
    {
        reportButton.GetComponent<ReportProcess>().SetReportRoom(room,this.transform.position);
    }
    /// <summary>
    /// �I�u�W�F�N�g�^�C�v�񍐃{�^��
    /// </summary>
    public void ClickTypeButton()
    {
        reportButton.GetComponent<ReportProcess>().SetReportObjectType(objectType,this.transform.position);
    }
}
