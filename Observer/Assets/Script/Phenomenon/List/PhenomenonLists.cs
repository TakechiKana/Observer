using System.Collections.Generic;
using UnityEngine;

public class PhenomenonLists : MonoBehaviour
{
    //�����\�ُ팻��list
    private List<GameObject> _ableToCreateList = new List<GameObject>();
    //������ُ팻��list
    private List<GameObject> _alreadyCreateList = new List<GameObject>();
    //������ُ팻��list
    private List<GameObject> _repotedObjectsList = new List<GameObject>();
    //�ُ팻��list
    static private List<string> _stillAnomalyNameList = new List<string>();
    //�v���C���[�X�e�[�g�A�Q�[���^�C�����A�^�b�`���ꂽ�I�u�W�F�N�g
    private GameObject _gameManager = default;
    //���|�[�g������
    static private int _reportedPhenomenonCount = default;
    //���������ُ푍��
    static private int _alreadyPhenomenonCount = default;

    //�J�����}�l�[�W���[
    private GameObject _cameraManager = default;
    [Header("���|�[�g��e�L�X�g")]
    [SerializeField] GameObject _afterReportText = default;
    [Header("���|�[�g�������")]
    [SerializeField] GameObject _reportSuccessScreen = default;

    //�f�o�b�O�t���O
    private bool _isDebug = false;
    //�f�o�b�O�t���O
    //private bool _isComplete = false;
    //�t���O�}�l�[�W��
    private GameObject _flagManager = default;

    /// <summary>
    /// ����������
    /// </summary>
    void Start()
    {
        //�����҂��Ă���t���O�}�l�W������������
        Invoke("FindFlagObject", 0.09f);

        //�Q�[�����[���I�u�W�F�N�g�̎擾
        _gameManager = GameObject.Find("GameManager");
        //�J�����}�l�[�W���[�I�u�W�F�N�g�̎擾
        _cameraManager = GameObject.Find("CameraManager");

        //���|�[�g�������̏�����
        _reportedPhenomenonCount = 0;
        //�ُ푍���̏�����
        _alreadyPhenomenonCount = 0;

        //�z��̏�����
        _repotedObjectsList.Clear();


        //�����҂��Ă��烊�X�g���V���b�t������
        Invoke("ShuffleListObject", 2.0f);
    }
    /// <summary>
    /// �t���O�}�l�[�W���[�̌���
    /// </summary>
    void FindFlagObject()
    {
        //�t���O�}�l�W�����݂���
        _flagManager = GameObject.FindGameObjectWithTag("FlagManager");
        //�������Ȃ�������
        if (_flagManager == null)
        {
            //�����I��
            return;
        }
        //�f�o�b�O�t���O���擾
        _isDebug = _flagManager.GetComponent<FlagManager>().GetIsDebug();
        //�R���v���[�g�t���O���擾
        //_isComplete = _flagManager.GetComponent<FlagManager>().GetCompleteMode();
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
        if (!_flagManager.GetComponent<FlagManager>().GetGameClear() && (_stillAnomalyNameList.Count == 0))
        {
            for (int i = 0; i < _ableToCreateList.Count; i++)
            {
                _stillAnomalyNameList.Add(_ableToCreateList[i].name);
            }
        }
        //�V���b�t��
        for (int i = 0; i < _ableToCreateList.Count - 1; i++)
        {
            var j = Random.Range(0, _ableToCreateList.Count); // �����_���ŗv�f�ԍ����P�I�ԁi�����_���v�f�j
            var temp = _ableToCreateList[i]; // ��ԍŌ�̗v�f�����m�ہitemp�j�ɂ����
            _ableToCreateList[i] = _ableToCreateList[j]; // �����_���v�f����ԍŌ�ɂ����
            _ableToCreateList[j] = temp; // ���m�ۂ��������_���v�f�ɏ㏑��
        }

        //�ُ푍��
        Debug.Log($"�����\���X�g{_ableToCreateList.Count}");
        Debug.Log($"���������X�g{ _stillAnomalyNameList.Count}");
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    private void Update()
    {


    }

    /// <summary>
    /// ���������Ŋ��ɂ��̌��ۂ��N���Ă��Ȃ������ʂ���
    /// </summary>
    /// <param name="gameObj">�ُ�I�u�W�F�N�g</param>
    private bool SearchSamePhenomenon(GameObject gameObj)
    {
        bool camera = false;
        bool type = false;
        for (int a = 0; a < _alreadyCreateList.Count; a++)
        {
            //����(�J����)���ׂ�
            if (gameObj.GetComponent<ObjectTypeManager>().GetRooms()
                == _alreadyCreateList[a].GetComponent<ObjectTypeManager>().GetRooms())
            {
                camera = true;
            }
            //�I�u�W�F�N�g�^�C�v���ׂ�
            if (gameObj.GetComponent<ObjectTypeManager>().GetObjectType()
                == _alreadyCreateList[a].GetComponent<ObjectTypeManager>().GetObjectType())
            {
                type = true;
            }
            //���������ł����
            if (camera == true && type == true)
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
    public void MakePhenomenon()
    {
        //�댯�t���O�������Ă���Ƃ��͏������Ȃ�
        if (_gameManager.GetComponent<PlayerRiskState>().GetIsDanger())

        {
            //�������Ȃ�
            return;
        }
        if((_ableToCreateList.Count == 0))
        {
            return;
        }
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
                //�I�u�W�F�N�g���Ō���Ɋi�[
                _ableToCreateList.Add(_ableToCreateList[0]);
                //�擪�I�u�W�F�N�g���폜����B
                _ableToCreateList.RemoveAt(0);
            }
        }
        //�������̂�����΂�蒼��
        while (flag);

        //�ϐ��ɔ���������ٕσI�u�W�F�N�g���i�[����
        GameObject gameObj = _ableToCreateList[0];
        //�v���C���[�̊댯�x��ݒ�(���Z)����B
        _gameManager.GetComponent<PlayerRiskState>().SetPlayerRiskPoint(gameObj.GetComponent<ObjectTypeManager>().GetRiskValue(), true);
        //���������ُ�̐������Z����B
        _alreadyPhenomenonCount += 1;

        //�ُ킪�����Ă���J�����̕����Ŕ���������
        if ((int)gameObj.GetComponent<ObjectTypeManager>().GetRooms()
            == _cameraManager.GetComponent<CameraManager>().GetCameraNo())
        {
            //�J�����ؑփt���O��ݒ肵�ăm�C�Y�𔭐�������
            _cameraManager.GetComponent<CameraManager>().SetCameraNoiseFlag();
        }

        ///�f�o�b�O
        Debug.Log($"{_ableToCreateList[rand].GetComponent<ObjectTypeManager>().GetRooms()}," +
            $"{_ableToCreateList[rand].GetComponent<ObjectTypeManager>().GetObjectType()}");


        //�����ς݈ٕς����X�g�ɒǉ�����
        _alreadyCreateList.Add(_ableToCreateList[rand]);
        //�������ٕσ��X�g����폜����
        _ableToCreateList.RemoveAt(rand);

        //�I�u�W�F�N�g����A�N�e�B�u�̏ꍇ
        if (!gameObj.activeSelf)
        {
            //�A�N�e�B�u�ɂ���
            gameObj.SetActive(true);
            //�����t���O�̏���
            gameObj.gameObject.GetComponent<ObjectTypeManager>().SetIsOutbreakOn();
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
    public void JudgeReport(Phenomenon.Rooms room, Phenomenon.ObjectType objectType)
    {
        //�����ςُ݂̈팻�ۃ��X�g������
        for (int i = 0; i < _alreadyCreateList.Count; i++)
        {
            //�ٕς̎�ނ��������
            if (_alreadyCreateList[i].GetComponent<ObjectTypeManager>().GetObjectType() != objectType)
            {
                //���̃��[�v��
                continue;
            }
            if (_alreadyCreateList[i].GetComponent<ObjectTypeManager>().GetRooms() != room)
            {
                //���̃��[�v��
                continue;
            }
            //���ۏC������
            FixPhenomenon(_alreadyCreateList[i]);
            //�����\�I�u�W�F�N�g�ɒǉ�����
            _ableToCreateList.Add(_alreadyCreateList[i]);
            //���������X�g����폜
            _alreadyCreateList.RemoveAt(i);
            
            //���|�[�g������ʂ̕\��
            _reportSuccessScreen.SetActive(true);
            return;
        }
        //���|�[�g���s�e�L�X�g�̕\��
        _afterReportText.GetComponent<AfterRepotText>().SetDisplayMessage(false);
        _afterReportText.SetActive(true);
    }

    /// <summary>
    /// �ُ팻�ۂ��C������
    /// </summary>
    private void FixPhenomenon(GameObject gameObj)
    {
        //�v���C���[�̊댯�x��ݒ�(���Z)����B
        _gameManager.GetComponent<PlayerRiskState>().SetPlayerRiskPoint(gameObj.GetComponent<ObjectTypeManager>().GetRiskValue(), false);
        //���|�[�g�����������Z����
        _reportedPhenomenonCount += 1;
        //�񍐍σI�u�W�F�N�g�ɒǉ�����
        _repotedObjectsList.Add(gameObj);

        //�I�u�W�F�N�g����A�N�e�B�u�̏ꍇ
        if (!gameObj.activeSelf)
        {
            //�A�N�e�B�u�ɂ���
            gameObj.SetActive(true);
            //�����t���O�̏���
            gameObj.gameObject.GetComponent<ObjectTypeManager>().SetIsOutbreakOff();
            return;
        }
        //���۔����t���O������
        gameObj.GetComponent<ObjectTypeManager>().SetIsOutbreakOff();
        //�C����ɔ��肵�Đ���������
        if (GetIsAllReported())
        {
            //�Q�[���N���A
            _gameManager.GetComponent<GameTime>().SetGameClearFlag();
        }

    }

    /// <summary>
    /// ���|�[�g�ψٕς̐��ʎ擾
    /// </summary>
    /// <returns></returns>
    static public int GetReportedPhenomenonCount()
    {
        return _reportedPhenomenonCount;
    }

    /// <summary>
    /// ���������ٕς̑���
    /// </summary>
    /// <returns></returns>
    static public int GetAlreadyPhenomenonCount()
    {
        return _alreadyPhenomenonCount;
    }
    ///// <summary>
    ///// �������ٕ̈ς̐�
    ///// </summary>
    ///// <returns></returns>
    static public int GetStillReportedAnomalyCount()
    {
        return _stillAnomalyNameList.Count;
    }
    /// <summary>
    /// �S�Ăٕ̈ς�񍐂������擾����
    /// </summary>
    /// <returns></returns>
    public bool GetIsAllReported()
    {
        //�����\�I�u�W�F�N�g�Ɣ������I�u�W�F�N�g���Ƃ���0�Ȃ�
        if ((_ableToCreateList.Count == 0) && (_alreadyCreateList.Count == 0))
        {
            //��
            return true;
        }
        //��
        return false;
    }
    /// <summary>
    /// �S�Ăٕ̈ς�񍐂������擾����
    /// </summary>
    /// <returns></returns>
    public void SearchAlreadyReportedObject()
    {
        //�񍐍σI�u�W�F�N�g��0�̏ꍇ
        if(_repotedObjectsList.Count == 0)
        {
            //�������Ȃ�
            return;
        }
        //�������I�u�W�F�N�g��0�̎�
        if(_stillAnomalyNameList.Count == 0)
        {
            //�������Ȃ�
            return;
        }
        //
        for (int i = 0; i < _repotedObjectsList.Count; i++)
        {
            //�������I�u�W�F�N�g��0�ɂȂ�����
            if(_stillAnomalyNameList.Count == 0)
            {
                _stillAnomalyNameList.Clear();
                //���[�v�o��
                break;
            }

            int num = _stillAnomalyNameList.IndexOf(_repotedObjectsList[i].name);

            if(num == -1)
            {
                //���[�v��蒼��
                continue;
            }
            //���������X�g����v�f���폜
            _stillAnomalyNameList.RemoveAt(num);
            //Debug.Log($"���������X�g��������{_stillAnomalyNameList.Count}");

        }
    }
}