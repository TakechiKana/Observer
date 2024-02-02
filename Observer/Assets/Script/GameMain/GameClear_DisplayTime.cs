using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear_DisplayTime : MonoBehaviour
{
    //フラグマネージャ
    private GameObject _flagManager = default;
    // Start is called before the first frame update
    void Start()
    {
        //フラグマネジャをみつける
        _flagManager = GameObject.FindGameObjectWithTag("FlagManager");
        //コンプリートモードでなければ
        if(!_flagManager.GetComponent<FlagManager>().GetCompleteMode())
        {
            //非表示
            this.gameObject.SetActive(false);
        }
    }
}
