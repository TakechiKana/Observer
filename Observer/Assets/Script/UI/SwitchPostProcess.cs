using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPostProcess : MonoBehaviour
{
    [Header("�|�X�g�v���Z�X")]
    [SerializeField] private Material _postProcess = default;
    //�|�X�g�v���Z�X�̕ϐ�ID
    private readonly int _doPostProcessID = Shader.PropertyToID("_DoPostProcess");    // �V�F�[�_�[�v���p�e�B��Reference��
    [Header("�|�X�g�v���Z�X�̐؂�ւ�")][Range(0,1)][Tooltip("OFF : 0 ,ON : 1")]
    [SerializeField] private float _switch = default;
    void Start()
    {
        //�|�X�g�G�t�F�N�g������
        _postProcess.SetFloat(_doPostProcessID, _switch);
    }
}
