using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneNum : MonoBehaviour {

    public void LoadSceneNumber(int num)
    {
        if (num < 0 || num >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("Can't load scene num " + num + ", SenceManager only has " + SceneManager.sceneCountInBuildSettings + "Scenes is BuildSetting !");
            return;
        }
        LoadingScreenManager.LoadScene(num);
    }
   
}
