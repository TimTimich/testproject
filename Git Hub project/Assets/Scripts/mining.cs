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
	public GameObject clonedversion;
	private bool exists = false;
	private float nextimetofire=0f;
	public Camera cam;
	public inventory inv;
	public healthobject hep;
	public Image barcloned;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		


		if (Input.GetButton ("Fire1")&&Time.time >= nextimetofire) {
	
			nextimetofire = Time.time + 1f / firerate;
			RaycastHit hit;
			if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range)) {
				if (hit.transform.CompareTag ("interact")) {
					if (exists==false) {
						exists = true;
						clonedversion = Instantiate (healthcavas);

					}
					clonedversion.transform.SetParent (hit.transform);
					clonedversion.transform.localPosition = new Vector3 (0, 0, 0);
					clonedversion.transform.LookAt (cam.transform.position);
					clonedversion.transform.Translate (Vector3.forward * 1.5f);
					spawnscript = hit.transform.parent.transform.parent.GetComponent<spawn> ();
					barcloned = clonedversion.transform.GetChild (0).transform.GetChild(0).GetComponent<Image>();
					print (barcloned.transform.name);
					hep = hit.transform.GetComponent<healthobject> ();
					Vector2 endhitgive = spawnscript.endreward;
					Vector2 beginhitgive = spawnscript.beginreward;
					GameObject target = hep.target;
					hep.hp -= damage;
					Debug.Log (hep.hp);
					clonedversion.GetComponentInChildren<Text>().text= "" + Mathf.Ceil(hep.hp)+"/" + hep.maxhp;
					clonedversion.GetComponentInChildren<Image>().fillAmount = hep.hp/ hep.maxhp;
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
						clonedversion.GetComponentInChildren<Text>().text= "" + Mathf.Ceil(hep.hp)+"/" + hep.maxhp;
						clonedversion.GetComponentInChildren<Image>().fillAmount = hep.hp/ hep.maxhp;
					}
					else{
						clonedversion.transform.position = new Vector3 (0, 0, 0);

					if (hep.hp <= 0) {
						spawnscript.killed = true;
						hep.growing = false;

						Debug.Log ("killed");
							exists = false;
						Destroy (target.gameObject);
						//Destroy (hit);
					}

					
					
				}
			}
		}

	}
		if (clonedversion != null) {
			clonedversion.GetComponentInChildren<Text>().text= "" + Mathf.Ceil(hep.hp)+"/" + hep.maxhp;
			barcloned.fillAmount = hep.hp/hep.maxhp;
			clonedversion.transform.LookAt (cam.transform.position);
			clonedversion.transform.localPosition = new Vector3 (0, -6f, 0);
			clonedversion.transform.Translate (Vector3.forward * 1f);
		}
}
}
