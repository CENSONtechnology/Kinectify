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
    [SerializeField]
    private Text feedbackmsg = null;
    string InsertUrl = "localhost/kinectify/register.php";
    string msgerror;

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

        if (UserInsField.text == "")
        {
            msgerror = "please enter username";
            FeedBackErrror();
        }
        else if (PassInsField.text == "" || confirmField.text == "")
        {
            msgerror = "please enter password";
            FeedBackErrror();
        }
        else if (phoneField.text == "")
        {
            msgerror = "please enter phone";
            FeedBackErrror();
        }
        else if (AgeField.text == "")
        {
            msgerror = "please enter your Age";
            FeedBackErrror();
        }
        else if (genderDD.value == 0)
        {
            msgerror = "please sellect your gender";
            FeedBackErrror();
        }
        else if (EmailField.text == "")
        {
            msgerror = "please enter your Email";
            FeedBackErrror();
        }
        else if (FirstNameField.text == "" || LastNameField.text == "")
        {
            msgerror = "please enter your name";
            FeedBackErrror();
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

            FeedBackOk();
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


   public void FeedBackOk()
    {

       
        feedbackmsg.color = Color.white;
        feedbackmsg.text = "Regesteration Success";
    }
   public  void FeedBackErrror()
    {

        feedbackmsg.CrossFadeAlpha(10f, 0f, false);
        feedbackmsg.color = Color.red;
        feedbackmsg.text = msgerror;

    }


// Use this for initialization
void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
