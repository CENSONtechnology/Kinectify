using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
  
    [SerializeField]
    private InputField UserField = null;
    [SerializeField]
    private InputField PassField = null;
    [SerializeField]
    private Text feedbackmsg = null;
    [SerializeField]
    public Toggle rememberData = null;

    string SellectUserUrl = "localhost/kinectify/conn.php";
    

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("remember") && PlayerPrefs.GetInt("remember") == 1)
        {
            UserField.text = PlayerPrefs.GetString("rememberUser");
            PassField.text = PlayerPrefs.GetString("rememberPass");
        }
    }
    public void BtnLogin()
    {
        if (UserField.text == "" || PassField.text == "")
        {
            FeedBackError("please enter data");
        }
        else
        {
            string username = UserField.text;
            string password = PassField.text;

            if (rememberData.isOn)
            {
                PlayerPrefs.SetInt("remember", 1);
                PlayerPrefs.SetString("rememberUser", username);
                PlayerPrefs.SetString("rememberPass", password);

            }
            WWW www = new WWW(SellectUserUrl + "?user_name=" + username + "&password=" + password);
            StartCoroutine(ValidLogin(www));
        }
    }
   
 
    IEnumerator ValidLogin (WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            if(www.text == "1")
            {
                FeedBackOk("login success");
                StartCoroutine(CarregaScene());
            }
            else
            {
                FeedBackError("username or password invalid");
            }
        }
        else
        {
            if (www.error == "couldn't connect with host")
            {
                FeedBackError("Server Error");
            }
        }
    }

    IEnumerator CarregaScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("LoadingScreen");
    }


    void FeedBackOk(string massage)
    {

        feedbackmsg.CrossFadeAlpha(100f, 0f, false);
        feedbackmsg.color = Color.white;
        feedbackmsg.text = "Login Success";
    }
    void FeedBackError(string message)
    {

        feedbackmsg.CrossFadeAlpha(100f, 0f, false);
        feedbackmsg.color = Color.red;
        feedbackmsg.text = "Login Not Valid";
        UserField.text = "";
        PassField.text = "";
    }

}