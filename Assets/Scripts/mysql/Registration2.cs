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
    
    string InsertUrl = "localhost/kinectify/register.php";
    

    // Use this for initialization
    //void Start()
    //{
    //    if (PlayerPrefs.HasKey("remember") && PlayerPrefs.GetInt("remember") == 1)
    //    {
    //        UserInsField.text = PlayerPrefs.GetString("rememberUser");
    //        PassInsField.text = PlayerPrefs.GetString("rememberPass");
    //        confirmField.text = PlayerPrefs.GetString("rememberconfirm");
    //        phoneField.text = PlayerPrefs.GetString("rememberphone");
    //        AgeField.text = PlayerPrefs.GetString("rememberage");
    //        genderDD.value = PlayerPrefs.GetInt("remembergender");
    //        FirstNameField.text = PlayerPrefs.GetString("rememberfirstname");
    //        LastNameField.text = PlayerPrefs.GetString("rememberlastname");
    //        NotesField.text = PlayerPrefs.GetString("remembernotes");
    //    }
    //}
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
        else if (NotesField.text == "")
        {
            Ui.Notes();
        }



        else
        {
            string username = UserInsField.text;
            string password = PassInsField.text;
            string confirm = confirmField.text;
            string phone = phoneField.text;
            string age = AgeField.text;
            int gender = genderDD.value;
            string firstname = FirstNameField.text;
            string lastname = LastNameField.text;
            string notes = NotesField.text;
            string email = EmailField.text;
            WWW www = new WWW(InsertUrl + "?user_name=" + username + "&password=" + password + "&ConfirmPassword=" + confirm + "&Phone=" + phone + "&Age=" + age + "&Gender=" + gender + "&Email=" + email
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
