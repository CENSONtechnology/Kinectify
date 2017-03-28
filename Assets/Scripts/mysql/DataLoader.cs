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
    string PaientID;
    IEnumerator Start()
    {
        WWW itemsData = new WWW("http://localhost/kinectify/Patient.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        print(itemsDataString);
        items = itemsDataString.Split(';');
        GenderField.text= GetDataValue(items[0], "Gender:");
        AgeField.text = GetDataValue(items[0], "Age:");
        NotesField.text = GetDataValue(items[0], "Notes:");
        FullNameField.text = GetDataValue(items[0], "FullName:");
        
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }


}


























//void Start(){
//	string data = "ID:1|Name:Health Potion|Type:consumables|Cost:50";
//	print(GetDataValue(data, "Cost:"));
//}
//
//void Update(){
//	
//}
//
//string GetDataValue(string data ,string index){
//	string value = data.Substring(data.IndexOf(index)+index.Length);
//	if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
//	return value;
//}
