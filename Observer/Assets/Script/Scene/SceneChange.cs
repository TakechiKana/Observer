using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private const float CONST_NOISETIMER = 0.1f;                                    //ノイズタイマー用定数
    private GameObject fadeCanvas = null;                                           //フェードスクリーン
    private AsyncOperation _async = default;                                        //シーン切替用変数
    private string _sceneName = default;                                            //シーン名
    private bool _isChanging = false;                                               //シーン切替中か

    private void Start()
    {
        Invoke("FindFadeObject", 0.09f);    //少し待ってからフェードオブジェクトを検索する
    }
    void FindFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");//Canvasをみつける
        if(fadeCanvas == null)
        {
            return;
        }
    }

    public void SceneChangeProcess(string sName)
    {
        //既にシーン切替中のとき
        if(_isChanging)
        {
            //処理しない
            return;
        }
        //シーン名を変数に格納
        _sceneName = sName;
        //シーンが既に読み込まれているか調べる
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            //読み込み済のシーン
            Scene scene = SceneManager.GetSceneAt(i);
            //既に読み込まれていたら
            if (scene.name == _sceneName)
            {
                //処理しない
                return;
            }
        }
        //シーン切替中フラグを設定する
        _isChanging = true;
        //シーンを読み込む
        StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {
        fadeCanvas.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fadeCanvas.GetComponent<FadeManager>().SetFadeOut();
        yield return new WaitForSeconds(1.0f);
        _async = SceneManager.LoadSceneAsync(_sceneName);
        _async.allowSceneActivation = false;
        yield return new WaitForSeconds(2.0f);
        _async.allowSceneActivation = true;
        fadeCanvas.GetComponent<FadeManager>().SetFadeIn();
        yield break;
    }

}
