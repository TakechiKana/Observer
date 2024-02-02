using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportMenuButton : MonoBehaviour
{
    //レポート画面UI
    [Header("レポート画面オブジェクト")]
    [SerializeField]
    private GameObject _reportScreen = default;
    [Header("ボタンクリック音")]
    [SerializeField] private AudioClip _audioClip = default;

    private void Start()
    {
        _reportScreen.SetActive(false);
    }

    public void PointDownButton()
    {
        //表示or非表示にする
        _reportScreen.SetActive(!_reportScreen.activeSelf);
        this.GetComponent<AudioSource>().PlayOneShot(_audioClip);
    }
}
