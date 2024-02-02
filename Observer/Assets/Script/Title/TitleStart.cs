using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStart : MonoBehaviour
{
    [Header("フェードスクリーン")]
    [SerializeField] private GameObject _fadeScreen = default;
    [Header("フラグマネージャ")]
    [SerializeField] private GameObject _flagManager = default;
    [Header("コンプリートモード")]
    [SerializeField] private GameObject _completeModeButton = default;
    [Header("未発見の異変テキスト")]
    [SerializeField] private GameObject _stillAnomalyText = default;
    // Start is called before the first frame update
    void Start()
    {
        //フラグマネージャ生成
        Instantiate(_flagManager);
        //フェードスクリーン生成
        Instantiate(_fadeScreen);
        if (_flagManager.GetComponent<FlagManager>().GetGameClear())
        {
            //_completeModeButton.SetActive(true);
            _stillAnomalyText.SetActive(true);
            return;
        }
        _completeModeButton.SetActive(false);
        _stillAnomalyText.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _flagManager.GetComponent<FlagManager>().SetDebug();
        }
    }
}
