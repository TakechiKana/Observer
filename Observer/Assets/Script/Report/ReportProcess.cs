using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportProcess : MonoBehaviour
{
    //���ۂ̃I�u�W�F�N�g�^�C�v
    private Phenomenon.ObjectType objectType = 0;
    //���ۂ̕���
    private Phenomenon.Rooms room = 0;
    [Header("PhenomenonLists.cs���A�^�b�`���ꂽ�I�u�W�F�N�g")]
    [SerializeField] GameObject phenomenonList = default;
    [Header("�G���[���b�Z�[�W�I�u�W�F�N�g")]
    [SerializeField] GameObject _errorMessageObj = default;
    //�J�����Z���N�g�I�u�W�F�N�g
    private GameObject selectedCamera = default;
    //�^�C�v�Z���N�g�I�u�W�F�N�g
    private GameObject selectedType = default;

    private void Start()
    {
        //�J�����Z���N�g�I�u�W�F�N�g����������
        selectedCamera = GameObject.Find("SelectedCamera");
        selectedCamera.SetActive(false);
        //�Z���N�g�I�u�W�F�N�g����������
        selectedType = GameObject.Find("SelectedType");
        selectedType.SetActive(false);
    }

    public void ReportSend()
    {
        //�ǂ��炩�Е��ł���ɂȂ��Ă���Ƃ�
        if(objectType == default || room == default)
        {
            //�񍐂ł��Ȃ��ꍇ�A�G���[���b�Z�[�W��\������B
            _errorMessageObj.SetActive(true);
            
            //�f�o�b�O
            Debug.Log("Report Miss");
            Debug.Log(objectType);
            Debug.Log(room);


            return;
        }
        //�f�o�b�O
        Debug.Log("Report Correct");
        Debug.Log(objectType);
        Debug.Log(room);

        //�G���[���b�Z�[�W���\������Ă�����
        if(_errorMessageObj.activeSelf)
        {
            //��\��
            _errorMessageObj.SetActive(false);
        }

        //���|�[�g�������������肷��
        phenomenonList.GetComponent<PhenomenonLists>().JudgeReport(room,objectType);
        //���e�����Z�b�g
        ReportCansel();
    }


    /// <summary>
    /// ���|�[�g���L�����Z������
    /// </summary>
    /// <param name="objType">���ۂ̃I�u�W�F�N�g�^�C�v</param>
    public void ReportCansel()
    {
        //���Z�b�g����
        objectType = default;
        room = default;
        //�I�𒆃G�t�F�N�g���\��
        selectedCamera.SetActive(false);
        selectedType.SetActive(false);
    }
    /// <summary>
    /// �񍐂������I�u�W�F�N�g�^�C�v��ݒ肷��
    /// </summary>
    /// <param name="objType">���ۂ̃I�u�W�F�N�g�^�C�v</param>
    public void SetReportObjectType(Phenomenon.ObjectType objType,Vector3 pos)
    {
        objectType = objType;
        //�I�𒆃G�t�F�N�g��\��
        selectedType.transform.position = pos;
        selectedType.SetActive(true);

        //�f�o�b�O
        Debug.Log("Type Set");
        Debug.Log(objectType);
    }


    /// <summary>
    /// �񍐂�����������ݒ肷��
    /// </summary>
    /// <param name="_room">���ۂ̕���</param>
    public void SetReportRoom(Phenomenon.Rooms _room,Vector3 pos)
    {
        room = _room;
        //�I�𒆃G�t�F�N�g��\��
        selectedCamera.transform.position = pos;
        selectedCamera.SetActive(true);
        //�f�o�b�O
        Debug.Log("Room Set");
        Debug.Log(room);
    }
}
