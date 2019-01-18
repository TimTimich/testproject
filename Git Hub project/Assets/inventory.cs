using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour {
	public int woodcount=0;
	public int stonecount=0;
	public Text stoneText;
	public Text woodText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		woodText.text = ""+ woodcount;
		stoneText.text = ""+ stonecount;
	}
}
