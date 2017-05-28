using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int cubeRemaining;
    public bool getCubeRemaining = true;
    public bool win = false;
    GameObject puzzle;
    float resetTimer = 2f;

    public Material mat;
    private GameObject theCamera;
    private Vector3 beginingPos;
    private bool lerpToBeginingTrigger;
    private float timer;
    private float speed;

    void Start()
    {
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");
        beginingPos = new Vector3(0, 0, 48.788f);
        timer = 3f;
        speed = 2f;
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
        //else this.transform.GetChild(0).gameObject.SetActive(false);


        if(lerpToBeginingTrigger)
        {
            theCamera.transform.position = Vector3.Lerp(theCamera.transform.position, beginingPos, Time.deltaTime);
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                lerpToBeginingTrigger = false;
            }
        }

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

    public void Continue()
    {
        puzzle = GameObject.FindGameObjectWithTag("Puzzle");
        puzzle.GetComponent<PuzzleGenerationBehavior>().DeleteCubes();
        puzzle.GetComponent<PuzzleGenerationBehavior>().GeneratePuzzle((int)Random.Range(-1000, 1000));
        getCubeRemaining = true;

        lerpToBeginingTrigger = true;
    }

    public void RestartLevel()
    {
        Debug.Log("Restart");
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        for (int counter = 0; counter < cubes.Length; counter++)
        {
            if (cubes[counter].GetComponent<CubeData>().cubeState == CubeState.Passed || cubes[counter].GetComponent<CubeData>().cubeState == CubeState.Current)
            {
                if(cubes[counter].GetComponent<CubeData>().start)
                {
                    cubes[counter].GetComponent<CubeData>().cubeState = CubeState.Current;
                    Debug.Log("reset Start position");
                }
                else
                {
                    cubes[counter].GetComponent<CubeData>().cubeState = CubeState.Passable;
                    cubes[counter].transform.GetChild(0).gameObject.GetComponent<Renderer>().material = mat;
                    Debug.Log("Reset the passed blocks");
                }
            }
        }
        getCubeRemaining = true;

    }
}
