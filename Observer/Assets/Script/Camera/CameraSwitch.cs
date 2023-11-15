using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    //カメラマネージャー
    private GameObject cameraManager = default;
    //カメラ番号
    private int _cameraNo = default;
    //カメラ番号の上限
    private const int MAX_CAMERA_NO = 4;
    void Start()
    {
        //カメラマネージャーの取得
        cameraManager = GameObject.Find("CameraManager");
    }
    /// <summary>
    /// 左ボタンがクリックされたら
    /// </summary>
    public void ClickButtonL()
    {
        if(cameraManager.GetComponent<CameraManager>().GetSwitchCameraFlag())
        {
            return;
        }
        //カメラ番号を1下げる
        _cameraNo -= 1;
        //カメラ番号が0未満になったら
        if (_cameraNo < 0)
        {
            //カメラ番号を3にする
            _cameraNo = MAX_CAMERA_NO;
        }
        //カメラの切り替え
        cameraManager.GetComponent<CameraManager>().SwitchCamera();
    }
    /// <summary>
    /// 右ボタンがクリックされたら
    /// </summary>
    public void ClickButtonR()
    {
        if (cameraManager.GetComponent<CameraManager>().GetSwitchCameraFlag())
        {
            return;
        }
        //カメラ番号を1上げる
        _cameraNo += 1;
        //カメラ番号が4以上になったら
        if (_cameraNo > MAX_CAMERA_NO)
        {
            //カメラ番号を0にする
            _cameraNo = 0;
        }
        //カメラの切り替え
        cameraManager.GetComponent<CameraManager>().SwitchCamera();
    }
}
