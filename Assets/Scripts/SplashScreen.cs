using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour {

    // Use this for initialization
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        Application.LoadLevel("Home Page");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
