using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string SceneName;    // 遷移先のシーン名

    public void SceneChangeProcess(string sName = null)
    {
        if(sName != null)
        {
            SceneManager.LoadScene(sName);
            return;
        }
        SceneManager.LoadScene(SceneName);
    }
}
