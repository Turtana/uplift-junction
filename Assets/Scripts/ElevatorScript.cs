using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {
	public int align; // Align -1 left or 1 right
	public float speed;
	public float shaft_height;
	public int floor_number;
	public string upcode;
	public string downcode;
	public bool singleElevator;

	private bool moving;

	private float floor1height, floor2height, floor3height, floor4height, floor5height;
	private float limit1, limit2, limit3, limit4;

	private GameObject gameController;
	private GameController gamescript;

	// Use this for initialization
	void Start () {
		floor1height = -21f;
		floor2height = -10.5f;
		floor3height = 0;
		floor4height = 10.5f;
		floor5height = 21f;

		limit4 = (floor5height + floor4height) / 2; // snap limits
		limit3 = (floor4height + floor3height) / 2;
		limit2 = (floor3height + floor2height) / 2;
		limit1 = (floor2height + floor1height) / 2;

		moving = false;

		gameController = GameObject.Find ("GameController");
		gamescript = gameController.GetComponent<GameController> ();
	}

	void Update () {

	}

	void FixedUpdate () {
		if (DataScript.leftdown && DataScript.rightdown) {
			return;
		}

		if (!gamescript.gameover) {
			if (DataScript.leftdown) {
				moving = true;
				floor_number = 0;
				gameObject.transform.Translate (speed * Vector3.up * align);
			} else if (DataScript.rightdown) {
				moving = true;
				floor_number = 0;
				gameObject.transform.Translate (speed * Vector3.down * align);
			} else {
				moving = false;
				// Neither left nor right button pressed
				float ypos = gameObject.transform.position.y;
				if (ypos > limit4) {
					moveToHeight (floor5height);
					floor_number = 5;
				} else if (ypos > limit3) {
					moveToHeight (floor4height);
					floor_number = 4;
				} else if (ypos > limit2) {
					moveToHeight (floor3height);
					floor_number = 3;
				} else if (ypos > limit1) {
					moveToHeight (floor2height);
					floor_number = 2;
				} else {
					moveToHeight (floor1height);
					floor_number = 1;
				}
			}
		}

		if (Input.GetKey ("escape")) {
			Application.Quit ();
		}

		// Boundaries
		if (gameObject.transform.position.y > shaft_height) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, shaft_height, gameObject.transform.position.z);
			return;
		}
		if (gameObject.transform.position.y < -shaft_height) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, -shaft_height, gameObject.transform.position.z);
			return;
		}


	}

	void moveToHeight (float height) {
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x, height, gameObject.transform.position.z);
	}

	public bool checkMoving() {
		return moving;
	}
}
