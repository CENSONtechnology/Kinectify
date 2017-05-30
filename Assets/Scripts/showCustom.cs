using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showCustom : MonoBehaviour {

    public Text Rtxt;
    public Text Ltxt;
    public InputField R;
    public InputField L;

    public void showcustominput()
    {
        Rtxt.gameObject.SetActive(true);
        Ltxt.gameObject.SetActive(true);
        R.gameObject.SetActive(true);
        L.gameObject.SetActive(true);

    }
    public void hidecustominput()
    {
        Rtxt.gameObject.SetActive(false);
        Ltxt.gameObject.SetActive(false);
        R.gameObject.SetActive(false);
        L.gameObject.SetActive(false);

    }

}
