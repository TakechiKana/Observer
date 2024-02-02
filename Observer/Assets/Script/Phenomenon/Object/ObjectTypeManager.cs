using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTypeManager : MonoBehaviour
{
    [Header("�ُ팻�ۂ̂ւ�")]
    public Phenomenon.Rooms room = default;
    [Header("�ُ팻�ۂ̃I�u�W�F�N�g�^�C�v")]
    public Phenomenon.ObjectType objectType = default;
    [Header("��������")]
    [SerializeField]
    private bool isOutbreak = false;
    [Header("�댯�x")]
    [SerializeField]
    private int _riskValue = 1;
    //�ُ팻�ۃ��X�g���A�^�b�`���ꂽ�Q�[���I�u�W�F�N�g
    private GameObject _phenomenonList = default;


    private void Start()
    {
        //PhenomenonObjectsManager�I�u�W�F�N�g������
        _phenomenonList = GameObject.Find("PhenomenonObjectsManager");
        //�ُ팻�ې����p�̃��X�g�ɒǉ�
        _phenomenonList.GetComponent<PhenomenonLists>().AddAbleToCreateList(this.gameObject);
        //�J�����I�u�W�F�N�g�̂Ƃ�
        if (objectType == Phenomenon.ObjectType.Camera)
        {
            //CameraMove�R���|�[�l���g��ǉ�����
            this.gameObject.AddComponent<CameraMove>();
        }
        //Move�X�N���v�g���A�^�b�`����I�u�W�F�N�g�̂Ƃ�
        if (GetAttachmentMoveScriptObject())
        {
            //Move�R���|�[�l���g��ǉ�����
            this.gameObject.AddComponent<MovementObject>();
        }
        //������I�u�W�F�N�g�̂Ƃ�(Vanish,Light)
        if ((objectType == Phenomenon.ObjectType.Vanish)
            || (objectType == Phenomenon.ObjectType.Light))
        {
            //�R���|�[�l���g��ǉ�����
            this.gameObject.AddComponent<Vanish>();
        }
        //��A�N�e�B�u�ɂ���I�u�W�F�N�g�̎�
        if (GetHiddenObject())
        {
            //Add�R���|�[�l���g��ǉ�����
            this.gameObject.AddComponent<Add>();
            //�J������Add�R���|�[�l���g��j������
            if(objectType == Phenomenon.ObjectType.Camera)
            {
                Destroy(GetComponent<Add>());
            }
            //��A�N�e�B�u�ɂ���
            this.gameObject.SetActive(false);
        }
    }
    /// <summary>
    /// Move�X�N���v�g���A�^�b�`����I�u�W�F�N�g
    /// </summary>
    /// <returns></returns>
    bool GetAttachmentMoveScriptObject()
    {
        //Move,Door,Camera
        return objectType == Phenomenon.ObjectType.Move || objectType == Phenomenon.ObjectType.Door;
    }

    bool GetHiddenObject()
    {
        return objectType == Phenomenon.ObjectType.AddObject || 
            objectType == Phenomenon.ObjectType.Blood || 
            objectType == Phenomenon.ObjectType.Camera || 
            objectType == Phenomenon.ObjectType.Ghost;
    }

    /// <summary>
    /// �ُ팻�ۂ̔����n(����)�̎擾
    /// </summary>
    /// <returns>����</returns>
    public Phenomenon.Rooms GetRooms()
    {
        return room;
    }
    /// <summary>
    /// �ُ팻�ۂ̃I�u�W�F�N�g�^�C�v�̎擾
    /// </summary>
    /// <returns></returns>
    public Phenomenon.ObjectType GetObjectType()
    {
        return objectType;
    }
    /// <summary>
    /// �댯�x�̎擾
    /// </summary>
    /// <returns>�댯�x</returns>
    public int GetRiskValue()
    {
        return _riskValue;
    }
    /// <summary>
    /// �ُ팻�۔��������擾
    /// </summary>
    /// <returns></returns>
    public bool GetIsOutbreak()
    {
        return isOutbreak;
    }
    /// <summary>
    /// �ُ팻�۔����t���O�𗧂Ă�
    /// </summary>
    public void SetIsOutbreakOn()
    {
        isOutbreak = true;
    }
    /// <summary>
    /// �ُ팻�۔����t���O������
    /// </summary>
    public void SetIsOutbreakOff()
    {
        isOutbreak = false;
    }
}
