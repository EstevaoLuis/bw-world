using UnityEngine;
using System.Collections;

public class FakePlayer : MonoBehaviour {

	public float speed = 5f;

	private float lastMovement;
	private Vector2 direction;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > lastMovement + Random.Range(1f,2f)) {
			int randomDirection = Random.Range (0,4);
			if (randomDirection == 0) {
				stopMovement ();
			} else if (randomDirection == 1) {
				moveUp ();			//move_up
			} else if (randomDirection == 2) {
				moveDown ();		//move_down
			} else if (randomDirection == 3) {
				moveLeft ();		//move_left		
			} else if (randomDirection == 4) {
				moveRight ();		//move right
			}
		}
	}

	public void moveDown() {
			animator.Play ("WalkDown");
			direction = new Vector2 (0.0f, -1.0f);
			//Vector2 newVelocity = direction * speed;
			//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
			rigidbody2D.velocity = direction * speed;
			lastMovement = Time.time;
	}
	public void moveUp() {
			animator.Play ("WalkUp");
			direction = new Vector2 (0.0f, 1.0f);
			//Vector2 newVelocity = direction * speed;
			//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
			rigidbody2D.velocity = direction * speed;
			lastMovement = Time.time;
	}
	public void moveLeft() {
			animator.Play ("WalkLeft");
			direction = new Vector2 (-1.0f, 0.0f);
			//Vector2 newVelocity = direction * speed;
			//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
			rigidbody2D.velocity = direction * speed;
			lastMovement = Time.time;
	}
	public void moveRight() {
			animator.Play ("WalkRight");
			direction = new Vector2 (1.0f, 0.0f);
			//Vector2 newVelocity = direction * speed;
			//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
			rigidbody2D.velocity = direction * speed;
			lastMovement = Time.time;
	}
	public void stopMovement() {
		Vector2 newVelocity = new Vector2 (0, 0);
		//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
		rigidbody2D.velocity = newVelocity;
		lastMovement = Time.time;
	}
}
