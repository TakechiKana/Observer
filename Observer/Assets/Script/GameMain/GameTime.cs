using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    //ゲームタイマー
    static private float _gameTimeMinute = 0.0f;
    //ゲームタイマー(時間)
    static private int _gameTimeHour = 0;
    //ゲームタイマーフラグ
    private bool _gameTimeFlag = false;
    //ゲームクリアフラグ
    private bool _isGameClear = false;
    //デバッグフラグ
    private bool _isDebug = false;
    //フラグマネージャ
    private GameObject _flagManager = default;
    //ゲームタイマー表示テキスト(時間)
    [SerializeField][Header("ゲームタイマー表示用テキスト(時間)")]
    private TextMeshProUGUI _gameTimeHourText = default;
    //ゲームタイマー表示テキスト(分)
    [SerializeField]
    [Header("ゲームタイマー表示用テキスト(分)")]
    private TextMeshProUGUI _gameTimeMinuteText = default;
    void Start()
    {
        Invoke("FindFlagObject", 0.09f);    //少し待ってからフラグマネジャを検索する
        //テキスト初期化
        _gameTimeHourText.text = "00";
        _gameTimeMinuteText.text = "00";
        //タイマー初期化
        _gameTimeHour = 0;
        _gameTimeMinute = 0.0f;
        //ゲームタイマースタート
        StartCoroutine("StartGameTime");
    }
    void FindFlagObject()
    {
        _flagManager = GameObject.FindGameObjectWithTag("FlagManager");//フラグマネジャをみつける
        if (_flagManager == null)
        {
            return;
        }
        _isDebug = _flagManager.GetComponent<FlagManager>().GetIsDebug();
    }

    void Update()
    {
        if (_isDebug && Input.GetKeyDown(KeyCode.Return))
        {
            _gameTimeHour += 1;
        }
        //ゲームタイマーフラグがfalseになったら
        if (!_gameTimeFlag)
        { 
            //処理しない
            return;
        }
        //6時になったら
        if(_gameTimeHour >= 6　&& !_isGameClear)
        {
            this.GetComponent<SceneChange>().SceneChangeProcess("GameClear");
            _flagManager.GetComponent<FlagManager>().SetGameClear();
            _isGameClear = true;
        }

        //ゲームタイマーを進める
        _gameTimeMinute += Time.deltaTime;

        //ゲームタイマーが60秒を超えたら
        if (_gameTimeMinute > 60.0f)
        {
            //ゲームタイマーの時間を1増やす
            _gameTimeHour += 1;
            //ゲームタイマーをリセットする
            _gameTimeMinute = 0f;
        }
        //時間表示(時間)
        _gameTimeHourText.text = _gameTimeHour.ToString("00");
        //時間表示(分)
        _gameTimeMinuteText.text = Mathf.Floor(_gameTimeMinute).ToString("00");
    }

    IEnumerator StartGameTime()
    {
        yield return new WaitForSeconds(1.0f);
        _gameTimeFlag = true;
        yield break;
    }
    /// <summary>
    /// ゲームタイムの制御
    /// </summary>
    /// <param name="flag"></param>
    public void SetGameTimeFlag(bool flag)
    {
        _gameTimeFlag = flag;
    }
    /// <summary>
    /// ゲームタイムの取得
    /// </summary>
    /// <returns></returns>
    public bool GetGameTimeFlag()
    {
        return _gameTimeFlag;
    }

    static public float GetMinute()
    {
        return _gameTimeMinute;
    }
    static public int GetHour()
    {
        return _gameTimeHour;
    }
}
