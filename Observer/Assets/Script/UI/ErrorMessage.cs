using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMessage : MonoBehaviour
{
    private float _displayTimer = 0f;   //表示タイマー
    private const float DISPLAY_TIMER_MAX = 2f; //表示タイマー定数
    // Start is called before the first frame update
    void Start()
    {
        //タイマーのセット
        _displayTimer = DISPLAY_TIMER_MAX;
    }

    // Update is called once per frame
    void Update()
    {
        //タイマーが0以下の時
        if(_displayTimer <= 0.0f)
        {
            this.gameObject.SetActive(false);
            //処理しない
            return;
        }
        //タイマー減算
        _displayTimer -= Time.deltaTime;
    }
    private void OnEnable()
    {
        //タイマーのセット
        _displayTimer = DISPLAY_TIMER_MAX;
    }
}
