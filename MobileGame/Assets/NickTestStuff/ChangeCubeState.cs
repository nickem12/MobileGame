using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCubeState : MonoBehaviour {

    Ray touchRay;
    RaycastHit objectHit;

    public Material mat;

    GameObject currentCube;
    GameObject gameManager;
	// Use this for initialization
	void Start () {

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
	}
	
	// Update is called once per frame
	void Update () {


        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Debug.Log("Cast Ray");
            if (Physics.Raycast(touchRay, out objectHit, Mathf.Infinity))
            {
                if(objectHit.transform.GetComponent<CubeData>().cubeState == CubeState.Passable)
                {
                    Debug.Log("Hit Passable object.");
                    GetCurrentCube();
                    if(Adjacent(objectHit.transform.gameObject))
                    {
                        Debug.Log("Hit Something adjacent to current cube.");

                        Debug.Log(objectHit.transform.tag);

                        objectHit.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = mat;

                        objectHit.transform.GetComponent<CubeData>().SetCubeState(CubeState.Current);

                        currentCube.GetComponent<CubeData>().SetCubeState(CubeState.Passed);

                        gameManager.GetComponent<GameManager>().cubeRemaining-= 1;
                    }
                }
            }
        } 
	}

    void GetCurrentCube()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        for(int counter = 0; counter<cubes.Length;counter++)
        {
            if(cubes[counter].GetComponent<CubeData>().cubeState == CubeState.Current)
            {
                currentCube = cubes[counter];
                return;
            }
        }
    }
    bool Adjacent(GameObject test)
    {
        for(int counter = 0;counter<currentCube.GetComponent<CubeData>().adjacentCubes.Count;counter++)
        {
            if(test == currentCube.GetComponent<CubeData>().adjacentCubes[counter])
            {
                return true;
            }
        }
        return false;
    }
}
