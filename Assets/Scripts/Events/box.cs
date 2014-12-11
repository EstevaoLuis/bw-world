using UnityEngine;
using System.Collections;

public class box : MonoBehaviour {

	int counter = 0;
	int max_counter = 10;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Box") {
			this.rigidbody2D.isKinematic = false;
			//this.rigidbody2D.mass = 100;
			//this.rigidbody2D.fixedAngle = false;
		}
		//this.rigidbody2D.AddForce(Vector2.up*0);
	
	}

	// Update is called once per frame
	void Update () {
	
		if (counter == max_counter) {
			this.rigidbody2D.isKinematic = true;
			counter=0;
		}
		counter++;
	}
}
