using UnityEngine;
using System.Collections;

public class Ava_Starts : MonoBehaviour {
	public GameObject door;
	public GameObject avalanche;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D (Collision2D other){

		if (other.gameObject.tag == "Player") {
			Destroy(door);
			Destroy(avalanche.rigidbody2D);
			Destroy(gameObject);

		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
