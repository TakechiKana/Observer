using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("マウスクリック音")]
    [SerializeField] private AudioClip _mouseClick = default;
    [Header("ゲームオーバーのノイズ音")]
    [SerializeField] private AudioClip _gameOverNoise = default;
    [Header("ゲームクリアのアラーム音")]
    [SerializeField] private AudioClip _gameClearSound = default;

    private AudioSource _audioSource = default;

    // Start is called before the first frame update
    void Start()
    {
        
        _audioSource = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }
    /// <summary>
    /// ゲームオーバー直前のノイズ音
    /// </summary>
    public void PlayGameOverSound()
    {
        _audioSource.PlayOneShot(_gameOverNoise);
    }
    /// <summary>
    /// ゲームオーバー直前のノイズ音
    /// </summary>
    public void PlayMouseClickSound()
    {
        _audioSource.PlayOneShot(_mouseClick);
    }
    /// <summary>
    /// ゲームクリア
    /// </summary>
    public void PlayGameClearSound()
    {
        _audioSource.PlayOneShot(_gameClearSound);
    }
    
}
