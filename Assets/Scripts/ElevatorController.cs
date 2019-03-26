using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {
	public float speed = 1.0f;//how fast? from 1-100
	public float placingspeed = 1.0f;
	public int height = 1;//how many floors use with elevator?
	public GameObject elevator_box;
	public bool placed = false;

	private SpriteRenderer sprRend;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		
	}

	void FixedUpdate () {
		if(!placed){
			if(Input.GetKeyDown ("right")){
				gameObject.transform.Translate (Vector2.right * 10);
				elevator_box.transform.Translate (Vector2.right * 10);
			}
			else if(Input.GetKeyDown ("left")){
				gameObject.transform.Translate (Vector2.left * 10);
				elevator_box.transform.Translate (Vector2.left * 10);
			}
			else if(Input.GetKeyDown ("up")){
				gameObject.transform.Translate (Vector2.up * 10);
				elevator_box.transform.Translate (Vector2.up * 10);
			}
			else if(Input.GetKeyDown ("down")){
				gameObject.transform.Translate (Vector2.down * 10);
				elevator_box.transform.Translate (Vector2.down * 10);
			}
		}
		if(!placed && Input.GetKeyDown("space")){

			Debug.Log ("PLACED ELEVATOR");
			placed = true;
			GameObject elevbox = Instantiate (elevator_box) as GameObject;
			elevbox.transform.position = gameObject.transform.position;
			elevbox.transform.position += new Vector3(0,-45.0f,0); 
		}
	}
		
}