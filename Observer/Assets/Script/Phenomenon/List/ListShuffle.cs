using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListShuffle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //���X�g���V���b�t������B
        this.gameObject.GetComponent<PhenomenonLists>().ShuffleListObject();
    }
}
