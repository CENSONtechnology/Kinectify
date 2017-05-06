using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DataLoader : MonoBehaviour
{
    [SerializeField]
    private InputField FullNameField = null;
    [SerializeField]
    private InputField AgeField = null;
    [SerializeField]
    private InputField GenderField = null;
    [SerializeField]
    private InputField NotesField = null;
    public string[] items;
    public string PatientID;
    public string FirstName, LastName, Age,Gender,Notes,Password,Phone,Email;

    IEnumerator Start()
    {
        PatientID = GetMyID.LoginID;

        WWW itemsData = new WWW("http://localhost/kinectify/patient.php"+ "?Patient_ID="+ PatientID);
        yield return itemsData;
        string itemsDataString = itemsData.text;
        print(itemsDataString);
        items = itemsDataString.Split(';');
        GenderField.text = GetDataValue(items[0], "Gender:");
        AgeField.text = GetDataValue(items[0], "Age:");
        NotesField.text = GetDataValue(items[0], "Notes:");
        FullNameField.text = GetDataValue(items[0], "FullName:");

        FirstName = GetDataValue(items[0], "FirstName:");
        print(FirstName);
        LastName = GetDataValue(items[0], "LastName:");
        print(LastName);
        Age = GetDataValue(items[0], "Age:");
        print(Age);
        Gender = GetDataValue(items[0], "Gender:");
        print(Gender);
        Notes = GetDataValue(items[0], "Notes:");
        print(Notes);
        Password = GetDataValue(items[0], "Password:");
        print(Password);
        Phone = GetDataValue(items[0], "Phone:");
        print("0"+Phone);
        Email = GetDataValue(items[0], "Email:");
        print(Email);

        //pathing value to another script (GetPatientInformation) to retrive data from this script
        GetPatientInformation.Firstname = FirstName;
        GetPatientInformation.Lastname = LastName;
        GetPatientInformation.Age = Age;
        GetPatientInformation.Gender = Gender;
        GetPatientInformation.Notes = Notes;
        GetPatientInformation.Password = Password;
        GetPatientInformation.Phone = Phone;
        GetPatientInformation.Email = Email;




    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }


}



















