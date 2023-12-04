using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhenomenonLists : MonoBehaviour
{
    //�����\�ُ팻��list
    private List<GameObject> ableToCreateList = new List<GameObject>();
    //������ُ팻��list
    private List<GameObject> alreadyCreateList = new List<GameObject>();
    [Header("�����p�^�C�}�[")]
    [SerializeField] private float timer = 15.0f;
    //�^�C�}�[�Đݒ�萔
    private const float TIMER_MAX = 10.0f;
    //�I�u�W�F�N�g�J�E���g�S�̐�
    private int allPhenomenonCount = 0;
    //�v���C���[�X�e�[�g�A�Q�[���^�C�����A�^�b�`���ꂽ�I�u�W�F�N�g
    private GameObject _gameRule = default;
    //�J�����}�l�[�W���[
    private GameObject _cameraManager = default;
    [Header("���|�[�g��e�L�X�g")]
    [SerializeField] GameObject _afterReportText = default;
    [Header("���|�[�g�������")]
    [SerializeField] GameObject _reportSuccessScreen = default;


    /// <summary>
    /// ����������
    /// </summary>
    void Start()
    {
        //�Q�[�����[���I�u�W�F�N�g�̎擾
        _gameRule = GameObject.Find("GameRule");
        //�J�����}�l�[�W���[�I�u�W�F�N�g�̎擾
        _cameraManager = GameObject.Find("CameraManager");
    }

    /// <summary>
    /// �����\�I�u�W�F�N�g���X�g�֒ǉ�
    /// </summary>
    /// <param name="gameObj">���X�g�ɒǉ�����GameObject</param>
    public void AddAbleToCreateList(GameObject gameObj)
    {
        ableToCreateList.Add(gameObj);
        allPhenomenonCount += 1;

    }


    /// <summary>
    /// �X�V����
    /// </summary>
    private void Update()
    {
        //�Q�[���^�C�����~�܂��Ă���Ƃ�
        if(!_gameRule.GetComponent<GameTime>().GetGameTimeFlag())
        {
            //�������Ȃ�
            return;
        }
        //�댯�t���O�������Ă���Ƃ��͏������Ȃ�
        if(_gameRule.GetComponent<PlayerRiskState>().GetIsDanger())
        {
            return;
        }
        //�ُ픭���p�^�C�}�[�̃J�E���g�_�E��
        timer -= Time.deltaTime;
        if (/*�f�o�b�O�p*/Input.GetKeyDown(KeyCode.Space) || timer < 0)
        {
            //�ُ팻�۔���
            MakePhenomenon();
            //�^�C�}�[�Đݒ�
            timer = TIMER_MAX;
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
        if(phenoType == Phenomenon.ObjectType.Vanish
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
        //�����̐���
        int rand = Random.Range(0, ableToCreateList.Count);


        //�ϐ��ɃI�u�W�F�N�g���i�[����
        GameObject gameObj = ableToCreateList[rand];
        //�ُ킪�����Ă���J�����̕����Ŕ���������
        if ((int)gameObj.GetComponent<ObjectTypeManager>().GetRooms() 
            == _cameraManager.GetComponent<CameraManager>().GetCamerNo())
        {
            //�J�����ؑփt���O��ݒ肵�ăm�C�Y�𔭐�������
            _cameraManager.GetComponent<CameraManager>().SetCameraSwitchFlag();
        }


        //�v���C���[�̊댯�x��ݒ�(���Z)����B
        _gameRule.GetComponent<PlayerRiskState>().SetPlayerRiskPoint(gameObj.GetComponent<ObjectTypeManager>().GetRiskValue(),true);

        ///�f�o�b�O
        Debug.Log($"{ableToCreateList[rand].GetComponent<ObjectTypeManager>().GetRooms()}," +
            $"{ableToCreateList[rand].GetComponent<ObjectTypeManager>().GetObjectType()}");

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
                    //���|�[�g������ʂ̕\��
                    _reportSuccessScreen.SetActive(true);
                    ///�f�o�b�O
                    //Debug.Log("�ʕ񐬌�");
                    return;
                }
            }
        }
        //���|�[�g���s�e�L�X�g�̕\��
        _afterReportText.GetComponent<AfterRepotText>().SetDisplayMessage(false);
        _afterReportText.SetActive(true);
        ///�f�o�b�O
        //Debug.Log("�ʕ񎸔s");
        
        //��v����I�u�W�F�N�g������������
        return;

    }

    /// <summary>
    /// �ُ팻�ۂ��C������
    /// </summary>
    private void FixPhenomenon(GameObject gameObj)
    {
        //�v���C���[�̊댯�x��ݒ�(���Z)����B
        _gameRule.GetComponent<PlayerRiskState>().SetPlayerRiskPoint(gameObj.GetComponent<ObjectTypeManager>().GetRiskValue(), false);
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
        //���۔����t���O������
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
