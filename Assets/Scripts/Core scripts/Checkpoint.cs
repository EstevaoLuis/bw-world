using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
		
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			GameInstance.instance.checkpoint();
		}
	}

}
