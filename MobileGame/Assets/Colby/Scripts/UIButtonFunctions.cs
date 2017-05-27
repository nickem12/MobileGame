using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonFunctions : MonoBehaviour {

    private GameObject theCanvas;
    private GameObject lockingCanvas;
    private GameObject theCamera;
    public GameObject gyroControls;
    private Quaternion holdRotation;
    //public float cameraMovementScalar;
    private bool moveCameraTrigger;
    Vector3 startingPos;
    Vector3 endPos;
    private float timer = .7f;
    // Use this for initialization
    void Start () {
        theCanvas = GameObject.FindGameObjectWithTag("Canvas");
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");
        lockingCanvas = GameObject.FindGameObjectWithTag("LockingCanvas");
        startingPos = theCamera.transform.position;
        endPos = new Vector3(0, 0, -13.2f);
    }
	
	// Update is called once per frame
	void Update () {
       if(moveCameraTrigger)
       {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                moveCameraTrigger = false;
            }
            MoveCamera();
       }
	}

    public void NewGame()
    {
        theCanvas.GetComponent<Canvas>().enabled = false;
        lockingCanvas.GetComponent<Canvas>().enabled = true;
        moveCameraTrigger = true;
    }

    public void MoveCamera()
    {
        theCamera.transform.position = Vector3.Lerp(theCamera.transform.position, endPos, Time.deltaTime);
        
    }

    public void LockRotation()
    {
        if(gyroControls.GetComponent<GyroControl>().gyroEnabled == true)
        {
            gyroControls.GetComponent<GyroControl>().gyroEnabled = false;
        }
        else
        {
            gyroControls.GetComponent<GyroControl>().gyroEnabled = true;
            
        }
    }
}
