using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    //ゲームタイム(分)
    static private int _gameTimeMinute = 0;
    //ゲームタイム(時間)
    static private int _gameTimeHour = 0;
    //ゲーム内の1分間の秒数
    private float GAMETIME_MINUTE = 1.5f;

    //ゲームタイマーフラグ
    private bool _gameTimeFlag = false;
    //ゲームクリアフラグ
    private bool _isGameClear = false;

    //デバッグフラグ
    private bool _isDebug = false;
    //コンプリートモードフラグ
    private bool _isCompleteMode = false;

    //フラグマネージャ
    private GameObject _flagManager = default;
    //フラグマネージャ
    private GameObject _phenomenonList = default;

    //コルーチン
    private IEnumerator _gameTimeEnumerator = default;

    //ゲームタイマー表示テキスト(時間)
    [SerializeField][Header("ゲームタイマー表示用テキスト(時間)")]
    private TextMeshProUGUI _gameTimeHourText = default;
    //ゲームタイマー表示テキスト(分)
    [SerializeField]
    [Header("ゲームタイマー表示用テキスト(分)")]
    private TextMeshProUGUI _gameTimeMinuteText = default;
    [Header("ゲームオーバー用UI")]
    [SerializeField] private GameObject _gameOverPanel = default;

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start()
    {
        Invoke("FindGameObject", 0.09f);    //少し待ってからフラグマネジャを検索する
        //テキスト初期化
        _gameTimeHourText.text = "00";
        _gameTimeMinuteText.text = "00";
        //タイマー初期化
        _gameTimeHour = 0;
        _gameTimeMinute = 0;
        //コルーチンを変数に格納
        _gameTimeEnumerator = GameTimeManager();
        //ゲームタイマースタート
        StartCoroutine("StartGameTime");
    }
    /// <summary>
    /// フラグマネージャの検索
    /// </summary>
    void FindGameObject()
    {
        //フラグマネジャをみつける
        _flagManager = GameObject.FindGameObjectWithTag("FlagManager");
        //異変リストを見つける
        _phenomenonList = GameObject.FindGameObjectWithTag("PhenomenonList");

        //デバッグ中などで生成されてない場合
        if (_flagManager == null)
        {
            //処理しない
            return;
        }
        //コンプリートモードフラグ格納
        _isCompleteMode = _flagManager.GetComponent<FlagManager>().GetCompleteMode();
        //デバッグフラグ格納
        _isDebug = _flagManager.GetComponent<FlagManager>().GetIsDebug();
        //デバッグモードの時
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
        //デバッグモードの時、エンターキーを押したら
        if (_isDebug && Input.GetKeyDown(KeyCode.Return))
        {
            //ゲームタイム(時間)を1時間分進める。
            _gameTimeHour += 1;
            _gameTimeHourText.text = _gameTimeHour.ToString("00");

        }
        //デバッグモードの時、Spaceキーを押したら
        if (_isDebug && Input.GetKeyDown(KeyCode.Space))
        {
            _phenomenonList.GetComponent<PhenomenonLists>().MakePhenomenon();

        }
        //コンプリートモードでない時に6時になったら
        if (!_isCompleteMode && _gameTimeHour == 6)
        {
            //ゲームクリアフラグを立てる
            SetGameClearFlag();
        }
        //ゲームクリアフラグがtrue
        if (_isGameClear)
        {
            //ゲームクリア処理
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
    /// ゲームスタート処理
    /// </summary>
    /// <returns></returns>
    IEnumerator StartGameTime()
    {
        //開始直後は1秒待つ
        yield return new WaitForSeconds(1.0f);
        //ゲームタイマーを作動させる
        SetGameTimeFlag(true);
        //コルーチンを停止
        yield break;
    }
    /// <summary>
    /// ゲームタイマー処理
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
                //分を0にする
                _gameTimeMinute = 0;
                //時間を増やす
                _gameTimeHour += 1;
                //時間表示(時間)
                _gameTimeHourText.text = _gameTimeHour.ToString("00");
            }
            //時間表示(分)
            _gameTimeMinuteText.text = Mathf.Floor(_gameTimeMinute).ToString("00");
            //最初の覚える時間外で、15分毎に
            if (!MemorizeTime() && (_gameTimeMinute % 15 == 0))
            {
                //異変生成
                _phenomenonList.GetComponent<PhenomenonLists>().MakePhenomenon();
            }
        }
    }
    /// <summary>
    /// 覚える時間か
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
    /// ゲームクリア
    /// </summary>
    IEnumerator GameClear()
    {
        //ゲームタイムを停止
        SetGameTimeFlag(false);
        //画面上をクリックできないようにする
        _gameOverPanel.SetActive(true);
        //ゲームクリア音
        this.GetComponent<AudioManager>().PlayGameClearSound();
        //3秒(なっている間)待つ
        yield return new WaitForSeconds(1.0f);
        //音量減衰
        this.GetComponent<FadeOutBGM>().VolumeChange();
        //未発見リストの更新
        _phenomenonList.GetComponent<PhenomenonLists>().SearchAlreadyReportedObject();
        //シーン遷移
        this.GetComponent<SceneChange>().SceneChangeProcess("GameClear");
        //フラグマネージャのゲームクリアフラグの処理
        _flagManager.GetComponent<FlagManager>().SetGameClear();
        yield break;
    }

    /// <summary>
    /// ゲームタイムの制御
    /// </summary>
    /// <param name="flag">ゲームタイムフラグ</param>
    public void SetGameTimeFlag(bool flag)
    {
        //ゲームタイムフラグを格納
        _gameTimeFlag = flag;

        //ゲームタイムフラグがfalseのとき
        if (!_gameTimeFlag)
        {
            //コルーチンを一時停止
            StopCoroutine(_gameTimeEnumerator);
            //処理終了
            return;
        }
        //コルーチンを再開
        StartCoroutine(_gameTimeEnumerator);
    }
    /// <summary>
    /// ゲームクリアフラグの設定
    /// </summary>
    /// <returns></returns>
    public void SetGameClearFlag()
    {
        _isGameClear = true;
    }
    /// <summary>
    /// ゲームタイムの取得
    /// </summary>
    /// <returns></returns>
    public bool GetGameTimeFlag()
    {
        return _gameTimeFlag;
    }
    /// <summary>
    /// ゲームタイム(分)の取得
    /// </summary>
    /// <returns></returns>
    static public int GetMinute()
    {
        return _gameTimeMinute;
    }

    /// <summary>
    /// ゲームタイム(時間)の取得
    /// </summary>
    /// <returns></returns>
    static public int GetHour()
    {
        return _gameTimeHour;
    }
}
