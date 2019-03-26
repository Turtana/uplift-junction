using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
	public Dropdown modeMenu;
	private AudioSource beep;

	void Awake() {
		beep = GetComponent<AudioSource> ();
	}

	public void SettingsView ()
	{
		beep.Play ();
		SceneManager.LoadScene("pc_2e_5f");
		/*
		if (modeMenu.value == 0) {
			DataScript.elevatorsConnected = true;
			DataScript.singleLift = false;
			SceneManager.LoadScene("pc_2e_5f");
		} else if (modeMenu.value == 1) {
			DataScript.singleLift = true;
			SceneManager.LoadScene("pc_1e_5f");
		} else {
			DataScript.elevatorsConnected = false;
			DataScript.singleLift = false;
			SceneManager.LoadScene("pc_2e_5f");
		}
		*/
	}
	
	void Update() {
		if (Input.GetKey ("escape")) {
			Application.Quit ();
		}
	}
}