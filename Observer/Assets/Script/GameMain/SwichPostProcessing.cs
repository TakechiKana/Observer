using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichPostProcessing : MonoBehaviour
{
    //ポストエフェクト
    [SerializeField] private Material _postProcess = default;
    // Start is called before the first frame update
    void Start()
    {
        //オンにする
        _postProcess.SetFloat("_DoPostProcess", 1f);
    }

    public void OffPostProcess()
    {
        //オンにする
        _postProcess.SetFloat("_DoPostProcess", 0f);

    }
}
