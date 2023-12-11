using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStart : MonoBehaviour
{
    [Header("�|�X�g�v���Z�X")]
    [SerializeField] private Material _postProcess = default;
    //�|�X�g�v���Z�X�̕ϐ�ID
    private readonly int _doPostProcessID = Shader.PropertyToID("_DoPostProcess");    // �V�F�[�_�[�v���p�e�B��Reference��
    // Start is called before the first frame update
    void Start()
    {
        _postProcess.SetFloat(_doPostProcessID, 0);
    }

}
