using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenres : MonoBehaviour {
    public bool pmode;
    // Use this for initialization
	void Start () {
        Debug.Log("Asdf");
        if(pmode)
            Screen.SetResolution(720,720, false);
        else 
            Screen.SetResolution(1920, 720, false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
