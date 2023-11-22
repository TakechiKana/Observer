using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTypeManager : MonoBehaviour
{
    [Header("異常現象のへや")]
    public Phenomenon.Rooms room = default;
    [Header("異常現象のオブジェクトタイプ")]
    public Phenomenon.ObjectType objectType = default;
    [Header("発生中か")]
    [SerializeField]
    private bool isOutbreak = false;
    [Header("危険度")]
    [SerializeField]
    private int _riskValue = 1;
    
    /// <summary>
    /// 異常現象の発生地(部屋)の取得
    /// </summary>
    /// <returns>部屋</returns>
    public Phenomenon.Rooms GetRooms()
    {
        return room;
    }
    /// <summary>
    /// 異常現象のオブジェクトタイプの取得
    /// </summary>
    /// <returns></returns>
    public Phenomenon.ObjectType GetObjectType()
    {
        return objectType;
    }
    /// <summary>
    /// 危険度の取得
    /// </summary>
    /// <returns>危険度</returns>
    public int GetRiskValue()
    {
        return _riskValue;
    }
    /// <summary>
    /// 異常現象発生中か取得
    /// </summary>
    /// <returns></returns>
    public bool GetIsOutbreak()
    {
        return isOutbreak;
    }
    /// <summary>
    /// 異常現象発生フラグを立てる
    /// </summary>
    public void SetIsOutbreakOn()
    {
        isOutbreak = true;
    }
    /// <summary>
    /// 異常現象発生フラグを消す
    /// </summary>
    public void SetIsOutbreakOff()
    {
        isOutbreak = false;
    }
}
