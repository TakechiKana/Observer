using TMPro;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private GameObject camera1 = default; //カメラ1
    [SerializeField] private GameObject camera2 = default; //カメラ2
    [SerializeField] private GameObject camera3 = default; //カメラ3
    [SerializeField] private GameObject camera4 = default; //カメラ4
    [SerializeField] private GameObject camera5 = default; //カメラ5

    [SerializeField]
    [Header("ポストエフェクトマテリアル")]
    private Material testPost;                                                  //ポストエフェクトマテリアル
    private readonly int _noiseTimerID = Shader.PropertyToID("_NoiseTimer");    // シェーダープロパティのReference名
    private bool switchCameraFlag = false;                                      //カメラ切替フラグ
    private const float CONST_NOISETIMER = 0.1f;                                //ノイズタイマー用定数
    private float noiseTimer = default;                                         //ノイズタイマー用変数
    [SerializeField][Header("カメラ番号テキストオブジェクト")]
    private TextMeshProUGUI cameraNoText = default;                             //カメラ番号のテキストオブジェクト
    private Vector3 camera1Pos = default;                                       //メインカメラ初期座標
    private Quaternion camera1Rot= default;                                     //メインカメラ初期回転
    //カメラ番号
    private int _cameraNo = default;
    //カメラ番号の上限
    private const int MAX_CAMERA_NO = 4;


    void Start()
    {
        //全てのカメラを取得する。
        //camera1 = GameObject.Find("MainCamera");
        //camera2 = GameObject.Find("Camera2");
        //camera3 = GameObject.Find("Camera3");
        //camera4 = GameObject.Find("Camera4");
        //camera5 = GameObject.Find("Camera5");
        //メインカメラの初期位置を格納する
        camera1Pos = camera1.transform.position;
        camera1Rot = camera1.transform.rotation;

        ////メインカメラを設定
        //camera1 = Camera.main;
        //メインカメラを有効化する
        ActiveCamera1();

        //ノイズタイマー用変数に定数を代入する
        noiseTimer = CONST_NOISETIMER;
    }

    private void Update()
    {
        //カメラ切替フラグがオフ
        if (!switchCameraFlag)
        {
            return;
        }

        //ノイズタイマーの値をシェーダへ渡す。
        testPost.SetFloat(_noiseTimerID, noiseTimer);
        noiseTimer -= Time.deltaTime;
        //ノイズタイマーが0になったら
        if (noiseTimer <= 0.0f)
        {
            //0を渡す。
            testPost.SetFloat(_noiseTimerID, 0.0f);
            switchCameraFlag = false;
            noiseTimer = CONST_NOISETIMER;
        }
    }

    //関数：カメラ1を有効化
    public void ActiveCamera1()
    {
        camera1.transform.position = camera1Pos;
        camera1.transform.rotation = camera1Rot;

        cameraNoText.text = "Camera1";
    }

    //関数：カメラ2を有効化
    public void ActiveCamera2()
    {
        camera1.transform.position = camera2.transform.position;
        camera1.transform.rotation = camera2.transform.rotation;

        cameraNoText.text = "Camera2";
    }

    //関数：カメラ3を有効化
    public void ActiveCamera3()
    {
        camera1.transform.position = camera3.transform.position;
        camera1.transform.rotation = camera3.transform.rotation;

        cameraNoText.text = "Camera3";
    }
    //関数：カメラ4を有効化
    public void ActiveCamera4()
    {
        camera1.transform.position = camera4.transform.position;
        camera1.transform.rotation = camera4.transform.rotation;

        cameraNoText.text = "Camera4";
    }
    //関数：カメラ5を有効化
    public void ActiveCamera5()
    {
        camera1.transform.position = camera5.transform.position;
        camera1.transform.rotation = camera5.transform.rotation;

        cameraNoText.text = "Camera5";
    }

    public void SwitchCamera()
    {
        //ノイズを発生させる
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
        //カメラ番号を1下げる
        _cameraNo -= 1;
        //カメラ番号が0未満になったら
        if (_cameraNo < 0)
        {
            //カメラ番号を3にする
            _cameraNo = MAX_CAMERA_NO;
        }
        //カメラの切り替え
        SwitchCamera();
    }
    /// <summary>
    /// 右ボタンがクリックされたら
    /// </summary>
    public void ClickButtonR()
    {
        if (GetSwitchCameraFlag())
        {
            return;
        }
        //カメラ番号を1上げる
        _cameraNo += 1;
        //カメラ番号が4以上になったら
        if (_cameraNo > MAX_CAMERA_NO)
        {
            //カメラ番号を0にする
            _cameraNo = 0;
        }
        //カメラの切り替え
        SwitchCamera();
    }
}
