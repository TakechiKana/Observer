using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    //public static bool isFadeInstance = false;      //�Q�[���N�����̃L�����o�X�����t���O

    public bool _isFadeIn = false;//�t�F�[�h�C������t���O
    public bool _isFadeOut = false;//�t�F�[�h�A�E�g����t���O

    public float _alpha = 0.0f;//���ߗ��A�����ω�������
    public float _fadeSpeed = 0.2f;//�t�F�[�h�Ɋ|���鎞��

    //�t���O�}�l�[�W��
    private GameObject _flagManager = default;
    void Start()
    {
        this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, _alpha);
        Invoke("FindFlagObject", 0.09f);    //�����҂��Ă���t�F�[�h�I�u�W�F�N�g����������
        //isFadeInstance = true;
    }
    /// <summary>
    /// �t���O�}�l�[�W���̌���
    /// </summary>
    void FindFlagObject()
    {
        //�t���O�}�l�W�����݂���
        _flagManager = GameObject.FindGameObjectWithTag("FlagManager");
        //�f�o�b�O���ȂǂŃt���O�}�l�[�W������������Ă��Ȃ��Ƃ�
        if (_flagManager == null)
        {
            //�������Ȃ�
            return;
        }

        //�t���O�}�l�[�W������Q�[���N���ς��擾����
        if (_flagManager.GetComponent<FlagManager>().GetGameStart())
        {
            //�N�����Ă����玩�g���폜
            Destroy(this);
            return;
        }
        //�V�[���Ԃŕێ��ł���悤�ɂ���
        DontDestroyOnLoad(this);
        //�Q�[���N���t���O��ݒ肷��
        _flagManager.GetComponent<FlagManager>().SetGameStart();
    }

    void Update()
    {
        if (_isFadeIn)
        {
            if(_isFadeOut)
            {
                _isFadeOut = false;
            }
            _alpha -= Time.deltaTime / _fadeSpeed;
            if (_alpha <= 0.0f)//�����ɂȂ�����A�t�F�[�h�C�����I��
            {
                _isFadeIn = false;
                _alpha = 0.0f;
                this.gameObject.SetActive(false);
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, _alpha);
        }
        else if (_isFadeOut)
        {
            _alpha += Time.deltaTime / _fadeSpeed;
            if (_alpha >= 1.0f)//�^�����ɂȂ�����A�t�F�[�h�A�E�g���I��
            {
                //isFadeOut = false;
                _alpha = 1.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, _alpha);
        }
    }

    public void SetFadeIn()
    {
        StartCoroutine("WaitFadeIn");
        
    }

    public void SetFadeOut()
    {
        _isFadeOut = true;
        _isFadeIn = false;
    }
    IEnumerator WaitFadeIn()
    {
        //1�b�҂�
        yield return new WaitForSeconds(1.0f);
        //�t���O�Ǘ�
        _isFadeIn = true;
        _isFadeOut = false;
        //�R���[�`�����~
        yield break;
    }
    public bool GetIsFadeOut()
    {
        return _isFadeOut;
    }

    public bool GetDoFade()
    {
        return _isFadeOut == false && _isFadeIn == false;
    }
}
