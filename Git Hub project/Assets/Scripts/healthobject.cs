using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthobject : MonoBehaviour {
	public float hp = 100f;
	public float maxhp = 100f;
	public string mat;
	public Vector2 beginreward = new Vector2(1f,1f);
	public Vector2 endreward = new Vector2(5f,6f);
	public GameObject target;
	public  bool growing;
	// Use this for initialization
	void Start () {
		 beginreward = new Vector2(1f,1f);
		 endreward = new Vector2(5f,6f);
		growing = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
