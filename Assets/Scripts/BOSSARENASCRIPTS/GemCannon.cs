using UnityEngine;
using System.Collections;

public class GemCannon : MonoBehaviour {

	public GameObject bullet;
	private GameObject target;
	private float diff_x;
	private float diff_y;
	private float speed = 2f;
	private float timer = 0.5f;
	private Vector3 direction;
	// Use this for initialization
	void Start () {
		target = GameObject.Find("GemPost_2");
	}
	Vector3 compute_startshot(){
		diff_x = transform.position.x - target.transform.position.x;
		diff_y = transform.position.y - target.transform.position.y;

		if (diff_x < diff_y && diff_x < 0) {
				return new Vector3 (1, 0);
		} else if (diff_x > diff_y && diff_x > 0) {
				return new Vector3 (-1, 0);
		} else if (diff_y < diff_x && diff_y < 0) {
				return new Vector3 (0, 1);
		} else if (diff_y > diff_x && diff_y > 0) {
				return new Vector3 (0, -1);
		} else {
				return new Vector3 (0, 0);
		}
	}

	// Update is called once per frame
	void Update () {

		direction += compute_startshot ();
		if (Time.time > timer) {
			direction.Normalize();
			Instantiate (bullet, direction+transform.position, transform.rotation);
			timer = timer + 0.5f;
		}
//		bullet.rigidbody2D.velocity = Vector3.right * speed;
		//shoot_to_other_portal ();
	
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Spell") {
				//Spell spell = other.gameObject.GetComponent("Spell") as Spell;
				GameInstance.instance.playAnimation ("Hit", gameObject.transform.position);
		}
	}

}

