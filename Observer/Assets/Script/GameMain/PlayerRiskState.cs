using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRiskState : MonoBehaviour
{
    private int _playerRiskPoint = 0;            //プレイヤーの危険度
    private const int PLAYER_RISK_MAX = 10;       //危険度の上限
    private const int PLAYER_RISK_HIGH = 7;      //危険度High
    private const int PLAYER_RISK_MIDDLE =4;    //危険度Middle
    private const int PLAYER_RISK_LOW = 1;       //危険度Low
    private bool _isGameOver = false;
    [Header("ステート用UI")]
    [SerializeField] private GameObject _stateUI = default;
    /// <summary>
    /// ステートの処理
    /// </summary>
    private void PlayerStateManager()
    {
        //数値が最大値
        if (_playerRiskPoint >= PLAYER_RISK_MAX)
        {
            //UI
            _stateUI.GetComponent<PlayerStateUI>().SetDanderLevel();
            //ゲームオーバー
            _isGameOver = true;
            return;
        }
        //数値が8以下
        if(_playerRiskPoint >= PLAYER_RISK_HIGH)
        {
            //UI
            _stateUI.GetComponent<PlayerStateUI>().SetHighLevel();

            return;
        }
        //数値が8以下
        if (_playerRiskPoint >= PLAYER_RISK_MIDDLE)
        {
            //UI
            _stateUI.GetComponent<PlayerStateUI>().SetMiddleLevel();

            return;
        }
        //数値が8以下
        if (_playerRiskPoint >= PLAYER_RISK_LOW)
        {
            //UI
            _stateUI.GetComponent<PlayerStateUI>().SetLowLevel();

            return;
        }
        //数値0
        if(_playerRiskPoint <= 0)
        {
            //UI
            _stateUI.GetComponent<PlayerStateUI>().SetNoneLevel();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="point">危険数値</param>
    /// <param name="flag">true = 加算,false = 減算</param>
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
                //flagがfalseの場合は減算
                _playerRiskPoint -= point;
                if (_playerRiskPoint < 0)
                {
                    _playerRiskPoint = 0;
                }
                break;
        }
        PlayerStateManager();
        //デバッグ　
        Debug.Log($"危険度{_playerRiskPoint}");
    }
    /// <summary>
    /// 危険度の取得。
    /// </summary>
    public int GetPlayerRiskPoint()
    {
        return _playerRiskPoint;
    }
    /// <summary>
    /// ゲームオーバーの取得
    /// </summary>
    /// <returns></returns>
    public bool GetIsGameOver()
    {
        return _isGameOver;
    }
}
