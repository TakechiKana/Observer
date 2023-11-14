using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhenomenonLists : MonoBehaviour
{
    //�����\�ُ팻��list
    private List<GameObject> ableToCreateList = new List<GameObject>();
    //������ُ팻��list
    private List<GameObject> alreadyCreateList = new List<GameObject>();
    //�����p�^�C�}�[
    [SerializeField] private float timer = 15.0f;
    //�I�u�W�F�N�g�J�E���g�p�ϐ�
    //�S�̐�
    private int allPhenomenonCount = 0;


    /// <summary>
    /// ����������
    /// </summary>
    void Start()
    {
        //�ُ팻�ې����p�̃��X�g�쐬
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //list�ɃQ�[���I�u�W�F�N�g���i�[���Ă���
            ableToCreateList.Add(this.transform.GetChild(i).gameObject);
        }
        //�S�̐��i�[
        allPhenomenonCount = ableToCreateList.Count;
    }


    /// <summary>
    /// �X�V����
    /// </summary>
    private void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) || timer < 0)
        {

            //�ُ팻�۔���
            MakePhenomenon();
            //�^�C�}�[�Đݒ�
            timer = 10.0f;
            //�f�o�b�O
            //DebugMethod();
        }
        
    }


    /// <summary>
    /// �ʏ펞�A�A�N�e�B�u�ȃI�u�W�F�N�g�����肷��
    /// </summary>
    /// <returns></returns>
    private bool JudgeDoActiveObject(GameObject obj)
    {
        //�I�u�W�F�N�g�^�C�v���i�[����B
        Phenomenon.ObjectType phenoType = obj.GetComponent<ObjectTypeManager>().GetObjectType();
        //�I�u�W�F�N�g�^�C�v���A�ʏ펞�̓A�N�e�B�u�ł���I�u�W�F�N�g�������ꍇ
        //�����A���C�g
        if(phenoType == Phenomenon.ObjectType.DisappearObject
            || phenoType == Phenomenon.ObjectType.Light)
        {
            //����Ԃ�
            return true;
        }
        //����Ԃ�
        return false;
    }
    
    
    /// <summary>
    /// �ʏ펞�A��A�N�e�B�u�ȃI�u�W�F�N�g�����肷��
    /// </summary>
    /// <returns></returns>
    private bool JudgeDoInactiveObject(GameObject obj)
    {
        //�I�u�W�F�N�g�^�C�v���i�[����B
        Phenomenon.ObjectType phenoType = obj.GetComponent<ObjectTypeManager>().GetObjectType();
        //�I�u�W�F�N�g�^�C�v���A�ʏ펞��A�N�e�B�u�ł���I�u�W�F�N�g�������ꍇ
        //�����A���C�g
        if(phenoType == Phenomenon.ObjectType.AddObject
            || phenoType == Phenomenon.ObjectType.Light)
        {
            //����Ԃ�
            return true;
        }
        //����Ԃ�
        return false;
    }


    /// <summary>
    /// �ُ팻�ۂ𔭐�������
    /// </summary>
    private void MakePhenomenon()
    {
        ///
        ///�f�o�b�O
        ///
        if(ableToCreateList.Count<=0)
        {
            Debug.Log("0Dayo");
            return;
        }
        ///


        //�����̐���
        int rand = Random.Range(0, ableToCreateList.Count);

        ///�f�o�b�O
        Debug.Log(ableToCreateList[rand]);

        //�ϐ��ɃI�u�W�F�N�g���i�[����
        GameObject gameObj = ableToCreateList[rand];
        //�����ς݌��ۂ����X�g������
        alreadyCreateList.Add(ableToCreateList[rand]);
        //���������ۃ��X�g����폜����
        ableToCreateList.RemoveAt(rand);
        //�I�u�W�F�N�g����A�N�e�B�u�̏ꍇ
        if(!gameObj.activeSelf)
        {
            //�A�N�e�B�u�ɂ���
            gameObj.SetActive(true);
            //�����t���O�̏���
            gameObj.gameObject.GetComponent<ObjectTypeManager>().SetIsOutbreakOn();
            return;
        }
        //�I�u�W�F�N�g���A�N�e�B�u�ŁA��A�N�e�B�u�Ώۂ̏ꍇ
        if (JudgeDoActiveObject(gameObj))
        {
            //��A�N�e�B�u�ɂ���
            gameObj.SetActive(false);
            return;
        }
        //���۔����t���O�𐳂ɂ���
        gameObj.GetComponent<ObjectTypeManager>().SetIsOutbreakOn();
        return;
    }


    /// <summary>
    /// �񍐃I�u�W�F�N�g�����݂��邩�̔���
    /// </summary>
    /// <param name="room">������������</param>
    /// <param name="objectType">�ُ팻�ۂ̃I�u�W�F�N�g�^�C�v</param>
    /// <returns></returns>
    public void JudgeReport(Phenomenon.Rooms room,Phenomenon.ObjectType objectType)
    {
        //�����ςُ݂̈팻�ۃ��X�g������
        for(int i = 0;i < alreadyCreateList.Count;i++)
        {
            //����room�ƈ�v������
            if(alreadyCreateList[i].GetComponent<ObjectTypeManager>().GetRooms() == room)
            {
                //���A����objectType�ƈ�v������
                if(alreadyCreateList[i].GetComponent<ObjectTypeManager>().GetObjectType() == objectType)
                {
                    //���ۏC������
                    FixPhenomenon(alreadyCreateList[i]);
                    //���������X�g�ɒǉ�
                    ableToCreateList.Add(alreadyCreateList[i]);
                    //���������X�g����폜
                    alreadyCreateList.RemoveAt(i);

                    ///�f�o�b�O
                    Debug.Log("�񍐐���");
                    return;
                }
            }
        }
        ///�f�o�b�O
        Debug.Log("�񍐎��s");
        
        //��v����I�u�W�F�N�g������������
        return;

    }


    /// <summary>
    /// �ُ팻�ۂ𔭐�������
    /// </summary>
    private void FixPhenomenon(GameObject gameObj)
    {
        //�I�u�W�F�N�g����A�N�e�B�u�̏ꍇ
        if (!gameObj.activeSelf)
        {
            //�A�N�e�B�u�ɂ���
            gameObj.SetActive(true);
            //�����t���O�̏���
            gameObj.gameObject.GetComponent<ObjectTypeManager>().SetIsOutbreakOff();
            return;
        }
        //�I�u�W�F�N�g���A�N�e�B�u�ŁA��A�N�e�B�u�Ώۂ̏ꍇ
        if (JudgeDoInactiveObject(gameObj))
        {
            //��A�N�e�B�u�ɂ���
            gameObj.SetActive(false);
            return;
        }
        //���۔����t���O�𐳂ɂ���
        gameObj.GetComponent<ObjectTypeManager>().SetIsOutbreakOff();
        return;
    }

    /// <summary>
    /// �f�o�b�O�p�֐�
    /// </summary>
    void DebugMethod()
    {
        Debug.Log(ableToCreateList.Count);
        Debug.Log(alreadyCreateList.Count);
        Debug.Log(allPhenomenonCount);
    }
}
