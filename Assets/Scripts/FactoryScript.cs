using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryScript : MonoBehaviour {
	public float delay;
	private float timer;
	public GameObject product;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < delay) {
			timer += Time.deltaTime;
		} else {
			timer = 0;
			Instantiate (product, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), transform.rotation);
		}
	}

}
