using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateList : MonoBehaviour
{
    //�ُ팻�ۃ��X�g���A�^�b�`���ꂽ�Q�[���I�u�W�F�N�g
    private GameObject _phenomenonList = default;
    // Start is called before the first frame update
    void Start()
    {
        _phenomenonList = GameObject.Find("PhenomenonObjectsManager");
        //�ُ팻�ې����p�̃��X�g�쐬
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //list�ɃQ�[���I�u�W�F�N�g���i�[���Ă���
            _phenomenonList.GetComponent<PhenomenonLists>().AddAbleToCreateList(this.transform.GetChild(i).gameObject);
        }

    }
}
