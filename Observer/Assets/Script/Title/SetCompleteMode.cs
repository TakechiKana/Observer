using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCompleteMode : MonoBehaviour
{
    private GameObject _flagManager = default;   //フラグマネージャー

    private void Start()
    {
        Invoke("FindFlagObject", 0.09f);    //少し待ってからフラグマネジャを検索する
    }
    void FindFlagObject()
    {
        _flagManager = GameObject.FindGameObjectWithTag("FlagManager");//フラグマネジャをみつける
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
