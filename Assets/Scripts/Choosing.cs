using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choosing : MonoBehaviour {

    public Button btnMale, btnFemale;
    public Camera choosingCam;
    public Camera cameraUI;
    public Camera cameraMale;
    public Camera cameraFemale;


    public void choosingCamera(Button btn)
    {

        if (btn == btnMale)
        {
            choosingCam.gameObject.SetActive(false);
            cameraUI.gameObject.SetActive(true);
            cameraMale.gameObject.SetActive(true);
        }
        else if (btn == btnFemale)
        {
            choosingCam.gameObject.SetActive(false);

            cameraUI.gameObject.SetActive(true);
            cameraFemale.gameObject.SetActive(true);
        }

    }
	
}
