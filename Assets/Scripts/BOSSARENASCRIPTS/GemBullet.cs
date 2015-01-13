using UnityEngine;
using System.Collections;

public class GemBullet : MonoBehaviour {

	private GameObject target;
	private GameObject origin;
	private float diff_x;
	private float diff_y;
	private float pos_x;
	private float pos_y;
	private float speed = 2f;
	private Vector3 direction;
	private float timer;
	private Vector3 pos_origin;
	private Vector3 pos_final;
	// Use this for initialization
	void Start () {

		target = GameObject.Find("GemPost_2");
		origin = GameObject.Find("GemPost_1");

	}

	void move_towards_gemPortal(){
	
		pos_origin = origin.transform.position;
		pos_final = target.transform.position;

		float distance = Vector3.Distance (pos_origin, pos_final);

		transform.position =new Vector3 (0.0f, 1.0f) * speed * Time.deltaTime;

	}


//	void standStill() {
//		rigidbody2D.velocity = new Vector3 (0, 0, 0);
//	}

	void OnCollisionEnter2D (Collision2D other){
		
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
	
//		if(Time.time > timer+0.1) {
//			Destroy (gameObject);
//		}

		diff_x =  transform.position.x- target.transform.position.x;
		diff_y = transform.position.y - target.transform.position.y;

		if (diff_x < diff_y && diff_x < 0) {
			rigidbody2D.velocity = Vector3.right;
		} else if (diff_x > diff_y && diff_x > 0) {
			rigidbody2D.velocity = Vector3.left;
		} else if (diff_y < diff_x && diff_y < 0) {
			rigidbody2D.velocity = Vector3.up;
		} else if (diff_y > diff_x && diff_y > 0) {
			rigidbody2D.velocity = Vector3.down;
		}
//
//		if (Mathf.Abs (transform.position.x)>6f || Mathf.Abs (transform.position.y)>6f){
//			Destroy(gameObject);
//		}
	}
}
//		//rigidbody2D.AddForce (direction * speed);

