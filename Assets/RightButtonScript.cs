using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonScript : MonoBehaviour {
	public void OnMouseDrag() {
		DataScript.rightdown = true;
	}
	void OnMouseUp() {
		DataScript.rightdown = false;
		
	}
}
