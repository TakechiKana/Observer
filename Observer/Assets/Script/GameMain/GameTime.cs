using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    //�Q�[���^�C�}�[
    private float _gameTimeMinute = 0.0f;
    //�Q�[���^�C�}�[(����)
    private int _gameTimeHour = 0;
    //�Q�[���^�C�}�[�t���O
    private bool _gameTimeFlag = true;
    //�Q�[���^�C�}�[�\���e�L�X�g(����)
    [SerializeField][Header("�Q�[���^�C�}�[�\���p�e�L�X�g(����)")]
    private TextMeshProUGUI _gameTimeHourText = default;
    //�Q�[���^�C�}�[�\���e�L�X�g(��)
    [SerializeField]
    [Header("�Q�[���^�C�}�[�\���p�e�L�X�g(��)")]
    private TextMeshProUGUI _gameTimeMinuteText = default;
    void Start()
    {
        _gameTimeHourText.text = "00";
        _gameTimeMinuteText.text = "00";
    }

    void Update()
    {
        //�Q�[���^�C�}�[�t���O��false�ɂȂ�����
        if(!_gameTimeFlag)
        { 
            //�������Ȃ�
            return;
        }
        //6���ɂȂ�����
        if(_gameTimeHour >= 6)
        {
            this.GetComponent<SceneChange>().SceneChangeProcess();
        }

        //�Q�[���^�C�}�[��i�߂�
        _gameTimeMinute += Time.deltaTime;

        //�Q�[���^�C�}�[��60�b�𒴂�����
        if (_gameTimeMinute > 60.0f)
        {
            //�Q�[���^�C�}�[�̎��Ԃ�1���₷
            _gameTimeHour += 1;
            //���ԕ\��(����)
            _gameTimeHourText.text = _gameTimeHour.ToString("00");
            //�Q�[���^�C�}�[�����Z�b�g����
            _gameTimeMinute = 0f;
        }
        //���ԕ\��(��)
        _gameTimeMinuteText.text = Mathf.Floor(_gameTimeMinute).ToString("00");
    }
    /// <summary>
    /// �Q�[���^�C���̐���
    /// </summary>
    /// <param name="flag"></param>
    public void SetGameTimeFlag(bool flag)
    {
        _gameTimeFlag = flag;
    }
    /// <summary>
    /// �Q�[���^�C���̎擾
    /// </summary>
    /// <returns></returns>
    public bool GetGameTimeFlag()
    {
        return _gameTimeFlag;
    }
}
