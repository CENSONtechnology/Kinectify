using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackROW : MonoBehaviour
{

    // Use this for initialization
    public Button shoulder;
    public Button wirst;
    public Button thumb;
    public Button pip;
    public Button hip;
    public Button knee;
    public Button ankle;
    public Button ELbow;
    public Image img;

    public Camera ElbowCam;
    public Camera NeckCam;
    public Camera ShoulderCam;
    public Camera LumberCam;
    public Camera HipsCam;
    public Camera WristCam;
    public Camera KneeCam;
    public Camera AnkleCam;
    // to make the Camera of movement selection invisable
    public void BackELbowMovement()
    {
        ElbowCam.gameObject.SetActive(false);
        shoulder.gameObject.SetActive(true);
        wirst.gameObject.SetActive(true);
        thumb.gameObject.SetActive(true);
        pip.gameObject.SetActive(true);
        hip.gameObject.SetActive(true);
        knee.gameObject.SetActive(true);
        ankle.gameObject.SetActive(true);
        img.gameObject.SetActive(true);
    }
    public void BackENeckMovement()
    {
        NeckCam.gameObject.SetActive(false);
        shoulder.gameObject.SetActive(true);
        wirst.gameObject.SetActive(true);
        thumb.gameObject.SetActive(true);
        ELbow.gameObject.SetActive(true);
        hip.gameObject.SetActive(true);
        knee.gameObject.SetActive(true);
        ankle.gameObject.SetActive(true);
        img.gameObject.SetActive(true);
    }
    public void BackShoulderMovement()
    {
        ShoulderCam.gameObject.SetActive(false);
        ELbow.gameObject.SetActive(true);
        wirst.gameObject.SetActive(true);
        thumb.gameObject.SetActive(true);
        pip.gameObject.SetActive(true);
        hip.gameObject.SetActive(true);
        knee.gameObject.SetActive(true);
        ankle.gameObject.SetActive(true);
        img.gameObject.SetActive(true);
    }
    public void BackELumbarMovement()
    {
        LumberCam.gameObject.SetActive(false);
        shoulder.gameObject.SetActive(true);
        wirst.gameObject.SetActive(true);
        ELbow.gameObject.SetActive(true);
        pip.gameObject.SetActive(true);
        hip.gameObject.SetActive(true);
        knee.gameObject.SetActive(true);
        ankle.gameObject.SetActive(true);
        img.gameObject.SetActive(true);
    }
    public void BackHipsMovement()
    {
        HipsCam.gameObject.SetActive(false);
        shoulder.gameObject.SetActive(true);
        wirst.gameObject.SetActive(true);
        thumb.gameObject.SetActive(true);
        pip.gameObject.SetActive(true);
        ELbow.gameObject.SetActive(true);
        knee.gameObject.SetActive(true);
        ankle.gameObject.SetActive(true);
        img.gameObject.SetActive(true);
    }
    public void BackEWristMovement()
    {
        WristCam.gameObject.SetActive(false);
        shoulder.gameObject.SetActive(true);
        ELbow.gameObject.SetActive(true);
        thumb.gameObject.SetActive(true);
        pip.gameObject.SetActive(true);
        hip.gameObject.SetActive(true);
        knee.gameObject.SetActive(true);
        ankle.gameObject.SetActive(true);
        img.gameObject.SetActive(true);
    }
    public void BackEKneeMovement()
    {
        KneeCam.gameObject.SetActive(false);
        shoulder.gameObject.SetActive(true);
        wirst.gameObject.SetActive(true);
        thumb.gameObject.SetActive(true);
        pip.gameObject.SetActive(true);
        hip.gameObject.SetActive(true);
        ELbow.gameObject.SetActive(true);
        ankle.gameObject.SetActive(true);
        img.gameObject.SetActive(true);
    }
    public void BackAnkleMovement()
    {
        AnkleCam.gameObject.SetActive(false);
        shoulder.gameObject.SetActive(true);
        wirst.gameObject.SetActive(true);
        thumb.gameObject.SetActive(true);
        pip.gameObject.SetActive(true);
        hip.gameObject.SetActive(true);
        knee.gameObject.SetActive(true);
        ELbow.gameObject.SetActive(true);
        img.gameObject.SetActive(true);
    }

}
