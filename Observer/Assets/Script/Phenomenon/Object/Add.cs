using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : MonoBehaviour
{
    private bool _isActive = false;

    void OnEnable()
    {
        //�����҂��Ă���t���O�𗧂Ă�
        Invoke("SetObjectActive", 0.9f);
    }

    /// <summary>
    /// �t���O�ݒ�
    /// </summary>
    void SetObjectActive()
    {
        _isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //��������������
        if(!_isActive)
        {
            //�������Ȃ�
            return;
        }
        //�ٕϔ����t���O����������
        if(!this.GetComponent<ObjectTypeManager>().GetIsOutbreak())
        {
            //�t���O������
            _isActive = false;
            //���g���A�N�e�B�u�ɂ���B
            this.gameObject.SetActive(false);
        }
    }
}
