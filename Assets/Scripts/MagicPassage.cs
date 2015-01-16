using UnityEngine;
using System.Collections;

public class MagicPassage : MonoBehaviour {

	public string level_name;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			Application.LoadLevel(level_name);
			GameInstance.instance.movePlayer(new Vector3(-220,-359,0));
			GameInstance.instance.moveCamera(new Vector3(-220,-359,0));
		}
	}
}