using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

	public void PlayGame (int i)
	{
		Time.timeScale = 1;
		if (i == 1) {
			SceneManager.LoadScene("pc_2e_5f");
		} else if (i == 2) {
			SceneManager.LoadScene("pc_1e_5f");
		} else {
			SceneManager.LoadScene("main_menu");
		}
	}
}
