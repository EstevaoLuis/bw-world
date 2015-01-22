using UnityEngine;
using System.Collections;

public class BoxArea : MonoBehaviour {

	public GameObject door = null;
	private bool isActivated = false;
	// Use this for initialization
	void Start () {
	
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Box" && !isActivated) {
			Destroy(door);
			Vector2 aux = new Vector2(transform.position.x,transform.position.y);
			GameInstance.instance.playAudio("Switch2");
			isActivated = true;
		}
	}
}
