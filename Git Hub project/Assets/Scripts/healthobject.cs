using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthobject : MonoBehaviour {
	public float hp = 100f;
	public float maxhp = 100f;
	public float beginhp = 1f;
	public string mat;

	public GameObject target;
	public  bool growing;
	// Use this for initialization
	void Start () {

		growing = true;

	}
	
	// Update is called once per frame
	void Update () {

	}
}
