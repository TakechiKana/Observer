using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichPostProcessing : MonoBehaviour
{
    //�|�X�g�G�t�F�N�g
    [SerializeField] private Material _postProcess = default;
    // Start is called before the first frame update
    void Start()
    {
        //�I���ɂ���
        _postProcess.SetFloat("_DoPostProcess", 1f);
    }

    public void OffPostProcess()
    {
        //�I���ɂ���
        _postProcess.SetFloat("_DoPostProcess", 0f);

    }
}
