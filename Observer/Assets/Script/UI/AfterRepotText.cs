using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AfterRepotText : MonoBehaviour
{
    private const string FAIL_MESSAGE = "Report Failed";        //���|�[�g���s�e�L�X�g
    private const string SUCCESS_MESSAGE = "Anomary Fixed";     //���|�[�g�����e�L�X�g
    private const float MAX_TIMER = 2.0f;                       //�f�B�X�v���C�^�C�}�[����l
    private float _displayTimer = 0f;                           //�f�B�X�v���C�^�C�}�[
    // Start is called before the first frame update
    private void Update()
    {
        //�^�C�}�[�����Z
        _displayTimer -= Time.deltaTime;
        //�^�C�}�[��0�ȉ��ɂȂ�����
        if(_displayTimer <= 0.0f)
        {
            //�^�C�}�[���Z�b�g
            _displayTimer = 0.0f;
            //��A�N�e�B�u�ɂ���
            this.gameObject.SetActive(false);
        }
    }

    public void SetDisplayMessage(bool flag)
    {
        switch (flag)
        {
            //true�̂Ƃ�
            case true:
                //�����e�L�X�g����
                this.GetComponent<TextMeshProUGUI>().text = SUCCESS_MESSAGE;
                break;
            //false�̂Ƃ�
            case false:
                //���s�e�L�X�g����
                this.GetComponent<TextMeshProUGUI>().text = FAIL_MESSAGE;
                break;
        }
        //�^�C�}�[�̐ݒ�
        _displayTimer = MAX_TIMER;
    }
}
