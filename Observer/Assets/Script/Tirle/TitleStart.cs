using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStart : MonoBehaviour
{
    [Header("ポストプロセス")]
    [SerializeField] private Material _postProcess = default;
    //ポストプロセスの変数ID
    private readonly int _doPostProcessID = Shader.PropertyToID("_DoPostProcess");    // シェーダープロパティのReference名
    // Start is called before the first frame update
    void Start()
    {
        _postProcess.SetFloat(_doPostProcessID, 0);
    }

}
