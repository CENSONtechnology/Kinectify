using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosingFromPlayScene : MonoBehaviour
{


    public Button Hair;
    public Button Toilet;
    public Button btnHR;
    public Button btnHL;
    public Button btnTR;
    public Button btnTL;
    public Button btnback;


    public void chooseHair()
    {
        btnHL.gameObject.SetActive(true);
        btnHR.gameObject.SetActive(true);
        btnback.gameObject.SetActive(true);

        Toilet.gameObject.SetActive(false);

    }
    public void chooseToilet()
    {
        btnTL.gameObject.SetActive(true);
        btnTR.gameObject.SetActive(true);
        btnback.gameObject.SetActive(true);

        Hair.gameObject.SetActive(false);

    }
    public void back()
    {
        btnTL.gameObject.SetActive(false);
        btnTR.gameObject.SetActive(false);
        btnHL.gameObject.SetActive(false);
        btnHR.gameObject.SetActive(false);
        btnback.gameObject.SetActive(false);
        Toilet.gameObject.SetActive(true);
        Hair.gameObject.SetActive(true);
    }
   

   

}   
