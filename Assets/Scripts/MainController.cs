using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {
	public int floor_amount = 4;
	public GameObject floors_main;
	public GameObject floors_prefab;
	// Use this for initialization
	void Start () {
		createFloors (floor_amount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void createFloors(int amount){
		for(var i = 0;i<amount;i++){
			GameObject floor = Instantiate (floors_prefab) as GameObject;
			floor.transform.SetParent (floors_main.transform,false);
		}
	}
}
