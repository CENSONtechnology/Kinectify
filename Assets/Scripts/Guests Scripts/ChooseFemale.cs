using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseFemale : MonoBehaviour {

    public Camera BedRoom;
    public Camera ChooseRoomsFemale;
    public Camera Office;

    public void ChooseRoom()
    {
        ChooseRoomsFemale.gameObject.SetActive(true);
    }
    public void ChooseBedRoomFemale()
    {
        ChooseRoomsFemale.gameObject.SetActive(false);

        BedRoom.gameObject.SetActive(true);

    }
    public void ChooseOfficeFemale()
    {
        ChooseRoomsFemale.gameObject.SetActive(false);
        Office.gameObject.SetActive(true);

    }
}
