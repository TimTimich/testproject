using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour {
	public float woodcount=0f;
	public float stonecount=0f;
	public float moneycount=0f;
	public Text stoneText;
	public Text woodText;
	public Text moneyText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		woodText.text = ""+ Mathf.Round(woodcount);
		stoneText.text = ""+ Mathf.Round(stonecount);
	}
}
