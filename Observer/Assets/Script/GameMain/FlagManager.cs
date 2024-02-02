using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    private static bool _isGameStart = false;           //�Q�[���N���t���O
    private static bool _alreadyGameClear = false;      //�Q�[���N���A�t���O
    private static bool _isDebug = false;               //�f�o�b�O�t���O
    private static bool _isCompleteMode = false;        //�R���v���[�g���[�h

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
    /// <summary>
    /// �R���v���[�g���[�h�t���O�̐ݒ�
    /// </summary>
    public void SetCompleteMode(bool flag)
    {
        _isCompleteMode = flag;
    }
    /// <summary>
    /// �Q�[���N���t���O�̎擾
    /// </summary>
    /// <returns></returns>
    public bool GetGameStart()
    {
        return _isGameStart;
    }
    /// <summary>
    /// �Q�[���N���A�t���O�̎擾
    /// </summary>
    /// <returns></returns>
    public bool GetGameClear()
    {
        return _alreadyGameClear;
    }
    /// <summary>
    /// �f�o�b�O���[�h�̎擾
    /// </summary>
    /// <returns></returns>
    public bool GetIsDebug()
    {
        return _isDebug;
    }
    /// <summary>
    /// �R���v���[�g���[�h���[�h�̎擾
    /// </summary>
    /// <returns></returns>
    public bool GetCompleteMode()
    {
        return _isCompleteMode;
    }

}
