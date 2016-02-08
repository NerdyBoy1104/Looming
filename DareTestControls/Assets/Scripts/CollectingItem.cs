using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectingItem : MonoBehaviour {
	
	public Text ItemText;
	public GameObject HudText;
	public int NumberItems;
	public GameObject ItemObj;

	// Use this for initialization
	void Start () {
		ItemText = GameObject.Find ("Canvas/Items").GetComponent<Text>();
		HudText = GameObject.Find ("Canvas/PressE");

		HudText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		ItemText.text = "Items: " + NumberItems;

		if (HudText.activeInHierarchy == true) {
			if (Input.GetMouseButtonDown(0)|| Input.GetButtonDown("Fire3")){ // Ckecks if the player is pressing the left mouse button or the X botton on the joypad
//				print ("Working");
				Destroy(ItemObj);
				NumberItems ++;
				ItemObj = null;
				HudText.SetActive (false);
			}
		}

	}

	void OnTriggerEnter(Collider other){
		HudText.SetActive (true);
		ItemObj = other.gameObject;
	}

	void OnTriggerExit(Collider other){
		HudText.SetActive (false);
		ItemObj = null;
		
	}
}
