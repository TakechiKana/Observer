using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateList : MonoBehaviour
{
    //異常現象リストがアタッチされたゲームオブジェクト
    private GameObject _phenomenonList = default;
    // Start is called before the first frame update
    void Start()
    {
        _phenomenonList = GameObject.Find("PhenomenonObjectsManager");
        //異常現象生成用のリスト作成
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //listにゲームオブジェクトを格納していく
            _phenomenonList.GetComponent<PhenomenonLists>().AddAbleToCreateList(this.transform.GetChild(i).gameObject);
        }

    }
}
