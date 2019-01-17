using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {
	public bool active = false;
	// Use this for initialization
	void LateStart () {
		gameObject.SetActive(active);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			Debug.Log ("down");
			gameObject.SetActive(!active);
		}
	}
}
