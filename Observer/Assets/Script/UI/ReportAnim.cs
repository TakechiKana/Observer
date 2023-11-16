using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReportAnim : MonoBehaviour
{
    [Header("レポートマネージャー")]
    [SerializeField] GameObject _repotManager = default;
    //レポート中テキスト
    private TextMeshProUGUI _reportingText = default;
    //文字数制限用タイマー
    private float _stringNumTimer = default;
    //アニメーション回数
    private int _animNum = 0;
    //アニメーション回数上限（定数）
    private const int ANIM_NUM_MAX = 5;
    //アニメーションが終わったか判定
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
        //5回以上になったら
        if(_animNum >= 5)
        {
            //レポート内容が正しいか判定
            _repotManager.GetComponent<ReportProcess>().ReportJudge();
            //アニメーション中フラグをfalseにする
            _doAnimation = false;
            //アニメーション回数をリセットする
            _animNum = 0;
            //自身を非表示
            this.gameObject.SetActive(false);
        }
        //タイマー
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
        //回数を1足す
        _animNum += 1;
    }
}
