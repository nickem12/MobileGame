using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGenerationBehavior : MonoBehaviour {

	public int Impassible_Likelyhood;

	public GameObject[] ImpassableBlocks;
	public GameObject[] UnusedBlocks;
	public GameObject[] UsedBlocks;

	public float BlockLength;
	public bool DEBUG;

    public int Seed;
    public GameObject Ship;

    private GameObject ChosenCube;

    
	void Start () {
		GeneratePuzzle(GenerateSeed());																			//Generate a level
	}
	

	void Update () {
		if(DEBUG){
			if(Input.GetKeyDown(KeyCode.G)){
				DeleteCubes();
				GeneratePuzzle(GenerateSeed());																		//Generate a world based on a generate seed
			}
		}
        if(ChosenCube != null)
        {
            Destroy(ChosenCube);
        }
	}


	public void GeneratePuzzle(int Seed){
		Random.InitState(Seed);																													//Set the seed of the random object

		CreateCentres();																														//Create the centres
		FillTop();																																//Fill in the tops
		FillBottom();																															//Fill in the bottoms
		FillSides();																															//Fill in the sides
		PickStart();
	}

	private void CreateCentres(){
		Instantiate(GenerateCube(), new Vector3(0,1 * BlockLength,0), 	Quaternion.identity, this.transform);										//Up cube
		Instantiate(GenerateCube(), new Vector3(0,-1 * BlockLength,0),  Quaternion.identity, this.transform);										//Down cube

		Instantiate(GenerateCube(), new Vector3(1 * BlockLength,0,0),  Quaternion.identity, this.transform);										//Right cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength,0,0), Quaternion.identity, this.transform);										//Left cube

		Instantiate(GenerateCube(), new Vector3(0,0,1 * BlockLength),  Quaternion.identity, this.transform);										//forward
		Instantiate(GenerateCube(), new Vector3(0,0,-1 * BlockLength), Quaternion.identity, this.transform);										//Backward

		GameObject Core = Instantiate(ImpassableBlocks[Random.Range(0, ImpassableBlocks.Length - 1)], this.transform.position, Quaternion.identity, this.transform);	//This is the core. No gameplay mechanics as to why we need it, need
		Core.GetComponent<Decor_Generation>().enabled = false;																																				//it for a quick fix for the ship, otherwise will spawn inside planet.
		Core.GetComponent<CubeData>().isCore = true;
	}

	private void FillTop(){
		Instantiate(GenerateCube(), new Vector3(1 * BlockLength,1 * BlockLength,0),                     Quaternion.identity, this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength,1 * BlockLength,0),                    Quaternion.identity, this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3(0 ,1 * BlockLength,1 * BlockLength),                    Quaternion.identity, this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(0 ,1 * BlockLength,-1 * BlockLength),                   Quaternion.identity, this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3(1 * BlockLength ,1 * BlockLength, 1 * BlockLength),     Quaternion.identity, this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength ,1 * BlockLength, 1 * BlockLength),    Quaternion.identity, this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3(1 * BlockLength ,1 * BlockLength, -1 * BlockLength),    Quaternion.identity, this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength ,1 * BlockLength, -1 * BlockLength),   Quaternion.identity, this.transform);		//Up cube

	}

	private void FillBottom(){
		Instantiate(GenerateCube(), new Vector3(1 * BlockLength,-1 * BlockLength,0),                    Quaternion.identity, this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength,-1 * BlockLength,0),                   Quaternion.identity, this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3(0 ,-1 * BlockLength,1 * BlockLength),                   Quaternion.identity, this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(0 ,-1 * BlockLength,-1 * BlockLength),                  Quaternion.identity, this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3(1 * BlockLength ,-1 * BlockLength, 1 * BlockLength),    Quaternion.identity, this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength ,-1 * BlockLength, 1 * BlockLength),   Quaternion.identity, this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3(1 * BlockLength ,-1 * BlockLength, -1 * BlockLength),   Quaternion.identity, this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength ,-1 * BlockLength, -1 * BlockLength),  Quaternion.identity, this.transform);		//Up cube

	}

	private void FillSides(){
		Instantiate(GenerateCube(), new Vector3( 1 * BlockLength, 0 , 1 * BlockLength),                     Quaternion.identity, this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength, 0 , 1 * BlockLength),                     Quaternion.identity, this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3( 1 * BlockLength, 0 ,-1 * BlockLength),                     Quaternion.identity, this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength, 0 ,-1 * BlockLength),                     Quaternion.identity, this.transform);		//Up cube

	}

	private void PickStart(){
		GameObject[] Cubes = GameObject.FindGameObjectsWithTag("Cube");

		do{
			ChosenCube = Cubes[Random.Range(0, Cubes.Length - 1)];
		}while(ChosenCube.GetComponent<CubeData>().isCore);

		GameObject Start = Instantiate(GetUsed(), ChosenCube.transform.position, Quaternion.identity, this.transform);              //Up cube
        Destroy(ChosenCube);
        SetShip(Start);
    }

	private GameObject GenerateCube(){
		int Type = Random.Range(1,11);																		//Generate what type of block we want

		if(Type <= Impassible_Likelyhood){
			return ImpassableBlocks[Random.Range(0, ImpassableBlocks.Length - 1)];
		}
		else{
			return UnusedBlocks[Random.Range(0, UnusedBlocks.Length - 1)]; 
		}
		return null;
	}

	private GameObject GetUsed(){
		return UsedBlocks[Random.Range(0, UsedBlocks.Length - 1)]; 
	}

	private int GenerateSeed(){
		Seed = (int)Random.Range(-1000, 1000);
		if(DEBUG) Debug.Log("Seed value : " + Seed);															//For testing, print out the seed
		return Seed;
	}

	public void DeleteCubes(){
		GameObject[] Cubes = GameObject.FindGameObjectsWithTag("Cube");
		for(int CurBlock = Cubes.Length - 1; CurBlock >= 0; CurBlock--){
			Destroy(Cubes[CurBlock]);
		}
	}

	public void SetShip(GameObject StartCube){
		GameObject[] AllCubes = GameObject.FindGameObjectsWithTag("Cube");
		Vector3 Dir = Vector3.zero;
		Vector3 Rotation = Vector3.zero;


		for(int CurrentDirection = 0; CurrentDirection < 6; CurrentDirection++){

			switch(CurrentDirection){
				case 0:
					Dir = Vector3.forward;
					Rotation = new Vector3(90.0f, 0.0f, 0.0f);
					break;
				case 1:
					Dir = Vector3.back;
					Rotation = new Vector3(-90.0f, 0.0f, 0.0f);
					break;
				case 2:
					Dir = Vector3.up;
					Rotation = new Vector3(0.0f, 0.0f, 0.0f);
					break;
				case 3:
					Dir = Vector3.down;
					Rotation = new Vector3(180.0f, 0.0f, 0.0f);
					break;
				case 4:
					Dir = Vector3.left;
					Rotation = new Vector3(0.0f, 0.0f, -90.0f);
					break;
				case 5:
					Dir = Vector3.right;
					Rotation = new Vector3(0.0f, 0.0f, 90.0f);
					break;
			}
			bool DirClear = true;

			foreach(GameObject CurCube in AllCubes){
				if(CurCube.transform.position == StartCube.transform.position + (Dir * BlockLength)) DirClear = false;
			}

			if(DirClear){
				CreateShip(StartCube.transform.position + (Dir * BlockLength * 0.5f), Rotation, StartCube); 
				break;
			}
		}

	}

	private void CreateShip(Vector3 position, Vector3 Rotation, GameObject StartCube){
		Quaternion Rot = new Quaternion();
		Rot.eulerAngles = Rotation;
		Instantiate(Ship, position, Rot, StartCube.transform);
	}

}
