using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportMenuButton : MonoBehaviour
{
    //���|�[�g���UI
    [Header("���|�[�g��ʃI�u�W�F�N�g")]
    [SerializeField]
    private GameObject _reportScreen = default;
    [Header("�{�^���N���b�N��")]
    [SerializeField] private AudioClip _audioClip = default;

    private void Start()
    {
        _reportScreen.SetActive(false);
    }

    public void PointDownButton()
    {
        //�\��or��\���ɂ���
        _reportScreen.SetActive(!_reportScreen.activeSelf);
        this.GetComponent<AudioSource>().PlayOneShot(_audioClip);
    }
}
