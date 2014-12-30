using UnityEngine;
using System.Collections;

public class SnakeMovement : MonoBehaviour {

	// Use this for initialization
	public GameObject Target;
	private Vector2 direction;
	public float speed;
	private float speed_2 = 200;
	private float distance;
	private float diff_x;
	private float diff_y;


	void Start () {
	
		//Target = GameObject.FindGameObjectWithTag("Player");



	}

	void moveTowardsTarget(){

		diff_x = transform.position.x - Target.transform.position.x;
		diff_y = transform.position.y - Target.transform.position.y;
		
		if (diff_x < diff_y && diff_x < 0) {
				moveRight ();
		} else if (diff_x > diff_y && diff_x > 0) {
				moveLeft ();
		} else if (diff_y < diff_x && diff_y < 0) {
				moveUp ();
		} else if (diff_y > diff_x && diff_y > 0) {
				moveDown ();
		}
//		} else {
//			standStill();
//		}
		
	}

	void moveUp(){
		direction = new Vector2 (0.0f, 1.0f);
		rigidbody2D.velocity = Vector3.up * speed;
	}
	void moveDown(){
		direction = new Vector2 (0.0f, -1.0f);
		rigidbody2D.velocity = Vector3.down * speed;
	}
	void moveRight(){
		direction = new Vector2 (1.0f, 0.0f);
		rigidbody2D.velocity = Vector3.right * speed;
	}
	void moveLeft(){
		direction = new Vector2 (-1.0f, 0.0f);
		rigidbody2D.velocity = Vector3.left * speed;
	}
	void standStill() {
		rigidbody2D.velocity = new Vector3 (0, 0, 0);
	}

	void OnCollisionEnter2D(Collision2D other){

		if(other.gameObject != Target){

			if (direction == new Vector2 (0.0f, 1.0f)) {
				rigidbody2D.velocity = Vector3.down * speed_2;
			}
			if (direction == new Vector2 (0.0f, -1.0f)) {
				rigidbody2D.velocity = Vector3.up * speed_2;
			}
			if (direction == new Vector2 (1.0f, 0.0f)) {
				rigidbody2D.velocity = Vector3.left * speed_2;
			}
			if (direction == new Vector2 (-1.0f, 0.0f)) {
				rigidbody2D.velocity = Vector3.right * speed_2;
			}
		}
	}


	
	// Update is called once per frame
	void Update () {
	
		moveTowardsTarget ();

	}
}
