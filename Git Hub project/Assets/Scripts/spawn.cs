using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {
	public healthobject healthscript;
	public float totalhp;
	public GameObject tospawn;
	public GameObject clonedversion;
	public GameObject clonedtrunk;
	public MeshRenderer leaves;
	public Vector3 maxgrowscale;
	public Vector3 leavesallowed;
	public float growrate = 0.0001f;
	private bool allowregenrate = true;
	[SerializeField]
	public bool killed = false;
	private Quaternion quaternion;
	private bool started = false;

	public Vector2 beginreward = new Vector2(1f,1f);
	public Vector2 endreward = new Vector2(5f,6f);

	public Vector3 offset = new Vector3 (0, 1f, 0);
	[SerializeField]
	private float xstart, ystart, zstart;


	// Use this for initialization
	IEnumerator Start () {
		started = true;
		allowregenrate = true;
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		yield return new WaitForSeconds(Random.Range(5,30));
		
		killed = false;

		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		xstart = tospawn.transform.localScale.x*2;
		ystart = tospawn.transform.localScale.y*2;
		zstart = tospawn.transform.localScale.z*2;


		clonedversion = Instantiate(tospawn, gameObject.transform.position+offset, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
		clonedversion.transform.SetParent(gameObject.transform,true);
		clonedversion.transform.localScale = new Vector3 (xstart, ystart, zstart);
		healthscript = clonedversion.GetComponentInChildren<healthobject> ();
		leaves = clonedversion.GetComponent<MeshRenderer> ();
		leaves.enabled = false;
		healthscript.hp = 1f;
		totalhp = healthscript.maxhp;
		healthscript.hp = totalhp/100;
		beginreward = new Vector2(1f,1f);
		endreward = new Vector2(5f,6f);
		started = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (started != true) {
			if (killed == false) {
				if (healthscript.growing == true) {
					clonedversion.transform.Rotate (0, 100f * Time.deltaTime, 0);
					if (clonedversion.transform.localScale.x < maxgrowscale.x) {
						if (allowregenrate == true) {
							if (healthscript.hp < totalhp) {
								healthscript.hp += growrate*2/5;
							} else {
								allowregenrate = false;

							}
						}
						//print(healthscript.hp);
						healthscript.growing = true;
						clonedversion.transform.localScale += new Vector3 (growrate * Time.deltaTime, growrate * Time.deltaTime, growrate * Time.deltaTime);
						clonedversion.transform.position += new Vector3 (0f, growrate * 0.03f, 0f);
						if (clonedversion.transform.localScale.x > leavesallowed.x) {
							leaves.enabled = true;
						}
					} else if (clonedversion.transform.localScale.x > maxgrowscale.x) {
						
						healthscript.growing = false;

					}
				} else if (healthscript.growing == false) {
					
				}
			} else {
				StartCoroutine (Test ());


			}
			killed = false;
		}




	}

	IEnumerator Test()
	{
		
		print ("wait has started");
		StopCoroutine (Test());
		yield return new WaitForSeconds (Random.Range(1,1));
		print ("wait has ended");
		StartCoroutine (Start());

	}



	

}