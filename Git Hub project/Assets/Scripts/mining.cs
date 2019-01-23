using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mining : MonoBehaviour {

	public spawn spawnscript;
	public GameObject healthcavas;
	public Text healthtext;
	public float damage = 10f;
	public float range = 5f;
	public float reset = 0.5f;
	public float firerate = 1f;
	private float nextimetofire=0f;
	public Camera cam;
	public inventory inv;
	public healthobject hep;
	public Image barcloned;
	RaycastHit hit;
	GameObject target;
	Renderer m_Renderer;

	private bool found = false;


	void Start () {
		found = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		


		if (Input.GetButton ("Fire1")&&Time.time >= nextimetofire) {
	
			nextimetofire = Time.time + 1f / firerate;

			if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range)) {
				if (hit.transform.CompareTag ("interact")) {
					
					spawnscript = hit.transform.parent.transform.parent.GetComponent<spawn> ();
					print (barcloned.transform.name);
					hep = hit.transform.GetComponent<healthobject> ();
					m_Renderer = hit.transform.GetComponent<MeshRenderer> ();
					Vector2 endhitgive = spawnscript.endreward;
					Vector2 beginhitgive = spawnscript.beginreward;
					target = hep.target;
					found = true;
					hep.hp -= damage;

					Debug.Log (hep.hp);
					healthtext.text= "" + Mathf.Ceil(hep.hp)+"/" + hep.maxhp;
					barcloned.fillAmount = hep.hp/ hep.maxhp;
					if (hep.hp >= hep.maxhp*(2/4)) {
						
						if (hep.mat == "MatWood") {
							inv.woodcount += Random.Range (endhitgive.x, endhitgive.y);
						} else if (hep.mat == "MatStone") {
							inv.stonecount += Random.Range (endhitgive.x, endhitgive.y);
						}
					}

					else if (hep.hp <= hep.maxhp*(2/4)) {

						if (hep.mat == "MatWood") {
							inv.woodcount += Random.Range (beginhitgive.x, beginhitgive.y);
						} else if (hep.mat == "MatStone") {
							inv.stonecount += Random.Range (beginhitgive.x, beginhitgive.y);
						}
					}
					if (hep.hp > 0) {
						healthtext.text= "" + Mathf.Ceil(hep.hp)+"/" + hep.maxhp;
						barcloned.fillAmount = hep.hp/ hep.maxhp;
						print (spawnscript.killed);
					}
					else{

					if (hep.hp <= 0) {
						spawnscript.killed = true;
						found = false;
						hep.growing = false;
						print (spawnscript.killed);

						Debug.Log ("killed");
						Destroy (target.gameObject);
						//Destroy (hit);
					}

					
					
				}
			}
		}

	}

			if (found==true) {
				if (spawnscript.killed == false) {
					print ("false");
					if (m_Renderer.isVisible) {
						if (Vector3.Distance (cam.transform.position, target.transform.position) < 15f) {
							var guiPosition = Camera.main.WorldToScreenPoint (hit.transform.position-new Vector3(0,hit.transform.localScale.y*5f,0));
							healthcavas.transform.GetChild (0).transform.position = guiPosition;
							healthcavas.SetActive (true);
						} else {
							healthcavas.SetActive (false);
						}
					}
					else {
						print ("not visible");
						healthcavas.SetActive (false);
					}


				} 

			}
		else if (found == false) {
			healthcavas.SetActive (false);
			print ("not found");
		}

	}
}
