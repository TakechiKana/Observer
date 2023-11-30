using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "CreateObject")]
public class Phenomenon : ScriptableObject
{
    /// <summary>
    /// �����^�C�v
    /// </summary>
    public enum Rooms
    {
        Default,
        Camera1,    
        Camera2,    
        Camera3,    
        Camera4,    
        Camera5     
    }
    /// <summary>
    /// �I�u�W�F�N�g�^�C�v(�ԈႢ�̎��)
    /// </summary>
    public enum ObjectType
    { 
        Default,            //Default
        Light,              //���C�g�̕ω�
        AddObject,          //�ǉ��I�u�W�F�N�g
        Vanish,             //�����I�u�W�F�N�g
        Move,               //�I�u�W�F�N�g�̈ړ�
        Door,               //�h�A�̊J��
        Image,              //�摜�ω�
        Ghost               //����
    }

    //�����^�C�v
    private Rooms _room = default;
    //�I�u�W�F�N�g�^�C�v
    private ObjectType _objectType = default;

    /// <summary>
    /// �����^�C�v�̎擾
    /// </summary>
    /// <returns>�����^�C�v</returns>
    public Rooms GetRooms()
    {
        return _room;
    }
    /// <summary>
    /// �I�u�W�F�N�g�^�C�v�̎擾
    /// </summary>
    /// <returns>�I�u�W�F�N�g�^�C�v</returns>
    public ObjectType GetObjectType()
    {
        return _objectType;
    }
}
