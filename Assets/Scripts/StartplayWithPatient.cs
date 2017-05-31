using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartplayWithPatient : MonoBehaviour {

    private Text LeftAngle;
    private Text RightAngle;

    public void startplay()
    {
        var rt = GameObject.Find("RightAngle");
        var lt = GameObject.Find("LeftAngle");

        RightAngle = rt.GetComponent<Text>();
        LeftAngle = lt.GetComponent<Text>();

        RightAngle.text = GetPatientInformation.Righthand;
        LeftAngle.text = GetPatientInformation.lefthand;
    }

}
