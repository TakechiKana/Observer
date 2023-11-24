using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AfterRepotText : MonoBehaviour
{
    private const string FAIL_MESSAGE = "Report Failed";        //レポート失敗テキスト
    private const string SUCCESS_MESSAGE = "Anomary Fixed";     //レポート成功テキスト
    private const float MAX_TIMER = 2.0f;                       //ディスプレイタイマー上限値
    private float _displayTimer = 0f;                           //ディスプレイタイマー
    // Start is called before the first frame update
    private void Update()
    {
        //タイマーを減算
        _displayTimer -= Time.deltaTime;
        //タイマーが0以下になったら
        if(_displayTimer <= 0.0f)
        {
            //タイマーリセット
            _displayTimer = 0.0f;
            //非アクティブにする
            this.gameObject.SetActive(false);
        }
    }

    public void SetDisplayMessage(bool flag)
    {
        switch (flag)
        {
            //trueのとき
            case true:
                //成功テキストを代入
                this.GetComponent<TextMeshProUGUI>().text = SUCCESS_MESSAGE;
                break;
            //falseのとき
            case false:
                //失敗テキストを代入
                this.GetComponent<TextMeshProUGUI>().text = FAIL_MESSAGE;
                break;
        }
        //タイマーの設定
        _displayTimer = MAX_TIMER;
    }
}
