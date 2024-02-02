using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCompleteMode : MonoBehaviour
{
    private GameObject _flagManager = default;   //�t���O�}�l�[�W���[

    private void Start()
    {
        Invoke("FindFlagObject", 0.09f);    //�����҂��Ă���t���O�}�l�W������������
    }
    void FindFlagObject()
    {
        _flagManager = GameObject.FindGameObjectWithTag("FlagManager");//�t���O�}�l�W�����݂���
        if (_flagManager == null)
        {
            return;
        }
    }
    public void SetCompleteModeButton()
    {
        _flagManager.GetComponent<FlagManager>().SetCompleteMode(true);
    }
}
