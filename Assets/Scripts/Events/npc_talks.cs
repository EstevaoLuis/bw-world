using UnityEngine;
using System.Collections;

public class npc_talks : MonoBehaviour {

	// Use this for initialization
	private GameObject player;
	public string text_to_say;
	float distance_to_talk = 2f;

	void Start () {
	
		player = GameObject.FindGameObjectWithTag("Player");
		//Instantiate(Txt,transform.position,transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {
	
				//guiText.text = "HELLOOOOOOO";
//				
//		Txt = GameObject.FindGameObjectWithTag("Text");

		float dist = Vector3.Distance (player.transform.position, this.transform.position);

		print (dist);

		if (dist < distance_to_talk) {

			this.guiText.enabled = true;
			this.guiText.text = text_to_say;

				} else {
			this.guiText.text = "";
			this.guiText.enabled = false;
			//this.guiText.text = "****";
		}


	}
}


