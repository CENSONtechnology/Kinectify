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
    public Toggle rememberData = null;
    [SerializeField]
    public Text feedbackmsg=null;
    UISampleWindow pop = new UISampleWindow();
    public string[] items;
    string SellectUserUrl = "localhost/kinectify/NewLogin.php";
    public string myid;
    public static string valid;
    public string text;
    public string myidint;

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
            pop.loginfail1();
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
            WWW www = new WWW(SellectUserUrl + "?UserName=" + username + "&Password=" + password);
            StartCoroutine(ValidLogin(www));
        }
    }
   
 
    IEnumerator  ValidLogin (WWW www)
    {
        yield return www;
        string itemsDataString = www.text;
        print(itemsDataString);
        items = itemsDataString.Split(';');
        valid = GetDataValue(items[0], "Validation:");
        myid = GetDataValue(items[0], "UserID:");
        print(myid);

        GetMyID.LoginID = myid;
    
       
        



        //System.IO.File.WriteAllText(@"D:new.txt", myid);
        print("Validation : "+valid);
        if (www.error == null)
        {
            if(valid == "1")
            {
                
                FeedBackdone("login success");
                StartCoroutine(CarregaScene());
                
            }
            else
            {
                pop.loginfail2();
                UserField.text = "";
                PassField.text = "";
            }
        }
        else
        {
            if (www.error == "couldn't connect with host")
            {
                pop.serverError();
            }
        }
    }

    

    IEnumerator CarregaScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Category");
    }
  


    void FeedBackdone(string message)
    {

        feedbackmsg.CrossFadeAlpha(100f, 0f, false);
        feedbackmsg.color = Color.green;
        feedbackmsg.text = "Sucsess Login";
       
    }
    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }

}
