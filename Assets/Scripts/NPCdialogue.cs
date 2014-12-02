using UnityEngine;
using System.Collections;

public class NPCdialogue : MonoBehaviour {

	private int count = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag == "Player") {
			GameInstance.text_to_show =  "Hello guy! " + count++;
			//GameInstance.show_text = false;
			//StartCoroutine("textTrue");
		}
	}

	/*IEnumerator textTrue(){
		yield return new WaitForSeconds (2);
		GameInstance.show_text = true;
	}*/


}
