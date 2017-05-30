using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defultbutton : MonoBehaviour {

    public InputField low;
    public InputField high;

    public void setdefult()
    {
        low.text = "50";
        high.text = "170";
    }

}
