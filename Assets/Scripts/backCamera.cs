using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backCamera : MonoBehaviour {

    public Camera choosingCam;
    public Camera cameraUI;
    public Camera cameraMale;
    public Camera cameraFemale;
    public int num;

    public void changeCamera(Button btn)
    {
        

        if (num< 0 || num >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("Can't load scene num " + num + ", SenceManager only has " + SceneManager.sceneCountInBuildSettings + "Scenes is BuildSetting !");
            return;
        }
        LoadingScreenManager.LoadScene(num);
        cameraUI.gameObject.SetActive(false);
        cameraMale.gameObject.SetActive(false);
        cameraFemale.gameObject.SetActive(false);


    }


}
