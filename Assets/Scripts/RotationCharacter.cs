using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RotationCharacter : MonoBehaviour {

    // Use this for initialization
    
	
        IEnumerator Start()
    {

            yield return new WaitForSeconds(0f);
        
           for(int i = 0; i >= 0; i++) { 
                transform.Rotate(0, i, 0);

                yield return new WaitForSeconds(0.5f);
               
                 }
          

    }

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
