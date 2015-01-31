using UnityEngine;
using System.Collections;

public class MovingGear : MonoBehaviour {

	public float period = 3f;
	public float speed = 5f;

	public int damage = 5;
	public Vector2 initialDirection = new Vector2 (1f, 0f);

	private float time = 0f;
	private float hitTime;
	private bool isMoving = false;
	private bool isVertical = false;


	private bool isActive = false;
	public float activationTime = 6f;

	// Use this for initialization
	void Start () {
		Invoke ("activate",activationTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive && Time.time > time + period) {
			rigidbody2D.velocity = new Vector2 (-rigidbody2D.velocity.x, -rigidbody2D.velocity.y);
			time = Time.time;
		}
	}

	private void activate() {
		if (initialDirection.y != 0) isVertical = true;
		rigidbody2D.velocity = initialDirection * speed;
		time = Time.time;
		isActive = true;
	}

	void OnCollisionStay2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			if(Time.time > hitTime + 1f) {
				GameInstance.instance.damagePlayer (damage);
				GameInstance.instance.playAnimation ("Hit", other.gameObject.transform.position);
				hitTime = Time.time;
			}
		}
	}
}
