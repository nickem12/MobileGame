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
		Instantiate(GenerateCube(), new Vector3(0,1 * BlockLength,0), 	new Quaternion(), this.transform);										//Up cube
		Instantiate(GenerateCube(), new Vector3(0,-1 * BlockLength,0), 	new Quaternion(), this.transform);										//Down cube

		Instantiate(GenerateCube(), new Vector3(1 * BlockLength,0,0), 	new Quaternion(), this.transform);										//Right cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength,0,0), 	new Quaternion(), this.transform);										//Left cube

		Instantiate(GenerateCube(), new Vector3(0,0,1 * BlockLength), 	new Quaternion(), this.transform);										//forward
		Instantiate(GenerateCube(), new Vector3(0,0,-1 * BlockLength), 	new Quaternion(), this.transform);										//Backward
	}

	private void FillTop(){
		Instantiate(GenerateCube(), new Vector3(1 * BlockLength,1 * BlockLength,0), 					new Quaternion(), this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength,1 * BlockLength,0), 					new Quaternion(), this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3(0 ,1 * BlockLength,1 * BlockLength), 					new Quaternion(), this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(0 ,1 * BlockLength,-1 * BlockLength), 					new Quaternion(), this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3(1 * BlockLength ,1 * BlockLength, 1 * BlockLength), 	new Quaternion(), this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength ,1 * BlockLength, 1 * BlockLength),	new Quaternion(), this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3(1 * BlockLength ,1 * BlockLength, -1 * BlockLength), 	new Quaternion(), this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength ,1 * BlockLength, -1 * BlockLength), 	new Quaternion(), this.transform);		//Up cube

	}

	private void FillBottom(){
		Instantiate(GenerateCube(), new Vector3(1 * BlockLength,-1 * BlockLength,0), 					new Quaternion(), this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength,-1 * BlockLength,0), 					new Quaternion(), this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3(0 ,-1 * BlockLength,1 * BlockLength), 					new Quaternion(), this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(0 ,-1 * BlockLength,-1 * BlockLength), 					new Quaternion(), this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3(1 * BlockLength ,-1 * BlockLength, 1 * BlockLength), 	new Quaternion(), this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength ,-1 * BlockLength, 1 * BlockLength),	new Quaternion(), this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3(1 * BlockLength ,-1 * BlockLength, -1 * BlockLength), 	new Quaternion(), this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength ,-1 * BlockLength, -1 * BlockLength), 	new Quaternion(), this.transform);		//Up cube

	}

	private void FillSides(){
		Instantiate(GenerateCube(), new Vector3( 1 * BlockLength, 0 , 1 * BlockLength), 					new Quaternion(), this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength, 0 , 1 * BlockLength), 					new Quaternion(), this.transform);		//Up cube

		Instantiate(GenerateCube(), new Vector3( 1 * BlockLength, 0 ,-1 * BlockLength), 					new Quaternion(), this.transform);		//Up cube
		Instantiate(GenerateCube(), new Vector3(-1 * BlockLength, 0 ,-1 * BlockLength), 					new Quaternion(), this.transform);		//Up cube

	}

	private void PickStart(){
		GameObject[] Cubes = GameObject.FindGameObjectsWithTag("Cube");
		GameObject ChosenCube = Cubes[Random.Range(0, Cubes.Length - 1)];
		Instantiate(GetUsed(), ChosenCube.transform.position, 	new Quaternion(), this.transform);              //Up cube
        Destroy(ChosenCube);
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
		int Seed = (int)Random.Range(-1000, 1000);
		if(DEBUG) Debug.Log("Seed value : " + Seed);															//For testing, print out the seed
		return Seed;
	}

	public void DeleteCubes(){
		GameObject[] Cubes = GameObject.FindGameObjectsWithTag("Cube");
		for(int CurBlock = Cubes.Length - 1; CurBlock >= 0; CurBlock--){
			Destroy(Cubes[CurBlock]);
		}
	}

}
