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
