using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    //�Q�[���^�C��(��)
    static private int _gameTimeMinute = 0;
    //�Q�[���^�C��(����)
    static private int _gameTimeHour = 0;
    //�Q�[������1���Ԃ̕b��
    private float GAMETIME_MINUTE = 1.5f;

    //�Q�[���^�C�}�[�t���O
    private bool _gameTimeFlag = false;
    //�Q�[���N���A�t���O
    private bool _isGameClear = false;

    //�f�o�b�O�t���O
    private bool _isDebug = false;
    //�R���v���[�g���[�h�t���O
    private bool _isCompleteMode = false;

    //�t���O�}�l�[�W��
    private GameObject _flagManager = default;
    //�t���O�}�l�[�W��
    private GameObject _phenomenonList = default;

    //�R���[�`��
    private IEnumerator _gameTimeEnumerator = default;

    //�Q�[���^�C�}�[�\���e�L�X�g(����)
    [SerializeField][Header("�Q�[���^�C�}�[�\���p�e�L�X�g(����)")]
    private TextMeshProUGUI _gameTimeHourText = default;
    //�Q�[���^�C�}�[�\���e�L�X�g(��)
    [SerializeField]
    [Header("�Q�[���^�C�}�[�\���p�e�L�X�g(��)")]
    private TextMeshProUGUI _gameTimeMinuteText = default;
    [Header("�Q�[���I�[�o�[�pUI")]
    [SerializeField] private GameObject _gameOverPanel = default;

    /// <summary>
    /// ����������
    /// </summary>
    void Start()
    {
        Invoke("FindGameObject", 0.09f);    //�����҂��Ă���t���O�}�l�W������������
        //�e�L�X�g������
        _gameTimeHourText.text = "00";
        _gameTimeMinuteText.text = "00";
        //�^�C�}�[������
        _gameTimeHour = 0;
        _gameTimeMinute = 0;
        //�R���[�`����ϐ��Ɋi�[
        _gameTimeEnumerator = GameTimeManager();
        //�Q�[���^�C�}�[�X�^�[�g
        StartCoroutine("StartGameTime");
    }
    /// <summary>
    /// �t���O�}�l�[�W���̌���
    /// </summary>
    void FindGameObject()
    {
        //�t���O�}�l�W�����݂���
        _flagManager = GameObject.FindGameObjectWithTag("FlagManager");
        //�ٕσ��X�g��������
        _phenomenonList = GameObject.FindGameObjectWithTag("PhenomenonList");

        //�f�o�b�O���ȂǂŐ�������ĂȂ��ꍇ
        if (_flagManager == null)
        {
            //�������Ȃ�
            return;
        }
        //�R���v���[�g���[�h�t���O�i�[
        _isCompleteMode = _flagManager.GetComponent<FlagManager>().GetCompleteMode();
        //�f�o�b�O�t���O�i�[
        _isDebug = _flagManager.GetComponent<FlagManager>().GetIsDebug();
        //�f�o�b�O���[�h�̎�
        if(_isDebug)
        {
            GAMETIME_MINUTE = 1.0f;
        }
    }

    void Update()
    {
        if(!_gameTimeFlag)
        {
            return;
        }
        //�f�o�b�O���[�h�̎��A�G���^�[�L�[����������
        if (_isDebug && Input.GetKeyDown(KeyCode.Return))
        {
            //�Q�[���^�C��(����)��1���ԕ��i�߂�B
            _gameTimeHour += 1;
            _gameTimeHourText.text = _gameTimeHour.ToString("00");

        }
        //�f�o�b�O���[�h�̎��ASpace�L�[����������
        if (_isDebug && Input.GetKeyDown(KeyCode.Space))
        {
            _phenomenonList.GetComponent<PhenomenonLists>().MakePhenomenon();

        }
        //�R���v���[�g���[�h�łȂ�����6���ɂȂ�����
        if (!_isCompleteMode && _gameTimeHour == 6)
        {
            //�Q�[���N���A�t���O�𗧂Ă�
            SetGameClearFlag();
        }
        //�Q�[���N���A�t���O��true
        if (_isGameClear)
        {
            //�Q�[���N���A����
            StartCoroutine("GameClear");

        }
        if(_gameTimeHour < 0 && _gameTimeMinute < 45)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.GetComponent<AudioManager>().PlayMouseClickSound();
        }
    }

    /// <summary>
    /// �Q�[���X�^�[�g����
    /// </summary>
    /// <returns></returns>
    IEnumerator StartGameTime()
    {
        //�J�n�����1�b�҂�
        yield return new WaitForSeconds(1.0f);
        //�Q�[���^�C�}�[���쓮������
        SetGameTimeFlag(true);
        //�R���[�`�����~
        yield break;
    }
    /// <summary>
    /// �Q�[���^�C�}�[����
    /// </summary>
    /// <returns></returns>
    IEnumerator GameTimeManager()
    {
        while (true)
        {
            yield return new WaitForSeconds(GAMETIME_MINUTE);
            _gameTimeMinute += 1;

            if (_gameTimeMinute == 60)
            {
                //����0�ɂ���
                _gameTimeMinute = 0;
                //���Ԃ𑝂₷
                _gameTimeHour += 1;
                //���ԕ\��(����)
                _gameTimeHourText.text = _gameTimeHour.ToString("00");
            }
            //���ԕ\��(��)
            _gameTimeMinuteText.text = Mathf.Floor(_gameTimeMinute).ToString("00");
            //�ŏ��̊o���鎞�ԊO�ŁA15������
            if (!MemorizeTime() && (_gameTimeMinute % 15 == 0))
            {
                //�ٕϐ���
                _phenomenonList.GetComponent<PhenomenonLists>().MakePhenomenon();
            }
        }
    }
    /// <summary>
    /// �o���鎞�Ԃ�
    /// </summary>
    /// <returns></returns>
    private bool MemorizeTime()
    {
        if (_gameTimeHour <= 0 && _gameTimeMinute < 45)
        {
            return true; ;
        }
        return false;
    }
    /// <summary>
    /// �Q�[���N���A
    /// </summary>
    IEnumerator GameClear()
    {
        //�Q�[���^�C�����~
        SetGameTimeFlag(false);
        //��ʏ���N���b�N�ł��Ȃ��悤�ɂ���
        _gameOverPanel.SetActive(true);
        //�Q�[���N���A��
        this.GetComponent<AudioManager>().PlayGameClearSound();
        //3�b(�Ȃ��Ă����)�҂�
        yield return new WaitForSeconds(1.0f);
        //���ʌ���
        this.GetComponent<FadeOutBGM>().VolumeChange();
        //���������X�g�̍X�V
        _phenomenonList.GetComponent<PhenomenonLists>().SearchAlreadyReportedObject();
        //�V�[���J��
        this.GetComponent<SceneChange>().SceneChangeProcess("GameClear");
        //�t���O�}�l�[�W���̃Q�[���N���A�t���O�̏���
        _flagManager.GetComponent<FlagManager>().SetGameClear();
        yield break;
    }

    /// <summary>
    /// �Q�[���^�C���̐���
    /// </summary>
    /// <param name="flag">�Q�[���^�C���t���O</param>
    public void SetGameTimeFlag(bool flag)
    {
        //�Q�[���^�C���t���O���i�[
        _gameTimeFlag = flag;

        //�Q�[���^�C���t���O��false�̂Ƃ�
        if (!_gameTimeFlag)
        {
            //�R���[�`�����ꎞ��~
            StopCoroutine(_gameTimeEnumerator);
            //�����I��
            return;
        }
        //�R���[�`�����ĊJ
        StartCoroutine(_gameTimeEnumerator);
    }
    /// <summary>
    /// �Q�[���N���A�t���O�̐ݒ�
    /// </summary>
    /// <returns></returns>
    public void SetGameClearFlag()
    {
        _isGameClear = true;
    }
    /// <summary>
    /// �Q�[���^�C���̎擾
    /// </summary>
    /// <returns></returns>
    public bool GetGameTimeFlag()
    {
        return _gameTimeFlag;
    }
    /// <summary>
    /// �Q�[���^�C��(��)�̎擾
    /// </summary>
    /// <returns></returns>
    static public int GetMinute()
    {
        return _gameTimeMinute;
    }

    /// <summary>
    /// �Q�[���^�C��(����)�̎擾
    /// </summary>
    /// <returns></returns>
    static public int GetHour()
    {
        return _gameTimeHour;
    }
}
