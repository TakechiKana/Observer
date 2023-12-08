using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //初期座標
    private Vector3 startPos = default;
    //初期回転
    private Quaternion startRot = default;
    //移動後座標
    private Vector3 movePos = default;
    //移動後の回転情報
    private Quaternion moveRot = default;
    //移動したかの判定
    private bool isMove = false;
    //カメラマネージャ
    private GameObject _cameraManager = default;

    // Start is called before the first frame update
    void Start()
    {
        //初期座標を設定
        startPos = this.transform.position;
        //初期回転を設定
        startRot = this.transform.rotation;
        //移動後座標用に子の空オブジェクトの座標を設定
        movePos = this.gameObject.transform.GetChild(0).position;
        //移動後座標用に子の空オブジェクトの座標を設定
        moveRot = this.gameObject.transform.GetChild(0).rotation;
        //カメラマネージャ
        _cameraManager = GameObject.Find("CameraManager");
    }
    private void Update()
    {
        //現象発生フラグが負の時
        if (!this.GetComponent<ObjectTypeManager>().GetIsOutbreak())
        {
            if (isMove)
            {
                //移動後フラグがオンになっていて、現象発生フラグがOFFのとき
                //初期位置,回転に戻す
                this.transform.position = startPos;
                this.transform.rotation = startRot;
                //移動フラグを消す
                isMove = false;
                //カメラの修正
                _cameraManager.GetComponent<CameraManager>().CameraUpdate();
                this.gameObject.SetActive(false);
            }
            return;
        }
        //現象発生フラグがONでも移動済のとき
        if (isMove)
        {
            return;
        }
        //移動させる
        this.transform.position = movePos;
        this.transform.rotation = moveRot;
        //カメラの修正
        _cameraManager.GetComponent<CameraManager>().CameraUpdate();
        //移動フラグを立てる
        isMove = true;
    }
}
