using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //�������W
    private Vector3 startPos = default;
    //������]
    private Quaternion startRot = default;
    //�ړ�����W
    private Vector3 movePos = default;
    //�ړ���̉�]���
    private Quaternion moveRot = default;
    //�ړ��������̔���
    private bool isMove = false;

    // Start is called before the first frame update
    void Start()
    {
        //�������W��ݒ�
        startPos = this.transform.position;
        //������]��ݒ�
        startRot = this.transform.rotation;
        //�ړ�����W�p�Ɏq�̋�I�u�W�F�N�g�̍��W��ݒ�
        movePos = this.gameObject.transform.GetChild(0).position;
        //�ړ�����W�p�Ɏq�̋�I�u�W�F�N�g�̍��W��ݒ�
        moveRot = this.gameObject.transform.GetChild(0).rotation;
    }
    private void Update()
    {
        //���۔����t���O�����̎�
        if(!this.GetComponent<ObjectTypeManager>().GetIsOutbreak())
        {
            if(isMove)
            {
                //�ړ���t���O���I���ɂȂ��Ă��āA���۔����t���O��OFF�̂Ƃ�
                //�����ʒu,��]�ɖ߂�
                this.transform.position = startPos;
                this.transform.rotation = startRot;
                //�ړ��t���O������
                isMove = false;
            }
            return;
        }
        //���۔����t���O��ON�ł��ړ��ς̂Ƃ�
        if(isMove)
        {
            return;
        }
        //�ړ�������
        this.transform.position = movePos;
        this.transform.rotation = moveRot;
        //�ړ��t���O�𗧂Ă�
        isMove = true;
    }
}
