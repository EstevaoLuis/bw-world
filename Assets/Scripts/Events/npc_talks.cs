using UnityEngine;
using System.Collections;

public class npc_talks : MonoBehaviour {

	// Use this for initialization
	private GameObject player;
	public string text_to_say;
	private GUIText txt;
	float dist;
	float distance_to_talk = 2f;

	void Start () {
	
		player = GameObject.FindGameObjectWithTag("Player");
	  

	}
	void OnGUI() {

		dist = Vector3.Distance (player.transform.position, this.transform.position);

		if (dist < distance_to_talk) {

			GUI.Label (new Rect (this.transform.position.x, this.transform.position.y, 100, 100), text_to_say);

		}

		//GUI.TextField(new Rect (this.transform.position.x, this.transform.position.y, 100, 100), "");	

	}
	
	// Update is called once per frame
	void Update () {
	
				//guiText.text = "HELLOOOOOOO";
//				
//		Txt = GameObject.FindGameObjectWithTag("Text");

		print (dist);

//			this.guiText.enabled = true;
//			this.guiText.text = text_to_say;
//
//				} else {
//			this.guiText.text = "";
//			this.guiText.enabled = false;
//		
	}
}


