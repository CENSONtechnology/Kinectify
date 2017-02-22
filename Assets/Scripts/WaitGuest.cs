using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WaitGuest : MonoBehaviour
{

    public Button btn;
    public Text count;
    public Image img;
    // Use this for initialization

    IEnumerator Start()
    {
        
        yield return new WaitForSeconds(0f);
        

        for (int i = 1; i <= 5; i++)
        {
            
            int x = i;
            count.text = i.ToString();
            i = x;
            yield return new WaitForSeconds(1f);
            
        }
        btn.interactable = true;
        img.gameObject.SetActive(false);

    }
}

