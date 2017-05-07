using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GetDataFromInserter : MonoBehaviour
{
    public string[] items;
    public string PatientID;
    public string Diesease, Movement, Lh, Rh;

    IEnumerator Start()
    {
        PatientID = GetMyID.LoginID;

        WWW itemsData = new WWW("http://localhost/kinectify/GetPatientInformation.php" + "?Patient_ID=16");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        print(itemsDataString);
        items = itemsDataString.Split(';');
        Diesease = GetDataValue(items[0], "Diesease:");
        print(Diesease);
        Movement = GetDataValue(items[0], "Movement:");
        print(Movement);
        Lh = GetDataValue(items[0], "Lh:");
        print(Lh);
        Rh = GetDataValue(items[0], "Rh:");
        print(Rh);


        //pathing value to another script (GetPatientInformation) to retrive data from this script

        GetPatientInformation.Diesease = Diesease;
        GetPatientInformation.Movement = Movement;
        GetPatientInformation.Lh = Lh;
        GetPatientInformation.Rh = Rh;
        


    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }


}



















