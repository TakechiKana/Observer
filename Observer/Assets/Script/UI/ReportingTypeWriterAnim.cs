using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReportingTypeWriterAnim : MonoBehaviour
{
    [Header("���|�[�g�}�l�[�W���[")]
    [SerializeField] GameObject _repotManager = default;
    [Header("�\���e�L�X�g")]
    [SerializeField] string _displayText = default;
    //���|�[�g���e�L�X�g
    private TextMeshProUGUI _reportingText = default;
    //�A�j���[�V�����񐔏���i�萔�j
    private int DISPLAYTEXT_LENGTH_MAX = 0;

    void Start()
    {
        //TMP�i�[
        _reportingText = this.gameObject.GetComponent<TextMeshProUGUI>();
        //�ő啶�����̎擾
        DISPLAYTEXT_LENGTH_MAX = _displayText.Length;
        //TMP�ɕ����Z�b�g
        _reportingText.SetText(_displayText);
        //�����̕\������ݒ�
        _reportingText.maxVisibleCharacters = 0;
    }

    private void OnEnable()
    {
        StartCoroutine("ReportingAnimation");
    }

    private void OnDisable()
    {
        StopCoroutine("ReportingAnimation");
    }

    IEnumerator ReportingAnimation()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j <= DISPLAYTEXT_LENGTH_MAX; j++)
            {
                //0.2�b�҂�
                yield return new WaitForSeconds(0.1f);
                //�\����������ݒ肷��
                _reportingText.maxVisibleCharacters = j;
            }
        }
        //���|�[�g���e��������������
        _repotManager.GetComponent<ReportProcess>().ReportJudge();
        //��A�N�e�B�u�ɂ���
        this.gameObject.SetActive(false);
    }


}
