using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterAnim : MonoBehaviour
{
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
        StartCoroutine("TypeWriter");
    }

    private void OnDisable()
    {
        StopCoroutine("TypeWriter");
    }

    IEnumerator TypeWriter()
    {
        for (int j = 0; j <= DISPLAYTEXT_LENGTH_MAX; j++)
        {
            //0.2�b�҂�
            yield return new WaitForSeconds(0.1f);
            //�\����������ݒ肷��
            _reportingText.maxVisibleCharacters = j;
            if(j == DISPLAYTEXT_LENGTH_MAX)
            {
                j = 0;
            }
        }
    }

}
