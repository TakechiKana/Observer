using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutBGM : MonoBehaviour
{
    private AudioSource _audioSource = default;
    private void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }
    public void VolumeChange()
    {
        StartCoroutine("VolumeDown");
    }

    IEnumerator VolumeDown()
    {
        while (_audioSource.volume > 0)
        {
            _audioSource.volume -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }
}
