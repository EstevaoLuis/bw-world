using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {

	private bool heart_lock = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player" && !heart_lock) {
			//Destroy(gameObject);
			heart_lock = true;
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<PolygonCollider2D>().enabled = false;
			//playAnAnimation TODO
			GameInstance.instance.regenerateAllHealth();
			GameInstance.instance.regenerateAllMana();
			Destroy(gameObject);
		}
	}
}
