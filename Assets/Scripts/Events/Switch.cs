using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public GameObject door = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			Destroy(door);
			Destroy (this);
			// TODO Animation switch pressed
		}
	}
}
