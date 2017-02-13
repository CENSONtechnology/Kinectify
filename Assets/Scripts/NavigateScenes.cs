using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateScenes : MonoBehaviour {

    //function to change main camera to another scene which in the build setting 
    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName); 
    }
}
