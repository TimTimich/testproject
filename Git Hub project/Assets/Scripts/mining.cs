﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mining : MonoBehaviour {

	public spawn spawnscript;
	public float damage = 10f;
	public float range = 5f;
	public float reset = 0.5f;
	public float firerate = 1f;


	private float nextimetofire=0f;

	public Camera cam;
	public inventory inv;
	// Use this for initialization
	void Start () {
		inv = gameObject.GetComponent<inventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")&&Time.time >= nextimetofire) {
			nextimetofire = Time.time + 1f / firerate;
			RaycastHit hit;
			if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range)) {
				if (hit.transform.CompareTag ("interact")) {
					healthobject hep = hit.transform.GetComponent<healthobject> ();
					Vector2 endhitgive = hep.endreward;
					Vector2 beginhitgive = hep.beginreward;
					GameObject target = hep.target;
					hep.hp -= damage;
					Debug.Log (hep.hp);
					if (hep.hp >= hep.maxhp*(3/4)) {
						
						if (hep.mat == "MatWood") {
							inv.woodcount += Random.Range (endhitgive.x, endhitgive.y);
						} else if (hep.mat == "MatStone") {
							inv.stonecount += Random.Range (endhitgive.x, endhitgive.y);
						}
					}

					else if (hep.hp <= hep.maxhp*(3/4)) {

						if (hep.mat == "MatWood") {
							inv.woodcount += Random.Range (beginhitgive.x, beginhitgive.y);
						} else if (hep.mat == "MatStone") {
							inv.stonecount += Random.Range (beginhitgive.x, beginhitgive.y);
						}
					}
					if (hep.hp <= 0) {
						hep.growing = false;
						Debug.Log ("killed");
						Destroy (target.gameObject);
						//Destroy (hit);
					}

					
					
				}
			}
		}

	}
}

