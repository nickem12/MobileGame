using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimation : MonoBehaviour {

    private GameObject UIButtonFunctions;
    private Animator anim;
    private bool float_up_limit;

	// Use this for initialization
	void Start () {
        UIButtonFunctions = GameObject.FindGameObjectWithTag("UIButtonFunctions");
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void TriggerFloatUp() {
        anim.SetTrigger("float_up");
    }
}
