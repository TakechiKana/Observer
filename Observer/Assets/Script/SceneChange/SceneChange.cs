using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string SceneName;    // �J�ڐ�̃V�[����
    //void Update()
    //{
    //    // �X�y�[�X�L�[�������ꂽ��V�[����؂�ւ���
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        SceneManager.LoadScene(SceneName);
    //    }
    //}

    public void SceneChangeProcess()
    {
        SceneManager.LoadScene(SceneName);
    }
}
