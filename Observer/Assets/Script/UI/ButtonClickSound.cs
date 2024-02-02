using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    //�{�^������p
    private bool _flag = false;
    //AudioClip
    [Header("�{�^���N���b�N��")]
    [SerializeField] private AudioClip _audioClip = default;

    private void Start()
    {
        AudioSource audio = default;
        audio = this.GetComponent<AudioSource>();
        //�I�[�f�B�I�\�[�X�R���|�[�l���g�̒ǉ�
        this.gameObject.AddComponent<AudioSource>();
    }

    public void ButtonClick()
    {
        if (!_flag)
        {
            this.GetComponent<AudioSource>().PlayOneShot(_audioClip);
            _flag = true;
        }
    }
}
