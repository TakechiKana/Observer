using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStart : MonoBehaviour
{
    [Header("�t�F�[�h�X�N���[��")]
    [SerializeField] private GameObject _fadeScreen = default;
    [Header("�t���O�}�l�[�W��")]
    [SerializeField] private GameObject _flagManager = default;
    [Header("�R���v���[�g���[�h")]
    [SerializeField] private GameObject _completeModeButton = default;
    [Header("�������ٕ̈σe�L�X�g")]
    [SerializeField] private GameObject _stillAnomalyText = default;
    // Start is called before the first frame update
    void Start()
    {
        //�t���O�}�l�[�W������
        Instantiate(_flagManager);
        //�t�F�[�h�X�N���[������
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
