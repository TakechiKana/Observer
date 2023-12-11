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
    private bool _gameTimeFlag = true;
    //ゲームタイマー表示テキスト(時間)
    [SerializeField][Header("ゲームタイマー表示用テキスト(時間)")]
    private TextMeshProUGUI _gameTimeHourText = default;
    //ゲームタイマー表示テキスト(分)
    [SerializeField]
    [Header("ゲームタイマー表示用テキスト(分)")]
    private TextMeshProUGUI _gameTimeMinuteText = default;
    void Start()
    {
        //テキスト初期化
        _gameTimeHourText.text = "00";
        _gameTimeMinuteText.text = "00";
        //タイマー初期化
        _gameTimeHour = 0;
        _gameTimeMinute = 0.0f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            _gameTimeHour += 1;
        }
        //ゲームタイマーフラグがfalseになったら
        if(!_gameTimeFlag)
        { 
            //処理しない
            return;
        }
        //6時になったら
        if(_gameTimeHour >= 6)
        {
            this.GetComponent<SceneChange>().SceneChangeProcess("GameClear");
        }

        //ゲームタイマーを進める
        _gameTimeMinute += Time.deltaTime;

        //ゲームタイマーが60秒を超えたら
        if (_gameTimeMinute > 60.0f)
        {
            //ゲームタイマーの時間を1増やす
            _gameTimeHour += 1;
            //時間表示(時間)
            _gameTimeHourText.text = _gameTimeHour.ToString("00");
            //ゲームタイマーをリセットする
            _gameTimeMinute = 0f;
        }
        //時間表示(分)
        _gameTimeMinuteText.text = Mathf.Floor(_gameTimeMinute).ToString("00");
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
