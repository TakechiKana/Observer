using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : MonoBehaviour
{
    private bool _isActive = false;

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
        //発生させた直後
        if(!_isActive)
        {
            //処理しない
            return;
        }
        //異変発生フラグが消えたら
        if(!this.GetComponent<ObjectTypeManager>().GetIsOutbreak())
        {
            //フラグを消す
            _isActive = false;
            //自身を非アクティブにする。
            this.gameObject.SetActive(false);
        }
    }
}
