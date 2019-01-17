using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
	public float speed = 70f;
	[Range(1,10)]
	public float jump;
	public float fallm=2.5f;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			Debug.Log ("pressed");
			rb.velocity = Vector3.up * jump;
		}

		float translation = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;
		float strafe = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		transform.Translate (strafe, 0, translation);
	}
}
