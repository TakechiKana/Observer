using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear_DisplayTime : MonoBehaviour
{
    //�t���O�}�l�[�W��
    private GameObject _flagManager = default;
    // Start is called before the first frame update
    void Start()
    {
        //�t���O�}�l�W�����݂���
        _flagManager = GameObject.FindGameObjectWithTag("FlagManager");
        //�R���v���[�g���[�h�łȂ����
        if(!_flagManager.GetComponent<FlagManager>().GetCompleteMode())
        {
            //��\��
            this.gameObject.SetActive(false);
        }
    }
}
