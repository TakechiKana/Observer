using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPostProcess : MonoBehaviour
{
    [Header("ポストプロセス")]
    [SerializeField] private Material _postProcess = default;
    //ポストプロセスの変数ID
    private readonly int _doPostProcessID = Shader.PropertyToID("_DoPostProcess");    // シェーダープロパティのReference名
    [Header("ポストプロセスの切り替え")][Range(0,1)][Tooltip("OFF : 0 ,ON : 1")]
    [SerializeField] private float _switch = default;
    void Start()
    {
        //ポストエフェクト無効化
        _postProcess.SetFloat(_doPostProcessID, _switch);
    }
}
