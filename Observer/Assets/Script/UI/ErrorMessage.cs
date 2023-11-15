using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMessage : MonoBehaviour
{
    private float _displayTimer = 0f;   //�\���^�C�}�[
    private const float DISPLAY_TIMER_MAX = 2f; //�\���^�C�}�[�萔
    // Start is called before the first frame update
    void Start()
    {
        //�^�C�}�[�̃Z�b�g
        _displayTimer = DISPLAY_TIMER_MAX;
    }

    // Update is called once per frame
    void Update()
    {
        //�^�C�}�[��0�ȉ��̎�
        if(_displayTimer <= 0.0f)
        {
            this.gameObject.SetActive(false);
            //�������Ȃ�
            return;
        }
        //�^�C�}�[���Z
        _displayTimer -= Time.deltaTime;
    }
    private void OnEnable()
    {
        //�^�C�}�[�̃Z�b�g
        _displayTimer = DISPLAY_TIMER_MAX;
    }
}
