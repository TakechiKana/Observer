using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PhenomenonDataBase", menuName = "CreatePhenomenonDataBase")]
public class PhenomenonDataBase : ScriptableObject
{
    public List<Object> _phenomenonLists = new List<Object>();
    //�A�C�e�����X�g��Ԃ�
    public List<Object> GetItemLists()
    {
        return _phenomenonLists;
    }
}
