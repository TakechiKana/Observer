using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportSuccessScreen : MonoBehaviour
{
    private const float MAX_TIMER = 3.0f;           //�^�C�}�[�ő�l
    private float _displayTimer = 0.0f;             //�f�B�X�v���C�^�C�}�[
    [Header("�G���[���b�Z�[�W�I�u�W�F�N�g")]
    [SerializeField] GameObject _afterRepotMessage = default;
    [Header("�Q�[���^�C��")]
    [SerializeField] GameObject _gameTime = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_displayTimer < 0.0f)
        {
            this.gameObject.SetActive(false);
        }
        //�^�C�}�[���Z
        _displayTimer -= Time.deltaTime;
        
    }

    private void OnEnable()
    {
        _gameTime.GetComponent<GameTime>().SetGameTimeFlag(false);
        //�^�C�}�[���Z�b�g
        _displayTimer = MAX_TIMER;
    }

    private void OnDisable()
    {
        _gameTime.GetComponent<GameTime>().SetGameTimeFlag(true);
        _afterRepotMessage.SetActive(true);
        _afterRepotMessage.GetComponent<AfterRepotText>().SetDisplayMessage(true);
    }
}
