using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DataInserterPatient : MonoBehaviour
{
    [SerializeField]
    private Dropdown DiseaseDdl = null;
    [SerializeField]
    private Dropdown MovementDdl = null;
    [SerializeField]
    private InputField RightField = null;
    [SerializeField]
    private InputField LeftField = null;
    [SerializeField]
    private Text ViewText = null;
    string url = "localhost/kinectify/DataInserterPatient.php";
    string moveinsert;
    string disinsert;
    public void BtnPaient()
    {
        
        if (DiseaseDdl.value == 0)
        {
            ViewText.text = "please sellect your disease";
        }
        else if (MovementDdl.value == 0)
        {
            ViewText.text = "please sellect your Movement";
        }
        else if (RightField.text == "")
        {
            ViewText.text = "please Insert Right Field";
        }
        else if (LeftField.text == "")
        {
            ViewText.text = "please Insert Left Field";
        }


        else
        {
            if (DiseaseDdl.value==1)
            {
                 disinsert = "Elbow";
            }

            if (MovementDdl.value == 1)
            {
                 moveinsert = "Flexion";
            }
            else if (MovementDdl.value == 2)
            {
                 moveinsert = "Extension";
            }
           
            string Lh = LeftField.text;
            string Rh = RightField.text;
            int PaientID = 3;

            WWW www = new WWW(url + "?Patient_ID=" + PaientID + "&Diesease=" + disinsert + "&Movement=" + moveinsert + "&Lh=" + Lh + "&Rh=" + Rh );

            StartCoroutine(ValidRegister(www));

            
        }

    }
    IEnumerator ValidRegister(WWW www)
    {
        yield return www;

    }

}












//    IEnumerator Start()
//    {
//        WWW itemsData = new WWW("http://localhost/kinectify/DataInserterPatient.php");
//        yield return itemsData;
//        string itemsDataString = itemsData.text;
//        print(itemsDataString);
//        items = itemsDataString.Split(';');
//        print(GetDataValue(items[0], "Gender:"));
//    }

//    string GetDataValue(string data, string index)
//    {
//        string value = data.Substring(data.IndexOf(index) + index.Length);
//        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
//        return value;
//    }


//}


























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
