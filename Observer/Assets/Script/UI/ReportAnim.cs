using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReportAnim : MonoBehaviour
{
    [Header("���|�[�g�}�l�[�W���[")]
    [SerializeField] GameObject _repotManager = default;
    //���|�[�g���e�L�X�g
    private TextMeshProUGUI _reportingText = default;
    //�����������p�^�C�}�[
    private float _stringNumTimer = default;
    //�A�j���[�V������
    private int _animNum = 0;
    //�A�j���[�V�����񐔏���i�萔�j
    private const int ANIM_NUM_MAX = 5;
    //�A�j���[�V�������I�����������
    private bool _doAnimation = false;

    void Start()
    {
        _reportingText = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _doAnimation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_doAnimation)
        {
            return;
        }
        //5��ȏ�ɂȂ�����
        if(_animNum >= 5)
        {
            //���|�[�g���e��������������
            _repotManager.GetComponent<ReportProcess>().ReportJudge();
            //�A�j���[�V�������t���O��false�ɂ���
            _doAnimation = false;
            //�A�j���[�V�����񐔂����Z�b�g����
            _animNum = 0;
            //���g���\��
            this.gameObject.SetActive(false);
        }
        //�^�C�}�[
        _stringNumTimer += Time.deltaTime;
        if (_stringNumTimer < 0.1f)
        {
            _reportingText.maxVisibleCharacters = 0;
            return;
        }
        if (_stringNumTimer < 0.2f)
        {
            _reportingText.maxVisibleCharacters = 1;
            return;
        }
        if (_stringNumTimer < 0.3f)
        {
            _reportingText.maxVisibleCharacters = 2;
            return;
        }
        if (_stringNumTimer < 0.4f)
        {
            _reportingText.maxVisibleCharacters = 3;
            return;
        }
        if (_stringNumTimer < 0.5f)
        {
            _reportingText.maxVisibleCharacters = 4;
            return;
        }
        if (_stringNumTimer < 0.6f)
        {
            _reportingText.maxVisibleCharacters = 5;
            return;
        }
        if (_stringNumTimer < 0.7f)
        {
            _reportingText.maxVisibleCharacters = 6;
            return;
        }
        if (_stringNumTimer < 0.8f)
        {
            _reportingText.maxVisibleCharacters = 7;
            return;
        }
        if (_stringNumTimer < 1.0f)
        {
            _reportingText.maxVisibleCharacters = 8;
            return;
        }
        _stringNumTimer = 0.0f;
        //�񐔂�1����
        _animNum += 1;
    }
}
