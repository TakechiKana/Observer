using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateUI : MonoBehaviour
{
    //UI��RectTransform
    private RectTransform _rectTransform = default;
    //UI�̃}�e���A��
    private Material _material = default;
    //���X�N���x���ɂ��T�C�Y(����)�Ɣg�`�̑��x�ݒ�p�萔
    //Danger
    private const float DANGER_HIGHT = 100;
    private const float DANGER_SPEED = 500;
    //High
    private const float HIGH_HIGHT = 80;
    private const float HIGH_SPEED = 70;
    //Middle
    private const float MIDDLE_HIGHT = 50;
    private const float MIDDLE_SPEED = 50;
    //Low
    private const float LOW_HIGHT = 30;
    private const float LOW_SPEED = 30;
    //None
    private const float NONE_HIGHT = 30;
    private const float NONE_SPEED = 20;
    ////���l�Ԃ̋���
    //private Vector3 _distance = default;
    ////�v�Z�p�̃t���O
    //private bool _calcFlag = false;

    void Start()
    {
        //RectTransform�R���|�[�l���g�擾
        _rectTransform = transform.GetChild(0).GetComponent<RectTransform>();
        //�}�e���A��
        _material = transform.GetChild(0).GetComponent<Image>().material;
        //�T�C�Y�ƃX�s�[�h�̐ݒ�
        SetNoneLevel();
    }

    /// <summary>
    /// �ُ�Ȃ�
    /// </summary>
    public void SetNoneLevel()
    {
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, NONE_HIGHT);
        _material.SetFloat("_OffsetTime", NONE_SPEED);
    }
    /// <summary>
    /// �჌�x��
    /// </summary>
    public void SetLowLevel()
    {
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, LOW_HIGHT);
        _material.SetFloat("_OffsetTime", LOW_SPEED);
    }
    /// <summary>
    /// �����x��
    /// </summary>
    public void SetMiddleLevel()
    {
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, MIDDLE_HIGHT);
        _material.SetFloat("_OffsetTime", MIDDLE_SPEED);
    }
    /// <summary>
    /// �����x��
    /// </summary>
    public void SetHighLevel()
    {
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, HIGH_HIGHT);
        _material.SetFloat("_OffsetTime", HIGH_SPEED);
    }
    /// <summary>
    /// �댯���x��
    /// </summary>
    public void SetDanderLevel()
    {
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, DANGER_HIGHT);
        _material.SetFloat("_OffsetTime", DANGER_SPEED);
    }
}
