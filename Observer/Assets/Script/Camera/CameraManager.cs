using TMPro;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private GameObject camera1 = default; //�J����1
    [SerializeField] private GameObject camera2 = default; //�J����2
    [SerializeField] private GameObject camera3 = default; //�J����3
    [SerializeField] private GameObject camera4 = default; //�J����4
    [SerializeField] private GameObject camera5 = default; //�J����5

    [SerializeField]
    [Header("�|�X�g�G�t�F�N�g�}�e���A��")]
    private Material testPost;                                                  //�|�X�g�G�t�F�N�g�}�e���A��
    private readonly int _noiseTimerID = Shader.PropertyToID("_NoiseTimer");    // �V�F�[�_�[�v���p�e�B��Reference��
    private bool switchCameraFlag = false;                                      //�J�����ؑփt���O
    private const float CONST_NOISETIMER = 0.1f;                                //�m�C�Y�^�C�}�[�p�萔
    private float noiseTimer = default;                                         //�m�C�Y�^�C�}�[�p�ϐ�
    [SerializeField][Header("�J�����ԍ��e�L�X�g�I�u�W�F�N�g")]
    private TextMeshProUGUI cameraNoText = default;                             //�J�����ԍ��̃e�L�X�g�I�u�W�F�N�g
    private Vector3 camera1Pos = default;                                       //���C���J�����������W
    private Quaternion camera1Rot= default;                                     //���C���J����������]
    //�J�����ԍ�
    private int _cameraNo = default;
    //�J�����ԍ��̏��
    private const int MAX_CAMERA_NO = 4;


    void Start()
    {
        //�S�ẴJ�������擾����B
        //camera1 = GameObject.Find("MainCamera");
        //camera2 = GameObject.Find("Camera2");
        //camera3 = GameObject.Find("Camera3");
        //camera4 = GameObject.Find("Camera4");
        //camera5 = GameObject.Find("Camera5");
        //���C���J�����̏����ʒu���i�[����
        camera1Pos = camera1.transform.position;
        camera1Rot = camera1.transform.rotation;

        ////���C���J������ݒ�
        //camera1 = Camera.main;
        //���C���J������L��������
        ActiveCamera1();

        //�m�C�Y�^�C�}�[�p�ϐ��ɒ萔��������
        noiseTimer = CONST_NOISETIMER;
    }

    private void Update()
    {
        //�J�����ؑփt���O���I�t
        if (!switchCameraFlag)
        {
            return;
        }

        //�m�C�Y�^�C�}�[�̒l���V�F�[�_�֓n���B
        testPost.SetFloat(_noiseTimerID, noiseTimer);
        noiseTimer -= Time.deltaTime;
        //�m�C�Y�^�C�}�[��0�ɂȂ�����
        if (noiseTimer <= 0.0f)
        {
            //0��n���B
            testPost.SetFloat(_noiseTimerID, 0.0f);
            switchCameraFlag = false;
            noiseTimer = CONST_NOISETIMER;
        }
    }

    //�֐��F�J����1��L����
    public void ActiveCamera1()
    {
        camera1.transform.position = camera1Pos;
        camera1.transform.rotation = camera1Rot;

        cameraNoText.text = "Camera1";
    }

    //�֐��F�J����2��L����
    public void ActiveCamera2()
    {
        camera1.transform.position = camera2.transform.position;
        camera1.transform.rotation = camera2.transform.rotation;

        cameraNoText.text = "Camera2";
    }

    //�֐��F�J����3��L����
    public void ActiveCamera3()
    {
        camera1.transform.position = camera3.transform.position;
        camera1.transform.rotation = camera3.transform.rotation;

        cameraNoText.text = "Camera3";
    }
    //�֐��F�J����4��L����
    public void ActiveCamera4()
    {
        camera1.transform.position = camera4.transform.position;
        camera1.transform.rotation = camera4.transform.rotation;

        cameraNoText.text = "Camera4";
    }
    //�֐��F�J����5��L����
    public void ActiveCamera5()
    {
        camera1.transform.position = camera5.transform.position;
        camera1.transform.rotation = camera5.transform.rotation;

        cameraNoText.text = "Camera5";
    }

    public void SwitchCamera()
    {
        //�m�C�Y�𔭐�������
        switchCameraFlag = true;

        switch (_cameraNo)
        {
            case 0:
                ActiveCamera1();
                break;
            case 1:
                ActiveCamera2();
                break;
            case 2:
                ActiveCamera3();
                break;
            case 3:
                ActiveCamera4();
                break;
            case 4:
                ActiveCamera5();
                break;
            default:
                break;

        }
    }

    public bool GetSwitchCameraFlag()
    {
        return switchCameraFlag;
    }

    public void ClickButtonL()
    {
        if (GetSwitchCameraFlag())
        {
            return;
        }
        //�J�����ԍ���1������
        _cameraNo -= 1;
        //�J�����ԍ���0�����ɂȂ�����
        if (_cameraNo < 0)
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
        //�J�����ԍ���4�ȏ�ɂȂ�����
        if (_cameraNo > MAX_CAMERA_NO)
        {
            //�J�����ԍ���0�ɂ���
            _cameraNo = 0;
        }
        //�J�����̐؂�ւ�
        SwitchCamera();
    }
}
