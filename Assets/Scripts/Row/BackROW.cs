using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackROW : MonoBehaviour {

    // Use this for initialization
    public Button shoulder;
    public Button wirst;
    public Button thumb;
    public Button pip;
    public Button dip;
    public Button hip;
    public Button knee;
    public Button ankle;
    public Button ankleANDfoot;
    public Camera Cam;
    public Image img;


    // to make the Camera of movement selection invisable
    public void BackROWMovement()
    {
        Cam.gameObject.SetActive(false);
        shoulder.gameObject.SetActive(true);
        wirst.gameObject.SetActive(true);
        thumb.gameObject.SetActive(true);
        pip.gameObject.SetActive(true);
        dip.gameObject.SetActive(true);
        hip.gameObject.SetActive(true);
        knee.gameObject.SetActive(true);
        ankle.gameObject.SetActive(true);
        ankleANDfoot.gameObject.SetActive(true);
        img.gameObject.SetActive(true);
       


    }

}
