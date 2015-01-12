using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//public Vector2 direction;
	public GameObject cameraSystem;
	public Vector2 triggerDirection;

	private BoxCollider2D collider;
	private float correctDistance;

	private bool isColliding = false;
	private Vector2 movementSpeed;

	private PlayerController player;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
		/*
		if (triggerDirection == new Vector2 (0f, 1f)) {
			correctDistance = transform.position.y - cameraSystem.transform.position.y - 1f - 1.25f; //collider.bounds.size.y / 2
			//Debug.DrawLine(transform.position, cameraSystem.transform.position, Color.green);
			Debug.Log (correctDistance);
		}
		*/
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
	}
	

	void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {

			movementSpeed = other.gameObject.rigidbody2D.velocity;

			if(/*(movementSpeed.x!=0 && movementSpeed.y!=0) ||*/ (triggerDirection == movementSpeed/player.GetSpeed())) {
				cameraSystem.transform.position += new Vector3(movementSpeed.x,movementSpeed.y,0f) * Time.deltaTime;
			}

			/*
			if((movementSpeed.x!=0 && movementSpeed.y!=0) || (triggerDirection == movementSpeed / player.GetSpeed())) {
				cameraSystem.transform.position = new Vector3(cameraSystem.transform.position.x, other.transform.position.y - correctDistance , 0f);
			}

			Debug.Log(cameraSystem.transform.position);
			*/
		}
	}

	/*
	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isColliding = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isColliding = false;
		}
	}

	void LateUpdate() {
		if (isColliding) {
			movementSpeed = player.rigidbody2D.velocity;
			if((movementSpeed.x!=0 && movementSpeed.y!=0) || (triggerDirection == movementSpeed / player.GetSpeed())) {
				cameraSystem.transform.position += new Vector3(movementSpeed.x,movementSpeed.y,0f) * Time.deltaTime;
			}
		}
	}
	*/
}
