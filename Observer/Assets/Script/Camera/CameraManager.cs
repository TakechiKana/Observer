using TMPro;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private GameObject mainCamera = default; //カメラ1
    [SerializeField] private GameObject camera1 = default; //カメラ2
    [SerializeField] private GameObject camera2 = default; //カメラ2
    [SerializeField] private GameObject camera3 = default; //カメラ3
    [SerializeField] private GameObject camera4 = default; //カメラ4
    [SerializeField] private GameObject camera5 = default; //カメラ5

    [SerializeField]
    [Header("ポストエフェクトマテリアル")]
    private Material _postProcessMat;
    [SerializeField]
    [Header("カメラ切替時のノイズ音")]
    private AudioClip _audioClip = default;
    private readonly int _noiseTimerID = Shader.PropertyToID("_NoiseTimer");    // シェーダープロパティのReference名
    private const float CONST_NOISETIMER = 0.1f;                                //ノイズタイマー用定数
    private float _noiseTimer = default;                                         //ノイズタイマー用変数
    private bool _cameraNoiseFlag = false;                                      //カメラ切替フラグ
    [SerializeField][Header("カメラ番号テキストオブジェクト")]
    private TextMeshProUGUI _cameraNoText = default;                             //カメラ番号のテキストオブジェクト
    //カメラ番号
    private int _cameraNo = 1;
    //カメラ番号の上限
    private const int MAX_CAMERA_NO = 5;


    void Start()
    {

        //メインカメラを有効化する
        ActiveCamera1();

        //ノイズタイマー用変数に定数を代入する
        _noiseTimer = CONST_NOISETIMER;
    }

    private void Update()
    {
        //カメラ切替フラグがオフ
        if (!_cameraNoiseFlag)
        {
            return;
        }

        CameraNoiseProcess();
    }

    //関数：カメラ1を有効化
    public void ActiveCamera1()
    {
        mainCamera.transform.position = camera1.transform.position;
        mainCamera.transform.rotation = camera1.transform.rotation;

        _cameraNoText.text = "Camera1";
    }

    //関数：カメラ2を有効化
    public void ActiveCamera2()
    {
        mainCamera.transform.position = camera2.transform.position;
        mainCamera.transform.rotation = camera2.transform.rotation;

        _cameraNoText.text = "Camera2";
    }

    //関数：カメラ3を有効化
    public void ActiveCamera3()
    {
        mainCamera.transform.position = camera3.transform.position;
        mainCamera.transform.rotation = camera3.transform.rotation;

        _cameraNoText.text = "Camera3";
    }
    //関数：カメラ4を有効化
    public void ActiveCamera4()
    {
        mainCamera.transform.position = camera4.transform.position;
        mainCamera.transform.rotation = camera4.transform.rotation;

        _cameraNoText.text = "Camera4";
    }
    //関数：カメラ5を有効化
    public void ActiveCamera5()
    {
        mainCamera.transform.position = camera5.transform.position;
        mainCamera.transform.rotation = camera5.transform.rotation;

        _cameraNoText.text = "Camera5";
    }

    public void CameraUpdate()
    {
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
                break;

        }
    }

    private bool GetCameraNoiseFlag()
    {
        return _cameraNoiseFlag;
    }

    public void ClickButtonL()
    {
        if (GetCameraNoiseFlag())
        {
            return;
        }
        //カメラ番号を1下げる
        _cameraNo -= 1;
        //カメラ番号が0以下になったら
        if (_cameraNo <= 0)
        {
            //カメラ番号を3にする
            _cameraNo = MAX_CAMERA_NO;
        }
        SetCameraNoiseFlag();
        //カメラの切り替え
        CameraUpdate();
    }
    /// <summary>
    /// 右ボタンがクリックされたら
    /// </summary>
    public void ClickButtonR()
    {
        if (GetCameraNoiseFlag())
        {
            return;
        }
        //カメラ番号を1上げる
        _cameraNo += 1;
        //カメラ番号が5より大きくなったら
        if (_cameraNo > MAX_CAMERA_NO)
        {
            //カメラ番号を0にする
            _cameraNo = 1;
        }
        SetCameraNoiseFlag();
        //カメラの切り替え
        CameraUpdate();
    }

    void CameraNoiseProcess()
    {
        //ノイズタイマーの値をシェーダへ渡す。
        _postProcessMat.SetFloat(_noiseTimerID, _noiseTimer);
        _noiseTimer -= Time.deltaTime;
        //ノイズタイマーが0になったら
        if (_noiseTimer <= 0.0f)
        {
            //0を渡す。
            _postProcessMat.SetFloat(_noiseTimerID, 0.0f);
            _cameraNoiseFlag = false;
            _noiseTimer = CONST_NOISETIMER;
        }
    }
    /// <summary>
    /// カメラ切替フラグの設定
    /// </summary>
    public void SetCameraNoiseFlag()
    {
        _cameraNoiseFlag = true;
        this.GetComponent<AudioSource>().PlayOneShot(_audioClip);
    }
    /// <summary>
    /// カメラ切替フラグの設定
    /// </summary>
    public bool GetCameraSwitchFlag()
    {
        return _cameraNoiseFlag;
    }
    /// <summary>
    /// カメラ番号の取得
    /// </summary>
    public int GetCameraNo()
    {
        return _cameraNo;
    }
}
