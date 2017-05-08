using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Registration2 : MonoBehaviour {

    [SerializeField]
    private InputField UserInsField = null;
    [SerializeField]
    private InputField PassInsField = null;
    [SerializeField]
    private InputField confirmField = null;
    [SerializeField]
    private InputField phoneField = null;
    [SerializeField]
    private InputField AgeField = null;
    [SerializeField]
    private Dropdown genderDD = null;
    [SerializeField]
    private InputField FirstNameField = null;
    [SerializeField]
    private InputField LastNameField = null;
    [SerializeField]
    private InputField NotesField = null;
    [SerializeField]
    private InputField EmailField = null;
    string gender1;
    string InsertUrl = "localhost/kinectify/Registration.php";
    

  
    public void BtnRegister()
    {
        UISampleWindow Ui = new UISampleWindow();
        if (UserInsField.text == "")
        {
            Ui.Username();
        }
        else if (PassInsField.text == "" )
        {
            Ui.Password();
        }
        else if (confirmField.text == "")
        {
            Ui.ConfirmPassword();
        }
        else if (PassInsField.text !=confirmField.text)
        {
            Ui.testConfirmPassword();
        }
        else if (phoneField.text == "")
        {
            Ui.PhoneNumber();
        }
        else if (AgeField.text == "")
        {
            Ui.Age();
        }
        else if (genderDD.value == 0)
        {
            Ui.Gender();
        }
        else if (EmailField.text == "")
        {
            Ui.Email();
        }
        else if (FirstNameField.text == "")
        {
            Ui.FirstName();
        }
        else if (LastNameField.text == "")
        {
            Ui.LastName();
        }
      



        else
        {
            if (genderDD.value==1)
            {
                gender1 = "Male";

            }
            if (genderDD.value == 2)
            {
                gender1 = "Female";

            }
            string username = UserInsField.text;
            string password = PassInsField.text;
            string confirm = confirmField.text;
            string phone = phoneField.text;
            string age = AgeField.text;
            string firstname = FirstNameField.text;
            string lastname = LastNameField.text;
            string notes = NotesField.text;
            string email = EmailField.text;
            WWW www = new WWW(InsertUrl + "?UserName=" + username + "&Password=" + password + "&Phone=" + phone + "&Age=" + age + "&Gender=" + gender1 + "&Email=" + email
                + "&FirstName=" + firstname + "&LastName=" + lastname + "&Notes=" + notes);

            StartCoroutine(ValidRegister(www));

            Ui.LoginSucsessful();
        }
        
    }
    IEnumerator ValidRegister(WWW www)
    {
        yield return www;

    }

    IEnumerator CarregaScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Home Page");
    }


   
  


// Use this for initialization
void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
