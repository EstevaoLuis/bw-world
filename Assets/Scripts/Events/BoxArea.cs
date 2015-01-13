using UnityEngine;
using System.Collections;

public class BoxArea : MonoBehaviour {

	public GameObject door = null;
	// Use this for initialization
	void Start () {
	
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Box") {
			Destroy(door);
			Vector2 aux = new Vector2(transform.position.x,transform.position.y);
			GameInstance.instance.playAudio("Switch2");
		}
	}
}
