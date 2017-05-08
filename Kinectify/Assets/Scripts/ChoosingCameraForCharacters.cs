using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingCameraForCharacters : MonoBehaviour {

    // Use this for initialization
    public Camera choosingCam;
    public Camera bedRoom;
    public Camera office;

    public void choosingBedRoom()
    {
        choosingCam.gameObject.SetActive(false);
        bedRoom.gameObject.SetActive(true);
        //AnglesCalculation.Angles.Start();
    }
    public void choosingOffice()
    {
        choosingCam.gameObject.SetActive(false);
        office.gameObject.SetActive(true);
        //AnglesCalculation.Angles.Start();
    }
    public void backFromBedRoom()
    {
        choosingCam.gameObject.SetActive(true);
        bedRoom.gameObject.SetActive(false);
    }
    public void backFromOffice()
    {
        choosingCam.gameObject.SetActive(true);
        office.gameObject.SetActive(false);
    }

}
