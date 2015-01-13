using UnityEngine;
using System.Collections;

public class GemCannon : MonoBehaviour {

	public GameObject bullet;
	private float speed = 2f;
	private float timer = 2f;
	// Use this for initialization
	void Start () {
		Instantiate (bullet, transform.position, transform.rotation);
	}
	void OnCollisionEnter2D (Collision2D other){

		Destroy (bullet);
	
	}
	// Update is called once per frame
	void Update () {

		bullet.rigidbody2D.velocity = Vector3.right * speed;
		//shoot_to_other_portal ();
	
	}
}
