using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRiskState : MonoBehaviour
{
    private int _playerRiskPoint = 0;            //�v���C���[�̊댯�x
    private const int PLAYER_RISK_MAX = 10;       //�댯�x�̏��
    private const int PLAYER_RISK_HIGH = 7;      //�댯�xHigh
    private const int PLAYER_RISK_MIDDLE =4;    //�댯�xMiddle
    private const int PLAYER_RISK_LOW = 1;       //�댯�xLow
    private bool _isGameOver = false;
    [Header("�X�e�[�g�pUI")]
    [SerializeField] private GameObject _stateUI = default;
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
            _isGameOver = true;
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
    /// 
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
        Debug.Log($"�댯�x{_playerRiskPoint}");
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
    public bool GetIsGameOver()
    {
        return _isGameOver;
    }
}
