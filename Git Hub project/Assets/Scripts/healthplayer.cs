using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthplayer : MonoBehaviour {

	public float maxhealth = 100;
	public float currenthealth = 100;
	public Image healthbar;
	public Text healthcount;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		healthbar.fillAmount = currenthealth / maxhealth;
		healthcount.text = "" + Mathf.Round (currenthealth);
	}
}
