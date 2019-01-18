﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Popup : MonoBehaviour {
	public GameObject panel;
	public cameracontroller camscipt;

	void Start () {
		panel.SetActive (!panel.activeSelf);
		camscipt = gameObject.GetComponent<cameracontroller> ();
		//Cursor.visible = false;
		}	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			Cursor.lockState = CursorLockMode.None  ;
			Cursor.visible = true;
			Debug.Log ("down");
			panel.SetActive (!panel.activeSelf);
			camscipt.enabled = !camscipt.enabled;

		} else if (camscipt.enabled == true) {
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = false;
		}
			

	}
}
