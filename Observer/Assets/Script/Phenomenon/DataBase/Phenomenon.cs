using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "CreateObject")]
public class Phenomenon : ScriptableObject
{
    /// <summary>
    /// 部屋タイプ
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
    /// オブジェクトタイプ(間違いの種類)
    /// </summary>
    public enum ObjectType
    { 
        Default,            //Default
        Light,              //ライトの変化
        AddObject,          //追加オブジェクト
        Vanish,             //消失オブジェクト
        Move,               //オブジェクトの移動
        Door,               //ドアの開閉
        Image,              //画像変化
        Ghost               //怪異
    }

    //部屋タイプ
    private Rooms _room = default;
    //オブジェクトタイプ
    private ObjectType _objectType = default;

    /// <summary>
    /// 部屋タイプの取得
    /// </summary>
    /// <returns>部屋タイプ</returns>
    public Rooms GetRooms()
    {
        return _room;
    }
    /// <summary>
    /// オブジェクトタイプの取得
    /// </summary>
    /// <returns>オブジェクトタイプ</returns>
    public ObjectType GetObjectType()
    {
        return _objectType;
    }
}
