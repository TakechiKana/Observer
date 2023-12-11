using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhenomenonLists : MonoBehaviour
{
    //�����\�ُ팻��list
    private List<GameObject> _ableToCreateList = new List<GameObject>();
    //������ُ팻��list
    private List<GameObject> _alreadyCreateList = new List<GameObject>();
    //�ُ팻��list
    //private List<GameObject> _allAnomaryList = new List<GameObject>();
    [Header("�����p�^�C�}�[")]
    [SerializeField] private float _timer = 0f;
    //�^�C�}�[�Đݒ�萔
    private const float TIMER_MAX = 20.0f;
    //�^�C�}�[Start�萔
    private const float TIMER_START = 60.0f;
    //�v���C���[�X�e�[�g�A�Q�[���^�C�����A�^�b�`���ꂽ�I�u�W�F�N�g
    private GameObject _gameRule = default;
    //���|�[�g������
    static private int _reportedPhenomenonCount = default;
    //�ُ푍��
    static private int _alreadyPhenomenonCount = default;
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
        //���|�[�g�������̏�����
        _reportedPhenomenonCount = 0;
        //�ُ푍���̏�����
        _alreadyPhenomenonCount = 0;
        //�^�C�}�[�̏�����
        _timer = TIMER_START;
    }

    /// <summary>
    /// �����\�I�u�W�F�N�g���X�g�֒ǉ�
    /// </summary>
    /// <param name="gameObj">���X�g�ɒǉ�����GameObject</param>
    public void AddAbleToCreateList(GameObject gameObj)
    {
        //�ُ�list�֊i�[
        _ableToCreateList.Add(gameObj);

    }
    /// <summary>
    /// ���X�g�̃I�u�W�F�N�g���V���b�t������B
    /// </summary>
    public void ShuffleListObject()
    {
        //�ُ탊�X�g�̑����̊i�[
        //_alreadyPhenomenonCount = _ableToCreateList.Count;
        //�V���b�t��
        for (int i = 0; i < _ableToCreateList.Count - 1; i++)
        {
            var j = Random.Range(0, _ableToCreateList.Count); // �����_���ŗv�f�ԍ����P�I�ԁi�����_���v�f�j
            var temp = _ableToCreateList[i]; // ��ԍŌ�̗v�f�����m�ہitemp�j�ɂ����
            _ableToCreateList[i] = _ableToCreateList[j]; // �����_���v�f����ԍŌ�ɂ����
            _ableToCreateList[j] = temp; // ���m�ۂ��������_���v�f�ɏ㏑��
        }
    }

    static public int GetReportedPhenomenonCount()
    {
        return _reportedPhenomenonCount;
    }
    
    static public int GetAllPhenomenonCount()
    {
        return _alreadyPhenomenonCount;
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
        _timer -= Time.deltaTime;
        if (/*�f�o�b�O�p*/Input.GetKeyDown(KeyCode.Space) || _timer < 0)
        {
            //�ُ팻�۔���
            MakePhenomenon();
            //�^�C�}�[�Đݒ�
            _timer = TIMER_MAX;
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
        return phenoType == Phenomenon.ObjectType.Vanish ||
            phenoType == Phenomenon.ObjectType.Light;
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
        //�ǉ��A���C�g�A�S�[�X�g
        return phenoType == Phenomenon.ObjectType.AddObject ||
            phenoType == Phenomenon.ObjectType.Light ||
            phenoType == Phenomenon.ObjectType.Blood ||
            phenoType == Phenomenon.ObjectType.Ghost;
    }
    /// <summary>
    /// ���������Ŋ��ɂ��̌��ۂ��N���Ă��Ȃ������ʂ���
    /// </summary>
    /// <param name="gameObj">�ُ�I�u�W�F�N�g</param>
    private bool SearchSamePhenomenon(GameObject gameObj)
    {
        bool camera = false;
        bool type = false;
        for(int a = 0; a < _alreadyCreateList.Count; a++)
        {
            //����(�J����)���ׂ�
            if(gameObj.GetComponent<ObjectTypeManager>().GetRooms()
                == _alreadyCreateList[a].GetComponent<ObjectTypeManager>().GetRooms())
            {
                camera = true;
            }
            //�I�u�W�F�N�g�^�C�v���ׂ�
            if(gameObj.GetComponent<ObjectTypeManager>().GetObjectType()
                == _alreadyCreateList[a].GetComponent<ObjectTypeManager>().GetObjectType())
            {
                type = true;
            }
            //���������ł����
            if(camera == true && type == true)
            {
                //true��Ԃ�
                return true;
            }
            //���Z�b�g
            camera = false;
            type = false;
        }
        //���Ă͂܂���̂��Ȃ����false��Ԃ�
        return false;
    }


    /// <summary>
    /// �ُ팻�ۂ𔭐�������
    /// </summary>
    private void MakePhenomenon()
    {
        //�����p
        bool flag = default;
        //�����p
        int rand = default;

        do
        {
            //���������œ����^�C�v�̌��ۂ��N���Ă��Ȃ�����������
            flag = SearchSamePhenomenon(_ableToCreateList[0]);
            //�������̂���������
            if (flag)
            {
                Debug.Log("��蒼��");
                //�I�u�W�F�N�g���Ō���Ɋi�[
                _ableToCreateList.Add(_ableToCreateList[0]);
                //�擪�I�u�W�F�N�g���폜����B
                _ableToCreateList.RemoveAt(0);
            }
        }
        //�������̂�����΂�蒼��
        while (flag);

        //�ϐ��ɃI�u�W�F�N�g���i�[����
        GameObject gameObj = _ableToCreateList[0];
        //�ُ킪�����Ă���J�����̕����Ŕ���������
        if ((int)gameObj.GetComponent<ObjectTypeManager>().GetRooms() 
            == _cameraManager.GetComponent<CameraManager>().GetCameraNo())
        {
            //�J�����ؑփt���O��ݒ肵�ăm�C�Y�𔭐�������
            _cameraManager.GetComponent<CameraManager>().SetCameraNoiseFlag();
        }


        //�v���C���[�̊댯�x��ݒ�(���Z)����B
        _gameRule.GetComponent<PlayerRiskState>().SetPlayerRiskPoint(gameObj.GetComponent<ObjectTypeManager>().GetRiskValue(),true);
        //���������ُ�̐��Ɋi�[����B
        _alreadyPhenomenonCount += 1;


        ///�f�o�b�O
        Debug.Log($"{_ableToCreateList[rand].GetComponent<ObjectTypeManager>().GetRooms()}," +
            $"{_ableToCreateList[rand].GetComponent<ObjectTypeManager>().GetObjectType()}");

        //�����ς݌��ۂ����X�g������
        _alreadyCreateList.Add(_ableToCreateList[rand]);
        //���������ۃ��X�g����폜����
        _ableToCreateList.RemoveAt(rand);

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
        for(int i = 0;i < _alreadyCreateList.Count;i++)
        {
            //����room�ƈ�v������
            if(_alreadyCreateList[i].GetComponent<ObjectTypeManager>().GetRooms() == room)
            {
                //���A����objectType�ƈ�v������
                if(_alreadyCreateList[i].GetComponent<ObjectTypeManager>().GetObjectType() == objectType)
                {
                    //���ۏC������
                    FixPhenomenon(_alreadyCreateList[i]);
                    //���������X�g�ɒǉ�
                    _ableToCreateList.Add(_alreadyCreateList[i]);
                    //���������X�g����폜
                    _alreadyCreateList.RemoveAt(i);
                    //���|�[�g������ʂ̕\��
                    _reportSuccessScreen.SetActive(true);
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
        //���|�[�g�����������Z����
        _reportedPhenomenonCount += 1;
        //�I�u�W�F�N�g����A�N�e�B�u�ŃJ�����łȂ��̏ꍇ
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
            //�����t���O�̏���
            gameObj.gameObject.GetComponent<ObjectTypeManager>().SetIsOutbreakOff();
            //��A�N�e�B�u�ɂ���
            gameObj.SetActive(false);
            return;
        }
        //���۔����t���O������
        gameObj.GetComponent<ObjectTypeManager>().SetIsOutbreakOff();
        return;
    }
}
