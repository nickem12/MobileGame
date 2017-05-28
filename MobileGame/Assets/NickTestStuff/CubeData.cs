using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CubeState { Current, Passable, Unpassable, Passed };

public class CubeData : MonoBehaviour {
    
    public List<GameObject> adjacentCubes = new List<GameObject>();
    [SerializeField]
    public CubeState cubeState;
    [SerializeField]
    int num;
    public float CubeLength;
    bool setAdjacent = true;
	// Use this for initialization
	void Awake () {

        string name = this.name;

        switch(name)
        {
            case "Used(Clone)":
                SetCubeState(CubeState.Current);
                break;
            case "Unused(Clone)":
                SetCubeState(CubeState.Passable);
                break;
            case "Impassable(Clone)":
                SetCubeState(CubeState.Unpassable);
                break;
        }
        num = adjacentCubes.Count;
	}
	
	// Update is called once per frame
	void Update () {
		if(setAdjacent)
        {
            SetAdjacentCubes();
            setAdjacent = false;
        }
	}

    public void SetCubeState(CubeState state)
    {
        cubeState = state;
    }

    void SetAdjacentCubes()
    {
        GameObject[] cube = GameObject.FindGameObjectsWithTag("Cube");

        for(int counter = 0;counter<cube.Length;counter++)
        {
			if(Vector3.Distance(cube[counter].transform.position,this.transform.position)<= CubeLength && cube[counter].gameObject != this.gameObject)
            {
                adjacentCubes.Add(cube[counter]);
            }
        }
    }
}
