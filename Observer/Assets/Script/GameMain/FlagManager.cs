using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    private static bool _isGameStart = false;           //ゲーム起動フラグ
    private static bool _alreadyGameClear = false;      //ゲームクリアフラグ
    private static bool _isDebug = false;               //デバッグフラグ
    private static bool _isCompleteMode = false;        //コンプリートモード

    private void Start()
    {
        if(_isGameStart)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);
    }
    /// <summary>
    /// ゲームクリアフラグの設定
    /// </summary>
    public void SetGameClear()
    {
        _alreadyGameClear = true;
    }
    /// <summary>
    /// ゲームStartフラグの設定
    /// </summary>
    public void SetGameStart()
    {
        _isGameStart = true;
    }
    /// <summary>
    /// デバッグフラグの設定
    /// </summary>
    public void SetDebug()
    {
        _isDebug = true;
    }
    /// <summary>
    /// コンプリートモードフラグの設定
    /// </summary>
    public void SetCompleteMode(bool flag)
    {
        _isCompleteMode = flag;
    }
    /// <summary>
    /// ゲーム起動フラグの取得
    /// </summary>
    /// <returns></returns>
    public bool GetGameStart()
    {
        return _isGameStart;
    }
    /// <summary>
    /// ゲームクリアフラグの取得
    /// </summary>
    /// <returns></returns>
    public bool GetGameClear()
    {
        return _alreadyGameClear;
    }
    /// <summary>
    /// デバッグモードの取得
    /// </summary>
    /// <returns></returns>
    public bool GetIsDebug()
    {
        return _isDebug;
    }
    /// <summary>
    /// コンプリートモードモードの取得
    /// </summary>
    /// <returns></returns>
    public bool GetCompleteMode()
    {
        return _isCompleteMode;
    }

}
