using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//public Vector2 direction;
	public GameObject cameraSystem;
	public Vector2 triggerDirection;

	private bool isColliding = false;
	private Vector2 movementSpeed;

	// Use this for initialization
	void Start () {
	
	}


	/*
	// Update is called once per frame
	void Update () {
		if (isColliding) {
			cameraSystem.transform.position += new Vector3(movementSpeed.x,movementSpeed.y,0f) * Time.deltaTime;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			isColliding = true;
			movementSpeed = other.gameObject.rigidbody2D.velocity;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			isColliding = false;
		}
	}
	*/

	void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			movementSpeed = other.gameObject.rigidbody2D.velocity;
			PlayerController p = other.gameObject.GetComponent<PlayerController>();

			if((movementSpeed.x!=0 && movementSpeed.y!=0) || (triggerDirection == movementSpeed/p.GetSpeed())) {
				cameraSystem.transform.position += new Vector3(movementSpeed.x,movementSpeed.y,0f) * Time.deltaTime;
			}
		}
	}

}
