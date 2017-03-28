using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadROW : MonoBehaviour {

    public Button shoulder;
    public Button wirst;
    public Button thumb;
    public Button pip;
    public Button hip;
    public Button knee;
    public Button ankle;
    public Camera Cam;
    public Image img;


    // to make the Camera of movement selection visable
    public void LoadROWMovement()
    {
        shoulder.gameObject.SetActive(false);
        wirst.gameObject.SetActive(false);
        thumb.gameObject.SetActive(false);
        pip.gameObject.SetActive(false);
        hip.gameObject.SetActive(false);
        knee.gameObject.SetActive(false);
        ankle.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        Cam.gameObject.SetActive(true);


    }
}
