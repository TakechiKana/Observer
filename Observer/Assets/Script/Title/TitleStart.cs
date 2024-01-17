using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStart : MonoBehaviour
{
    [Header("フェードスクリーン")]
    [SerializeField] private GameObject _fadeScreen = default;
    [Header("フラグマネージャ")]
    [SerializeField] private GameObject _flagManager = default;
    // Start is called before the first frame update
    void Start()
    {
        //フラグマネージャ生成
        Instantiate(_flagManager);
        //フェードスクリーン生成
        Instantiate(_fadeScreen);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _flagManager.GetComponent<FlagManager>().SetDebug();
        }
    }
}
