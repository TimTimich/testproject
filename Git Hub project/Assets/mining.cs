using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mining : MonoBehaviour {

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
					Vector2 hitgive = hep.reward;
					hep.hp -= damage;
					Debug.Log (hep.hp);
					if (hep.mat == "MatWood") {
						inv.woodcount += Random.Range (hitgive.x,hitgive.y);
					}
					else if (hep.mat == "MatStone") {
						inv.stonecount += Random.Range (hitgive.x,hitgive.y);
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

