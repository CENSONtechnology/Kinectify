using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour {
   public Camera BedroomCam;
   public Camera PatientInfo;
   public Camera ChooseRoom;
    public Camera officeCam;

    public void startLevelwithroom()
    {
        ChooseRoom.gameObject.SetActive(true);
        PatientInfo.gameObject.SetActive(false);
    }
    public void startbedroom()
    {
        ChooseRoom.gameObject.SetActive(false);
        BedroomCam.gameObject.SetActive(true);
    }
    public void startoffice()
    {
        ChooseRoom.gameObject.SetActive(false);
        officeCam.gameObject.SetActive(true);
    }

}
