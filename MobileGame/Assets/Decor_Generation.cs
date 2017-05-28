using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decor_Generation : MonoBehaviour {

	public GameObject[] DecorOptions;
	private List<GameObject> AdjacentObjects;
	private bool InitializeDecor = true;
	public int DecorChance;

	// Use this for initialization
	void Start () {
		
						
	}

	void Update(){
		if(InitializeDecor){
			Debug.Log("Actual List : " + this.GetComponent<CubeData>().adjacentCubes.Count);
			AdjacentObjects = this.GetComponent<CubeData>().adjacentCubes;
			CreateDecor();
			InitializeDecor = false;
		}
	}


	private void CreateDecor(){
		if(Random.Range(1,11) <= DecorChance) PlaceDecor(Vector3.forward * 2.0f, 	new Vector3(90.0f, 0.0f, 0.0f));
		if(Random.Range(1,11) <= DecorChance) PlaceDecor(Vector3.back * 2.0f, 		new Vector3(-90.0f, 0.0f, 0.0f));
		if(Random.Range(1,11) <= DecorChance) PlaceDecor(Vector3.up * 2.0f, 		new Vector3(0.0f, 0.0f,0.0f));
		if(Random.Range(1,11) <= DecorChance) PlaceDecor(Vector3.down * 2.0f, 		new Vector3(180.0f, 0.0f, 0.0f));
		if(Random.Range(1,11) <= DecorChance) PlaceDecor(Vector3.right * 2.0f, 		new Vector3(0.0f, 0.0f, -90.0f));
		if(Random.Range(1,11) <= DecorChance) PlaceDecor(Vector3.left * 2.0f, 		new Vector3(0.0f, 0.0f, 90.0f));

		Debug.Log(Vector3.up * 2.0f);

	}

	private GameObject GetDecor(){
		return DecorOptions[Random.Range(0, DecorOptions.Length)];
	}

	private void PlaceDecor(Vector3 Position, Vector3 Rotation){
		bool canPlace = true;

		foreach (GameObject CurrentCube in AdjacentObjects){

			if(CurrentCube.transform.position == this.transform.position + Position){
				canPlace = false;
				break;
			}
		}
		Quaternion Rot = new Quaternion();
		Rot.eulerAngles = Rotation;
		if(canPlace){
			GameObject Decor;
			Decor = Instantiate(GetDecor(), (Position * 0.5f) + this.transform.position, Rot, this.transform); 
			Decor.transform.localScale = new Vector3(Random.Range(0.75f, 1.25f), Random.Range(0.75f, 1.25f), Random.Range(0.75f, 1.25f));

		}
	}

}
