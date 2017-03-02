using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCamera : MonoBehaviour {

    public Camera ChooseCharcter;
    public Camera ChooseRoomsFemale;
    public Camera ChooseRoomsMale;
    public Camera bedMale;
    public Camera OfficeMale;
    public Camera bedFeMale;
    public Camera OfficeFeMale;

    public void CloseMale()
    {
        ChooseCharcter.gameObject.SetActive(true);
        ChooseRoomsMale.gameObject.SetActive(false);
    }
    public void CloseFeMale()
    {
        ChooseCharcter.gameObject.SetActive(true);
        ChooseRoomsFemale.gameObject.SetActive(false);
    }
    public void closebedmale()
    {
        bedMale.gameObject.SetActive(false);
        ChooseRoomsMale.gameObject.SetActive(true);
    }
    public void closeOfficemale()
    {
        OfficeMale.gameObject.SetActive(false);
        ChooseRoomsMale.gameObject.SetActive(true);
    }
    public void closebedFemale()
    {
        bedFeMale.gameObject.SetActive(false);
        ChooseRoomsFemale.gameObject.SetActive(true);
    }
    public void closeofficeFemale()
    {
        OfficeFeMale.gameObject.SetActive(false);
        ChooseRoomsFemale.gameObject.SetActive(true);
    }
}
