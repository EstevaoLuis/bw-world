using UnityEngine;
using System.Collections;

public class NPCdialogue : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag == "Player") {
			GameInstance.text_to_show =  "Hello guy!";
			GameInstance.show_text =true;
		}
	}


}
