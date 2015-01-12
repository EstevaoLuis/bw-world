using UnityEngine;
using System.Collections;

public class CloseGate : MonoBehaviour {

	BoxCollider2D collider;
	SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
		renderer = GetComponent<SpriteRenderer> ();
		collider.isTrigger = true;
		renderer.color = new Vector4 (255f,255f,255f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			collider.isTrigger = false;
			renderer.color = new Vector4 (255f,255f,255f,255f);
		}
	}
}
