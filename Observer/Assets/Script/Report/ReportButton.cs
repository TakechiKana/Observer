using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportButton : MonoBehaviour
{
    [Header("�����{�^���̏ꍇ�͂���������ݒ�")]
    [SerializeField] Phenomenon.Rooms room = default;

    [Header("�I�u�W�F�N�g�^�C�v�{�^���̏ꍇ�͂���������ݒ�")]
    [SerializeField] Phenomenon.ObjectType objectType = default;
    
    [Header("�I�����̌��ʉ�")]
    [SerializeField] AudioClip _audioClip = default;
    //���|�[�g�{�^��
    private GameObject reportButton = default;
    

    private void Start()
    {
        //���|�[�g�{�^������������
        reportButton = GameObject.Find("ReportManager");
        //�I�[�f�B�I�\�[�X�R���|�[�l���g��ǉ�����
        this.gameObject.AddComponent<AudioSource>();
        //�I�[�f�B�I�\�[�X�̃{�����[��
        this.gameObject.GetComponent<AudioSource>().volume = 0.5f;
    }
    /// <summary>
    /// �����񍐃{�^��
    /// </summary>
    public void ClickRoomButton()
    {
        reportButton.GetComponent<ReportProcess>().SetReportRoom(room,this.transform.position);
        PlaySE();
    }
    /// <summary>
    /// �I�u�W�F�N�g�^�C�v�񍐃{�^��
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
