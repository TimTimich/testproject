using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mining : MonoBehaviour {

	public float damage = 10f;
	public float range = 5f;
	public float reset = 0.5f;

	public Camera cam;
	public inventory inv;
	// Use this for initialization
	void Start () {
		inv = gameObject.GetComponent<inventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			RaycastHit hit;
			if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range)) {
				if (hit.transform.CompareTag ("interact")) {
					health hep = hit.transform.GetComponent<health> ();
					hep.hp -= damage;
					Debug.Log (hep.hp);
					if (hep.mat == "MatWood") {
						inv.woodcount += Random.Range (7, 9);
					}
					else if (hep.mat == "MatStone") {
						inv.stonecount += Random.Range (5, 7);
					}
					if (hep.hp <= 0) {
						Debug.Log ("killed");
						Destroy (hit.collider.gameObject);
						//Destroy (hit);
					}

					
					
				}
			}
		}

	}
}

