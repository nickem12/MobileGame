using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimation : MonoBehaviour {

    private GameObject UIButtonFunctions;

	// Use this for initialization
	void Start () {
        UIButtonFunctions = GameObject.FindGameObjectWithTag("UIButtonFunctions");
	}
	
	// Update is called once per frame
	void Update () {
		
        if(UIButtonFunctions.GetComponent<UIButtonFunctions>().startedGame)
        {
            Debug.Log("Hit");
        }

	}
}
