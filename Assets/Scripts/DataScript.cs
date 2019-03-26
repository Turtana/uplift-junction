using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataScript : MonoBehaviour {

	public static bool elevatorsConnected;
	public static bool singleLift;

	public static bool leftdown;
	public static bool rightdown;

	// Use this for initialization
	void Start () {
		elevatorsConnected = true;
		singleLift = false;

		leftdown = false;
		rightdown = false;
	}
}
