using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRiskState : MonoBehaviour
{
    //�v���C���[�̊댯�x
    [SerializeField] private int _playerRiskPoint = 0;            
    private const int PLAYER_RISK_MAX = 10;       //�댯�x�̏��
    private const int PLAYER_RISK_HIGH = 7;      //�댯�xHigh
    private const int PLAYER_RISK_MIDDLE =4;    //�댯�xMiddle
    private const int PLAYER_RISK_LOW = 1;       //�댯�xLow
    private bool _isDanger = false;              //�댯�xMAX�t���O 
    //�Q�[���I�[�o�[�t���O
    private bool _isGameOver = false;               
    //�Q�[���I�[�o�[�܂ł̐�������
    [SerializeField] private float _gameOverTimer = 0.0f;       
    //�Q�[���I�[�o�[�܂ł̐�������
    private float MAX_GAMEOVER_TIMER = 10.0f;        
    [Header("�X�e�[�g�pUI")]
    [SerializeField] private GameObject _stateUI = default;
    [Header("�X�e�[�g�pUI")]
    [SerializeField] private Material _postProcess = default;
    [Header("�Q�[���I�[�o�[�pUI")]
    [SerializeField] private GameObject _gameOverPanel = default;
    // �V�F�[�_�[�v���p�e�B��Reference��
    private readonly int _noiseTimerID = Shader.PropertyToID("_NoiseTimer");    
    private void Update()
    {
        //�댯�x��MAX�łȂ����A�Q�[���I�[�o�[�łȂ����Ƃ�
        if(!_isDanger�@|| _isGameOver)
        {
            //�������Ȃ�
            return;
        }
        //�Q�[���I�[�o�[�^�C�}�[��0�ɂȂ�����
        if(_gameOverTimer <= 0f)
        {
            StartCoroutine("GameOverProcess");
            _isGameOver = true;
            return;
        }
        //�^�C�}�[�ғ�
        _gameOverTimer -= Time.deltaTime;
    }
    /// <summary>
    /// �X�e�[�g�̏���
    /// </summary>
    private void PlayerStateManager()
    {
        //���l���ő�l
        if (_playerRiskPoint >= PLAYER_RISK_MAX)
        {
            //UI
            _stateUI.GetComponent<PlayerStateUI>().SetDanderLevel();
            //�Q�[���I�[�o�[
            _isDanger = true;
            _gameOverTimer = MAX_GAMEOVER_TIMER;
            return;
        }
        //���l��8�ȉ�
        if(_playerRiskPoint >= PLAYER_RISK_HIGH)
        {
            //UI
            _stateUI.GetComponent<PlayerStateUI>().SetHighLevel();

            return;
        }
        //���l��8�ȉ�
        if (_playerRiskPoint >= PLAYER_RISK_MIDDLE)
        {
            //UI
            _stateUI.GetComponent<PlayerStateUI>().SetMiddleLevel();

            return;
        }
        //���l��8�ȉ�
        if (_playerRiskPoint >= PLAYER_RISK_LOW)
        {
            //UI
            _stateUI.GetComponent<PlayerStateUI>().SetLowLevel();

            return;
        }
        //���l0
        if(_playerRiskPoint <= 0)
        {
            //UI
            _stateUI.GetComponent<PlayerStateUI>().SetNoneLevel();
        }
    }
    /// <summary>
    /// �댯�x�̐ݒ�
    /// </summary>
    /// <param name="point">�댯���l</param>
    /// <param name="flag">true = ���Z,false = ���Z</param>
    public void SetPlayerRiskPoint(int point,bool flag)
    {

        switch(flag)
        {
            case true:
                _playerRiskPoint += point;
                if (_playerRiskPoint > 10)
                {
                    _playerRiskPoint = 10;
                }
                break;
            case false:
                //���Z����O�ɂɊ댯�x��Max�������ꍇ
                if(_isDanger)
                {
                    _isDanger = false;

                }
                //flag��false�̏ꍇ�͌��Z
                _playerRiskPoint -= point;
                if (_playerRiskPoint < 0)
                {
                    _playerRiskPoint = 0;
                }
                break;
        }
        PlayerStateManager();
        //�f�o�b�O�@
        //Debug.Log($"�댯�x{_playerRiskPoint}");
    }
    /// <summary>
    /// �Q�[���I�[�o�[����
    /// </summary>
    IEnumerator GameOverProcess()
    {
        this.GetComponent<GameTime>().SetGameTimeFlag(false);
        _gameOverPanel.SetActive(true);
        this.GetComponent<AudioManager>().PlayGameOverSound();
        _postProcess.SetFloat(_noiseTimerID, 1.0f);
        yield return new WaitForSeconds(2.0f);
        this.GetComponent<FadeOutBGM>().VolumeChange();
        this.GetComponent<SceneChange>().SceneChangeProcess("GameOver");
        yield return new WaitForSeconds(0.5f);
        _postProcess.SetFloat(_noiseTimerID, 0f);
        yield break;
    }
    /// <summary>
    /// �댯�x�̎擾�B
    /// </summary>
    public int GetPlayerRiskPoint()
    {
        return _playerRiskPoint;
    }
    /// <summary>
    /// �Q�[���I�[�o�[�̎擾
    /// </summary>
    /// <returns></returns>
    public bool GetIsDanger()
    {
        return _isDanger;
    }
}
