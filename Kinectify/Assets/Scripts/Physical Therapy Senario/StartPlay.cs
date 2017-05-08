using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartPlay : MonoBehaviour {

    // Use this for initialization
    public Camera Choosing;
    public Camera Angles;
    public Text RightBed;
    public Text LeftBed;
    public Text RightOffice;
    public Text LeftOffice;
    public  InputField RightA;
    public  InputField LeftA;
    public static string Right;
    public static string Left;

    public void okbutton()
    {
        Angles.gameObject.SetActive(false);
        Choosing.gameObject.SetActive(true);
        Right = RightA.text;
        Left = LeftA.text;

        RightBed.text = Right;
        RightOffice.text = Right;

        LeftBed.text = Left;
        LeftOffice.text = Left;
        
    }
}
