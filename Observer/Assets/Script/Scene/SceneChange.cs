using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private const float CONST_NOISETIMER = 0.1f;                                    //�m�C�Y�^�C�}�[�p�萔
    private GameObject fadeCanvas = null;                                           //�t�F�[�h�X�N���[��
    private AsyncOperation _async = default;                                        //�V�[���ؑ֗p�ϐ�
    private string _sceneName = default;                                            //�V�[����
    private bool _isChanging = false;                                               //�V�[���ؑ֒���

    private void Start()
    {
        Invoke("FindFadeObject", 0.09f);    //�����҂��Ă���t�F�[�h�I�u�W�F�N�g����������
    }
    void FindFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");//Canvas���݂���
        if(fadeCanvas == null)
        {
            return;
        }
    }

    public void SceneChangeProcess(string sName)
    {
        //���ɃV�[���ؑ֒��̂Ƃ�
        if(_isChanging)
        {
            //�������Ȃ�
            return;
        }
        //�V�[������ϐ��Ɋi�[
        _sceneName = sName;
        //�V�[�������ɓǂݍ��܂�Ă��邩���ׂ�
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            //�ǂݍ��ݍς̃V�[��
            Scene scene = SceneManager.GetSceneAt(i);
            //���ɓǂݍ��܂�Ă�����
            if (scene.name == _sceneName)
            {
                //�������Ȃ�
                return;
            }
        }
        //�V�[���ؑ֒��t���O��ݒ肷��
        _isChanging = true;
        //�V�[����ǂݍ���
        StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {
        fadeCanvas.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fadeCanvas.GetComponent<FadeManager>().SetFadeOut();
        yield return new WaitForSeconds(1.0f);
        _async = SceneManager.LoadSceneAsync(_sceneName);
        _async.allowSceneActivation = false;
        yield return new WaitForSeconds(2.0f);
        _async.allowSceneActivation = true;
        fadeCanvas.GetComponent<FadeManager>().SetFadeIn();
        yield break;
    }

}
