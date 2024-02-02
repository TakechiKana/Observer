using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    //public static bool isFadeInstance = false;      //ゲーム起動時のキャンバス生成フラグ

    public bool _isFadeIn = false;//フェードインするフラグ
    public bool _isFadeOut = false;//フェードアウトするフラグ

    public float _alpha = 0.0f;//透過率、これを変化させる
    public float _fadeSpeed = 0.2f;//フェードに掛かる時間

    //フラグマネージャ
    private GameObject _flagManager = default;
    void Start()
    {
        this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, _alpha);
        Invoke("FindFlagObject", 0.09f);    //少し待ってからフェードオブジェクトを検索する
        //isFadeInstance = true;
    }
    /// <summary>
    /// フラグマネージャの検索
    /// </summary>
    void FindFlagObject()
    {
        //フラグマネジャをみつける
        _flagManager = GameObject.FindGameObjectWithTag("FlagManager");
        //デバッグ中などでフラグマネージャが生成されていないとき
        if (_flagManager == null)
        {
            //処理しない
            return;
        }

        //フラグマネージャからゲーム起動済か取得する
        if (_flagManager.GetComponent<FlagManager>().GetGameStart())
        {
            //起動していたら自身を削除
            Destroy(this);
            return;
        }
        //シーン間で保持できるようにする
        DontDestroyOnLoad(this);
        //ゲーム起動フラグを設定する
        _flagManager.GetComponent<FlagManager>().SetGameStart();
    }

    void Update()
    {
        if (_isFadeIn)
        {
            if(_isFadeOut)
            {
                _isFadeOut = false;
            }
            _alpha -= Time.deltaTime / _fadeSpeed;
            if (_alpha <= 0.0f)//透明になったら、フェードインを終了
            {
                _isFadeIn = false;
                _alpha = 0.0f;
                this.gameObject.SetActive(false);
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, _alpha);
        }
        else if (_isFadeOut)
        {
            _alpha += Time.deltaTime / _fadeSpeed;
            if (_alpha >= 1.0f)//真っ黒になったら、フェードアウトを終了
            {
                //isFadeOut = false;
                _alpha = 1.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, _alpha);
        }
    }

    public void SetFadeIn()
    {
        StartCoroutine("WaitFadeIn");
        
    }

    public void SetFadeOut()
    {
        _isFadeOut = true;
        _isFadeIn = false;
    }
    IEnumerator WaitFadeIn()
    {
        //1秒待つ
        yield return new WaitForSeconds(1.0f);
        //フラグ管理
        _isFadeIn = true;
        _isFadeOut = false;
        //コルーチンを停止
        yield break;
    }
    public bool GetIsFadeOut()
    {
        return _isFadeOut;
    }

    public bool GetDoFade()
    {
        return _isFadeOut == false && _isFadeIn == false;
    }
}
