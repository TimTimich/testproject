using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour {

	[Header("Wood Types")]
	public float woodcount=0f;
	public float woodbirch=0f;
	public float woodoak=0f;



	[Header("Stone Types")]
	public float stonecount=0f;


	[Header("Text")]
	public Text stoneText;
	public Text woodText;
	public Text moneyText;

    [Header("Extra")]
    public GameObject panel;
    public GameObject background;
    private GameObject[] slot;
    public cameracontroller camscipt;
    public bool inventoryenabled;
    public float moneycount = 0f;


    // Use this for initialization
    void Start () {
        background.SetActive(false);
        camscipt = gameObject.GetComponent<cameracontroller>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("down");
            background.SetActive(!background.activeSelf);
            camscipt.enabled = !camscipt.enabled;

        }
        else if (background.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        woodText.text = ""+ Mathf.Round(woodcount);
		stoneText.text = ""+ Mathf.Round(stonecount);
	}

}

