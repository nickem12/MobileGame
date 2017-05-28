using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int cubeRemaining;
    public bool getCubeRemaining = true;
    public bool win = false;
    GameObject puzzle;
    float resetTimer = 2f;

    void Start()
    {
        puzzle = GameObject.FindGameObjectWithTag("Puzzle");
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
            resetTimer -= Time.deltaTime;
        }
        else this.transform.GetChild(0).gameObject.SetActive(false);

        if(resetTimer <= 0)
        {
            puzzle.GetComponent<PuzzleGenerationBehavior>().DeleteCubes();
            puzzle.GetComponent<PuzzleGenerationBehavior>().GeneratePuzzle((int)Random.Range(-1000,1000));
            getCubeRemaining = true;
            resetTimer = 2f;
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
}
