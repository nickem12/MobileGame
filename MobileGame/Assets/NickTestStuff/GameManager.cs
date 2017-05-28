using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int cubeRemaining;
    public bool getCubeRemaining = true;
    public bool win = false;
    GameObject puzzle;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update () {

        if (getCubeRemaining)
        {
            GetInitialOpenCubes();
            getCubeRemaining = false;
        }
        if (cubeRemaining == 0)
        {
            win = true;
        }
        else win = false;


        if (win)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else this.transform.GetChild(0).gameObject.SetActive(false);
	}
    public void GetInitialOpenCubes()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        for(int counter =0;counter<cubes.Length;counter++)
        {
            if(cubes[counter].GetComponent<CubeData>().cubeState == CubeState.Passable)
            {
                cubeRemaining++;
            }
        }
    }
}
