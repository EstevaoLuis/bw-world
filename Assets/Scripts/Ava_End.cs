using UnityEngine;
using System.Collections;

public class Ava_End : MonoBehaviour {
	public GameObject ava;
	private GameObject gem;
	float timer;
	// Use this for initialization
	void Start () {
	
		gem = GameObject.Find("Crystal");

	}
	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {
			Destroy (ava);
			Instantiate (gem, transform.position-new Vector3(-5,1.1f), transform.rotation);
			Destroy(gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
