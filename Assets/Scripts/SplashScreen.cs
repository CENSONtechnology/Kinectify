using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {
    
    // Use this for initialization
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Home Page");
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
