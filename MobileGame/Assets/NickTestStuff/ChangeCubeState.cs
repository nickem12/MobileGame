using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCubeState : MonoBehaviour {

    Ray touchRay;
    RaycastHit objectHit;

    public Material mat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(touchRay, out objectHit, Mathf.Infinity))
            {
                Debug.Log("Hit Something");

                Debug.Log(objectHit.transform.tag);

                objectHit.transform.gameObject.GetComponent<Renderer>().material = mat;
            }
        }
       

        
	}
}
