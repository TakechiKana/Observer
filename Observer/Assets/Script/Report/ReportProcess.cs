using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportProcess : MonoBehaviour
{
    //���ۂ̃I�u�W�F�N�g�^�C�v
    private Phenomenon.ObjectType objectType = default;
    //���ۂ̕���
    private Phenomenon.Rooms room = 0;
    [Header("PhenomenonLists.cs���A�^�b�`���ꂽ�I�u�W�F�N�g")]
    [SerializeField] GameObject phenomenonList = default;

    public void Report()
    {
        //�ǂ��炩�Е��ł���ɂȂ��Ă���Ƃ�
        if(objectType == default || room == default)
        {
            //�񍐂ł��Ȃ��ꍇ�A����܂łɊi�[���������Ǝ�ނ̓N���A�ɂ���B
            objectType = default;
            room = default;
            
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

        //���|�[�g�������������肷��
        phenomenonList.GetComponent<PhenomenonLists>().JudgeReport(room,objectType);
        objectType = 0;
        room = 0;
    }


    /// <summary>
    /// �񍐂������I�u�W�F�N�g�^�C�v��ݒ肷��
    /// </summary>
    /// <param name="objType">���ۂ̃I�u�W�F�N�g�^�C�v</param>
    public void SetReportObjectType(Phenomenon.ObjectType objType)
    {
        objectType = objType;

        //�f�o�b�O
        Debug.Log("Type Set");
        Debug.Log(objectType);
    }


    /// <summary>
    /// �񍐂�����������ݒ肷��
    /// </summary>
    /// <param name="_room">���ۂ̕���</param>
    public void SetReportRoom(Phenomenon.Rooms _room)
    {
        room = _room;

        //�f�o�b�O
        Debug.Log("Room Set");
        Debug.Log(room);
    }
}
