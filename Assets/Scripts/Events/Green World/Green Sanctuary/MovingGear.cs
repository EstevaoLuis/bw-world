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

	// Use this for initialization
	void Start () {
		if (initialDirection.y != 0) isVertical = true;
		rigidbody2D.velocity = initialDirection * speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > time + period) {
			rigidbody2D.velocity = new Vector2 (-rigidbody2D.velocity.x, -rigidbody2D.velocity.y);
			time = Time.time;
		}
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
