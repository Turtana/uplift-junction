using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject customer;
	public int totalscore;
	public int highscore;
	private int totalpeople;
	private GameObject[] spawnDoors;
	public bool gameover;

	public float timer; // 60.0f
	public GameObject timertext;
	private Text timert;
	public GameObject gotext;
	public GameObject gopanel;

	public GameObject scoretext;
	private Text guiscore;
	public GameObject ppmtext;
	private Text guippm;
	public GameObject goingStuff;
	public GameObject overStuff;

	public GameObject finalScore;
	private Text finalScoreT;
	public GameObject finalHigh;
	private Text finalHighT;
	public GameObject finalPeople;
	private Text finalPeopleT;

	public GameObject leftBtn;
	public GameObject rightBtn;
	private LeftButtonScript lscript;
	private RightButtonScript rscript;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
		guiscore = scoretext.GetComponent<Text>();
		guippm = ppmtext.GetComponent<Text>();
		timert = timertext.GetComponent<Text> ();

		finalScoreT = finalScore.GetComponent<Text>();
		finalHighT = finalHigh.GetComponent<Text>();
		finalPeopleT = finalPeople.GetComponent<Text>();

		spawnDoors = GameObject.FindGameObjectsWithTag ("Respawn");

		foreach (GameObject spawn in spawnDoors) {
			Instantiate (customer, new Vector3 (spawn.transform.position.x, spawn.transform.position.y - 1, 0), spawn.transform.rotation);
		}
		gameover = false;
		totalpeople = 0;

		highscore = PlayerPrefs.GetInt ("highscore", highscore);
		lscript = leftBtn.GetComponent<LeftButtonScript>();
		rscript = rightBtn.GetComponent<RightButtonScript>();
	}
	

	void Update () { // Number of people / minute
		if (!gameover) {
			guippm.text = (6 * totalscore / (Time.timeSinceLevelLoad)).ToString ("F2");

			timer -= Time.deltaTime;
			string min = Mathf.Floor (timer / 60).ToString ("00");
			string sec = (timer % 60).ToString ("00");

			timert.text = string.Format ("{0}:{1}", min, sec);
			if (timer < 0f) {
				GameOver();
			}
		} else {
			if(Input.GetKeyDown("r")){
				UnityEngine.SceneManagement.SceneManager.LoadScene ("pc_2e_5f");
			}
		}
		
		if (Input.GetKey("left")) {
			lscript.OnMouseDrag();
		}
		
		if (Input.GetKey("right")) {
			rscript.OnMouseDrag();
		}
	}

	public void AddScore(int score) {
		
		totalscore += score;
		totalpeople += 1;
		timer += 1;
		guiscore.text = totalscore.ToString ();
		if (!gameover) {
			SpawnDude ();
		}
	}

	void GameOver() {
		if (totalscore > highscore) {
			PlayerPrefs.SetInt ("highscore", totalscore);
			finalHighT.text = "High score: " + totalscore.ToString();
		} else {
			finalHighT.text = "High score: " + highscore.ToString();
		}
		gameover = true;
		overStuff.SetActive (true);
		goingStuff.SetActive (false);
		finalScoreT.text = "Your score: " + totalscore.ToString();
		finalPeopleT.text = "People moved: " + totalpeople.ToString();
		Time.timeScale = 0;
	}


	private void SpawnDude () {
		int index = Random.Range (0,10);
		Instantiate (customer, new Vector3 (spawnDoors[index].transform.position.x, spawnDoors[index].transform.position.y - 1, 0), Quaternion.identity);
	}
}
