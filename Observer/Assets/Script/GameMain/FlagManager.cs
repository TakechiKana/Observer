using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    private static bool _isGameStart = false;           //�Q�[���N���t���O
    private static bool _alreadyGameClear = false;      //�Q�[���N���A�t���O
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
    /// �Q�[���N���A�t���O�̐ݒ�
    /// </summary>
    public void SetGameClear()
    {
        _alreadyGameClear = true;
    }
    /// <summary>
    /// �Q�[��Start�t���O�̐ݒ�
    /// </summary>
    public void SetGameStart()
    {
        _isGameStart = true;
    }
    /// <summary>
    /// �f�o�b�O�t���O�̐ݒ�
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
