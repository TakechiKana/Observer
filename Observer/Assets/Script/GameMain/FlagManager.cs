using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    private static bool _isGameStart = false;           //ゲーム起動フラグ
    private static bool _alreadyGameClear = false;      //ゲームクリアフラグ
    private static bool _isDebug = false;

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

    public bool GetGameStart()
    {
        return _isGameStart;
    }

    public bool GetGameClear()
    {
        return _alreadyGameClear;
    }
    
    public bool GetIsDebug()
    {
        return _isDebug;
    }
}
