using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SplashScoreScript : MonoBehaviour
{
	private float timer;
	private TextMeshPro tmp;
	
    // Start is called before the first frame update
    void Awake()
    {
        tmp = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
		transform.localScale += Time.deltaTime * Vector3.one;
		if (timer > 1) {
			Destroy(gameObject);
		}
    }
	
	public void setScore(string score) {
		tmp.SetText("+ " + score);
	}
}
