using UnityEngine;
using System.Collections;

public class BlueTrigger : MonoBehaviour {

	public GameObject spawner;
	public Vector3 coordinates;
	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {
			Instantiate (spawner,coordinates, transform.rotation);
			Destroy(gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
