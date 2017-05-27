using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisScript : MonoBehaviour {

    public Vector3 up;
    public Vector3 right;
    public Vector3 back;

	// Use this for initialization
	void Start () {
        up = Vector3.up;
        right = Vector3.right;
        back = Vector3.back;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
