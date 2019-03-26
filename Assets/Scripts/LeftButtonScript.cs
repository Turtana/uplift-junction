using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButtonScript : MonoBehaviour {
	public void OnMouseDrag() {
		DataScript.leftdown = true;
	}
	void OnMouseUp() {
		DataScript.leftdown = false;
	}
}
