using TMPro;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private GameObject mainCamera = default; //�J����1
    [SerializeField] private GameObject camera1 = default; //�J����2
    [SerializeField] private GameObject camera2 = default; //�J����2
    [SerializeField] private GameObject camera3 = default; //�J����3
    [SerializeField] private GameObject camera4 = default; //�J����4
    [SerializeField] private GameObject camera5 = default; //�J����5

    [SerializeField]
    [Header("�|�X�g�G�t�F�N�g�}�e���A��")]
    private Material _postProcessMat;                                                  //�|�X�g�G�t�F�N�g�}�e���A��
    private readonly int _noiseTimerID = Shader.PropertyToID("_NoiseTimer");    // �V�F�[�_�[�v���p�e�B��Reference��
    private bool _cameraSwitchFlag = false;                                      //�J�����ؑփt���O
    private const float CONST_NOISETIMER = 0.1f;                                //�m�C�Y�^�C�}�[�p�萔
    private float _noiseTimer = default;                                         //�m�C�Y�^�C�}�[�p�ϐ�
    [SerializeField][Header("�J�����ԍ��e�L�X�g�I�u�W�F�N�g")]
    private TextMeshProUGUI _cameraNoText = default;                             //�J�����ԍ��̃e�L�X�g�I�u�W�F�N�g
    //�J�����ԍ�
    private int _cameraNo = 1;
    //�J�����ԍ��̏��
    private const int MAX_CAMERA_NO = 5;


    void Start()
    {

        //���C���J������L��������
        ActiveCamera1();

        //�m�C�Y�^�C�}�[�p�ϐ��ɒ萔��������
        _noiseTimer = CONST_NOISETIMER;
    }

    private void Update()
    {
        //�J�����ؑփt���O���I�t
        if (!_cameraSwitchFlag)
        {
            return;
        }

        CameraNoiseProcess();
    }

    //�֐��F�J����1��L����
    public void ActiveCamera1()
    {
        mainCamera.transform.position = camera1.transform.position;
        mainCamera.transform.rotation = camera1.transform.rotation;

        _cameraNoText.text = "Camera1";
    }

    //�֐��F�J����2��L����
    public void ActiveCamera2()
    {
        mainCamera.transform.position = camera2.transform.position;
        mainCamera.transform.rotation = camera2.transform.rotation;

        _cameraNoText.text = "Camera2";
    }

    //�֐��F�J����3��L����
    public void ActiveCamera3()
    {
        mainCamera.transform.position = camera3.transform.position;
        mainCamera.transform.rotation = camera3.transform.rotation;

        _cameraNoText.text = "Camera3";
    }
    //�֐��F�J����4��L����
    public void ActiveCamera4()
    {
        mainCamera.transform.position = camera4.transform.position;
        mainCamera.transform.rotation = camera4.transform.rotation;

        _cameraNoText.text = "Camera4";
    }
    //�֐��F�J����5��L����
    public void ActiveCamera5()
    {
        mainCamera.transform.position = camera5.transform.position;
        mainCamera.transform.rotation = camera5.transform.rotation;

        _cameraNoText.text = "Camera5";
    }

    public void SwitchCamera()
    {
        //�m�C�Y�𔭐�������
        _cameraSwitchFlag = true;

        switch (_cameraNo)
        {
            case 1:
                ActiveCamera1();
                break;
            case 2:
                ActiveCamera2();
                break;
            case 3:
                ActiveCamera3();
                break;
            case 4:
                ActiveCamera4();
                break;
            case 5:
                ActiveCamera5();
                break;
            default:
                Debug.Log("�������Ȃ��ԍ�");
                break;

        }
    }

    private bool GetSwitchCameraFlag()
    {
        return _cameraSwitchFlag;
    }

    public void ClickButtonL()
    {
        if (GetSwitchCameraFlag())
        {
            return;
        }
        //�J�����ԍ���1������
        _cameraNo -= 1;
        //�J�����ԍ���0�ȉ��ɂȂ�����
        if (_cameraNo <= 0)
        {
            //�J�����ԍ���3�ɂ���
            _cameraNo = MAX_CAMERA_NO;
        }
        //�J�����̐؂�ւ�
        SwitchCamera();
    }
    /// <summary>
    /// �E�{�^�����N���b�N���ꂽ��
    /// </summary>
    public void ClickButtonR()
    {
        if (GetSwitchCameraFlag())
        {
            return;
        }
        //�J�����ԍ���1�グ��
        _cameraNo += 1;
        //�J�����ԍ���5���傫���Ȃ�����
        if (_cameraNo > MAX_CAMERA_NO)
        {
            //�J�����ԍ���0�ɂ���
            _cameraNo = 1;
        }
        //�J�����̐؂�ւ�
        SwitchCamera();
    }

    void CameraNoiseProcess()
    {
        //�m�C�Y�^�C�}�[�̒l���V�F�[�_�֓n���B
        _postProcessMat.SetFloat(_noiseTimerID, _noiseTimer);
        _noiseTimer -= Time.deltaTime;
        //�m�C�Y�^�C�}�[��0�ɂȂ�����
        if (_noiseTimer <= 0.0f)
        {
            //0��n���B
            _postProcessMat.SetFloat(_noiseTimerID, 0.0f);
            _cameraSwitchFlag = false;
            _noiseTimer = CONST_NOISETIMER;
        }
    }
    /// <summary>
    /// �J�����ؑփt���O�̐ݒ�
    /// </summary>
    public void SetCameraSwitchFlag()
    {
        _cameraSwitchFlag = true;
    }
    /// <summary>
    /// �J�����ؑփt���O�̐ݒ�
    /// </summary>
    public bool GetCameraSwitchFlag()
    {
        return _cameraSwitchFlag;
    }
    /// <summary>
    /// �J�����ԍ��̎擾
    /// </summary>
    public int GetCamerNo()
    {
        return _cameraNo;
    }
}
