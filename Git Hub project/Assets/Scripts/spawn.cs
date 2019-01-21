using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

	public GameObject tospawn;
	GameObject clonedversion;
	public MeshRenderer leaves;
	public Vector3 maxgrowscale;
	public Vector3 leavesallowed;
	public float leavesint;
	public float growrate = 0.0001f;
	public Vector3 offset = new Vector3 (0, 2, 0);
	[SerializeField]
	public float xstart, ystart, zstart;

	// Use this for initialization
	void Start () {
		maxgrowscale = new Vector3(0.2f,0.2f,0.2f);
		leavesint = maxgrowscale.x * (2 / 5);
		leavesallowed = new Vector3(0.2f,leavesint,0.2f);
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		xstart = tospawn.transform.localScale.x / 5f;
		ystart = tospawn.transform.localScale.y / 5f;
		zstart = tospawn.transform.localScale.z / 5f;


		clonedversion = Instantiate(tospawn, gameObject.transform.position+offset, gameObject.transform.rotation);
		clonedversion.transform.localScale = new Vector3 (xstart, ystart, zstart);
		leaves = clonedversion.GetComponent<MeshRenderer> ();
		leaves.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(clonedversion.transform.localScale.x < maxgrowscale.x)
		{
			clonedversion.transform.localScale += new Vector3 (growrate*Time.deltaTime, growrate*Time.deltaTime, growrate*Time.deltaTime);
			clonedversion.transform.position += new Vector3 (0f,growrate*0.35f,0f);
			if (clonedversion.transform.localScale.x > leavesallowed.x) {
				leaves.enabled = true;
			}
		}
	}

}