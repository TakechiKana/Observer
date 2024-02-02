using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("�}�E�X�N���b�N��")]
    [SerializeField] private AudioClip _mouseClick = default;
    [Header("�Q�[���I�[�o�[�̃m�C�Y��")]
    [SerializeField] private AudioClip _gameOverNoise = default;
    [Header("�Q�[���N���A�̃A���[����")]
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
    /// �Q�[���I�[�o�[���O�̃m�C�Y��
    /// </summary>
    public void PlayGameOverSound()
    {
        _audioSource.PlayOneShot(_gameOverNoise);
    }
    /// <summary>
    /// �Q�[���I�[�o�[���O�̃m�C�Y��
    /// </summary>
    public void PlayMouseClickSound()
    {
        _audioSource.PlayOneShot(_mouseClick);
    }
    /// <summary>
    /// �Q�[���N���A
    /// </summary>
    public void PlayGameClearSound()
    {
        _audioSource.PlayOneShot(_gameClearSound);
    }
    
}
