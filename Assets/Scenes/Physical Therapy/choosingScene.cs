using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class choosingScene : MonoBehaviour
{
    string gender;
    //private Text LeftHand;
    //private Text RightHand;
    //string RH;
    //string LH;
    public void choosingRoom()
    {
        //var rt = GameObject.Find("RightHand");
        //var lt = GameObject.Find("LeftHand");
        //RightHand = rt.GetComponent<Text>();
        //LeftHand = lt.GetComponent<Text>();
        //RH = RightHand.text;
        //LH = LeftHand.text;
        //GetPatientInformation.Righthand = RH;
        //GetPatientInformation.lefthand =LH;
       gender= GetPatientInformation.Gender;
        if (gender.Contains("Female"))
        {
            SceneManager.LoadScene("FlexionRoomsFemale");
        }
        else if (gender.Contains("Male"))
        {
            SceneManager.LoadScene("FlexionRoomsMale");

        }
    }
}
