using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    //ボタン制御用
    private bool _flag = false;
    //AudioClip
    [Header("ボタンクリック音")]
    [SerializeField] private AudioClip _audioClip = default;

    private void Start()
    {
        AudioSource audio = default;
        audio = this.GetComponent<AudioSource>();
        //オーディオソースコンポーネントの追加
        this.gameObject.AddComponent<AudioSource>();
    }

    public void ButtonClick()
    {
        if (!_flag)
        {
            this.GetComponent<AudioSource>().PlayOneShot(_audioClip);
            _flag = true;
        }
    }
}
