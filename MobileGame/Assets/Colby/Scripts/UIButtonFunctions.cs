using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonFunctions : MonoBehaviour {

    private GameObject theCanvas;
    private GameObject theCamera;
    public float cameraMovementScalar;

	// Use this for initialization
	void Start () {
        theCanvas = GameObject.FindGameObjectWithTag("Canvas");
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(theCamera.transform.position);
	}

    public void NewGame()
    {
        theCanvas.GetComponent<Canvas>().enabled = false;
        Vector3 startingPos = theCamera.transform.position;
        Vector3 endPos = new Vector3(0, 23, -24);
        theCamera.transform.position = Vector3.Lerp(startingPos, endPos, Time.deltaTime * cameraMovementScalar);
    }
}
