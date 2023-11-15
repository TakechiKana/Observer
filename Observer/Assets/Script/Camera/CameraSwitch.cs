using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    //�J�����}�l�[�W���[
    private GameObject cameraManager = default;
    //�J�����ԍ�
    private int _cameraNo = default;
    //�J�����ԍ��̏��
    private const int MAX_CAMERA_NO = 4;
    void Start()
    {
        //�J�����}�l�[�W���[�̎擾
        cameraManager = GameObject.Find("CameraManager");
    }
    /// <summary>
    /// ���{�^�����N���b�N���ꂽ��
    /// </summary>
    public void ClickButtonL()
    {
        if(cameraManager.GetComponent<CameraManager>().GetSwitchCameraFlag())
        {
            return;
        }
        //�J�����ԍ���1������
        _cameraNo -= 1;
        //�J�����ԍ���0�����ɂȂ�����
        if (_cameraNo < 0)
        {
            //�J�����ԍ���3�ɂ���
            _cameraNo = MAX_CAMERA_NO;
        }
        //�J�����̐؂�ւ�
        cameraManager.GetComponent<CameraManager>().SwitchCamera();
    }
    /// <summary>
    /// �E�{�^�����N���b�N���ꂽ��
    /// </summary>
    public void ClickButtonR()
    {
        if (cameraManager.GetComponent<CameraManager>().GetSwitchCameraFlag())
        {
            return;
        }
        //�J�����ԍ���1�グ��
        _cameraNo += 1;
        //�J�����ԍ���4�ȏ�ɂȂ�����
        if (_cameraNo > MAX_CAMERA_NO)
        {
            //�J�����ԍ���0�ɂ���
            _cameraNo = 0;
        }
        //�J�����̐؂�ւ�
        cameraManager.GetComponent<CameraManager>().SwitchCamera();
    }
}
