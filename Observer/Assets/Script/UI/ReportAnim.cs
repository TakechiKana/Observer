using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReportAnim : MonoBehaviour
{
    //レポート中テキスト
    private TextMeshProUGUI _reportingText = default;
    //文字数制限用タイマー
    private float _stringNumTimer = default;

    void Start()
    {
        _reportingText = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //タイマー
        _stringNumTimer += Time.deltaTime;
        /////////////////////////////////////////
        //if (_stringNumTimer < 0.25f)
        //{
        //    _reportingText.maxVisibleCharacters = 8;
        //    return;
        //}
        //if (_stringNumTimer < 0.50f)
        //{
        //    _reportingText.maxVisibleCharacters = 9;
        //    return;
        //}
        //if (_stringNumTimer < 0.75f)
        //{
        //    _reportingText.maxVisibleCharacters = 10;
        //    return;
        //}
        //if (_stringNumTimer < 1.0f)
        //{
        //    _reportingText.maxVisibleCharacters = 11;
        //    return;
        //}
        ////////////////////////////////
        

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
    }
}
