using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanish : MonoBehaviour
{
    private bool _isActive = false;

    private void Start()
    {
        SetObjectActive();
    }
    void OnEnable()
    {
        //少し待ってからフラグを立てる
        Invoke("SetObjectActive", 0.9f);
    }

    /// <summary>
    /// フラグ設定
    /// </summary>
    void SetObjectActive()
    {
        _isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isActive)
        {
            return;
        }
        if(this.GetComponent<ObjectTypeManager>().GetIsOutbreak())
        {
            _isActive = false;
            this.gameObject.SetActive(false);
        }
    }
}
