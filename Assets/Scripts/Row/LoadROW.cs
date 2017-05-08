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
    public Button ELbow;
    public Image img;

    public Camera RowCam;
    public Camera NeckCam;
    public Camera ShoulderCam;
    public Camera LumberCam;
    public Camera HipsCam;
    public Camera WristCam;
    public Camera KneeCam;
    public Camera AnkleCam;


    // to make the Camera of movement selection visable
    public void LoadElbowMovement()
    {
        shoulder.gameObject.SetActive(false);
        wirst.gameObject.SetActive(false);
        thumb.gameObject.SetActive(false);
        pip.gameObject.SetActive(false);
        hip.gameObject.SetActive(false);
        knee.gameObject.SetActive(false);
        ankle.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        RowCam.gameObject.SetActive(true);

    }
    public void LoadNeckMovement()
    {
        shoulder.gameObject.SetActive(false);
        wirst.gameObject.SetActive(false);
        thumb.gameObject.SetActive(false);
        ELbow.gameObject.SetActive(false);
        hip.gameObject.SetActive(false);
        knee.gameObject.SetActive(false);
        ankle.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        NeckCam.gameObject.SetActive(true);

    }
    public void LoadShoulderMovement()
    {
        ELbow.gameObject.SetActive(false);
        wirst.gameObject.SetActive(false);
        thumb.gameObject.SetActive(false);
        pip.gameObject.SetActive(false);
        hip.gameObject.SetActive(false);
        knee.gameObject.SetActive(false);
        ankle.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        ShoulderCam.gameObject.SetActive(true);

    }
    public void LoadLumberMovement()
    {
        shoulder.gameObject.SetActive(false);
        wirst.gameObject.SetActive(false);
        ELbow.gameObject.SetActive(false);
        pip.gameObject.SetActive(false);
        hip.gameObject.SetActive(false);
        knee.gameObject.SetActive(false);
        ankle.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        LumberCam.gameObject.SetActive(true);

    }
    public void LoadHipsMovement()
    {
        shoulder.gameObject.SetActive(false);
        wirst.gameObject.SetActive(false);
        thumb.gameObject.SetActive(false);
        pip.gameObject.SetActive(false);
        ELbow.gameObject.SetActive(false);
        knee.gameObject.SetActive(false);
        ankle.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        HipsCam.gameObject.SetActive(true);

    }
    public void LoadWirstMovement()
    {
        shoulder.gameObject.SetActive(false);
        ELbow.gameObject.SetActive(false);
        thumb.gameObject.SetActive(false);
        pip.gameObject.SetActive(false);
        hip.gameObject.SetActive(false);
        knee.gameObject.SetActive(false);
        ankle.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        WristCam.gameObject.SetActive(true);

    }
    public void LoadKneeMovement()
    {
        shoulder.gameObject.SetActive(false);
        wirst.gameObject.SetActive(false);
        thumb.gameObject.SetActive(false);
        pip.gameObject.SetActive(false);
        hip.gameObject.SetActive(false);
        ELbow.gameObject.SetActive(false);
        ankle.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        KneeCam.gameObject.SetActive(true);

    }
    public void LoadAnkleMovement()
    {
        shoulder.gameObject.SetActive(false);
        wirst.gameObject.SetActive(false);
        thumb.gameObject.SetActive(false);
        pip.gameObject.SetActive(false);
        hip.gameObject.SetActive(false);
        knee.gameObject.SetActive(false);
        ELbow.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        AnkleCam.gameObject.SetActive(true);

    }

}
