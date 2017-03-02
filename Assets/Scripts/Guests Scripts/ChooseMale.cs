using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMale: MonoBehaviour {


    public Camera BedRoom;
    public Camera ChooseRoomsMale;
    public Camera Office;

    public void ChooseRoom()
    {
        ChooseRoomsMale.gameObject.SetActive(true);
    }
    public void ChooseBedRoomMale()
    {
        ChooseRoomsMale.gameObject.SetActive(false);
        
        BedRoom.gameObject.SetActive(true);

    }
    public void ChooseOfficeMale()
    {
        ChooseRoomsMale.gameObject.SetActive(false);
        Office.gameObject.SetActive(true);

    }

}
