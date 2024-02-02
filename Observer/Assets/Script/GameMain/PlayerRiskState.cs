using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRiskState : MonoBehaviour
{
    //プレイヤーの危険度
    [SerializeField] private int _playerRiskPoint = 0;            
    private const int PLAYER_RISK_MAX = 10;       //危険度の上限
    private const int PLAYER_RISK_HIGH = 7;      //危険度High
    private const int PLAYER_RISK_MIDDLE =4;    //危険度Middle
    private const int PLAYER_RISK_LOW = 1;       //危険度Low
    private bool _isDanger = false;              //危険度MAXフラグ 
    //ゲームオーバーフラグ
    private bool _isGameOver = false;               
    //ゲームオーバーまでの制限時間
    [SerializeField] private float _gameOverTimer = 0.0f;       
    //ゲームオーバーまでの制限時間
    private float MAX_GAMEOVER_TIMER = 10.0f;        
    [Header("ステート用UI")]
    [SerializeField] private GameObject _stateUI = default;
    [Header("ステート用UI")]
    [SerializeField] private Material _postProcess = default;
    [Header("ゲームオーバー用UI")]
    [SerializeField] private GameObject _gameOverPanel = default;
    // シェーダープロパティのReference名
    private readonly int _noiseTimerID = Shader.PropertyToID("_NoiseTimer");    
    private void Update()
    {
        //危険度がMAXでないか、ゲームオーバーでない時とき
        if(!_isDanger　|| _isGameOver)
        {
            //処理しない
            return;
        }
        //ゲームオーバータイマーが0になったら
        if(_gameOverTimer <= 0f)
        {
            StartCoroutine("GameOverProcess");
            _isGameOver = true;
            return;
        }
        //タイマー稼働
        _gameOverTimer -= Time.deltaTime;
    }
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
            _isDanger = true;
            _gameOverTimer = MAX_GAMEOVER_TIMER;
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
    /// 危険度の設定
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
                //減算する前にに危険度がMaxだった場合
                if(_isDanger)
                {
                    _isDanger = false;

                }
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
        //Debug.Log($"危険度{_playerRiskPoint}");
    }
    /// <summary>
    /// ゲームオーバー処理
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
    public bool GetIsDanger()
    {
        return _isDanger;
    }
}
