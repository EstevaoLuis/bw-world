using UnityEngine;
using System.Collections;

public class GemBullet : MonoBehaviour {

	private GameObject target;
	private GameObject origin;
	private EnemyController enemy;
	private float diff_x;
	private float diff_y;
	private float pos_x;
	private float pos_y;
	private float speed = 10f;
	private float timer = 2f;
	private float timer_2 = 8f;
	private Vector3 direction;
	private Vector3 pos_origin;
	private Vector3 pos_final;
	private int lifes = 5;

	// Use this for initialization
	void Start () {

		target = GameObject.Find("GemPost_2");
		origin = GameObject.Find("GemPost_1");

	}
	void aimTowardsTarget(){
		
		diff_x = transform.position.x - target.transform.position.x;
		diff_y = transform.position.y - target.transform.position.y;
		
		if (diff_x < diff_y && diff_x < 0) {
			direction += new Vector3(1,0);
		} else if (diff_x > diff_y && diff_x > 0) {
			direction += new Vector3(-1,0);
		} else if (diff_y < diff_x && diff_y < 0) {
			direction += new Vector3(0,1);
		} else if (diff_y > diff_x && diff_y > 0) {
			direction += new Vector3(0,-1);
		}
	}


	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag != "gem") {
			Destroy (gameObject);
		}

		if (other.gameObject.tag == "Enemy") {
			enemy = other.gameObject.GetComponent<EnemyController>();
			enemy.damageEnemy(50);
		}
	
	}

	// Update is called once per frame
	void Update () {
		aimTowardsTarget ();
//			if (Time.time > timer) {
			direction.Normalize ();
			rigidbody2D.velocity = direction * speed;
//				timer = timer + 2f;
//			}
		}
//		}
//		if(transform.position.x == transform.position.x + 0.5f || transform.position.y == transform.position.y + 0.5f){
//			Destroy(gameObject);
//		}

	
//		if(Time.time > timer_2) {
//			Destroy (gameObject);
//			timer_2 = timer_2 + 8;
//		}
				


//		diff_x =  transform.position.x- target.transform.position.x;
//		diff_y = transform.position.y - target.transform.position.y;
//
//		if (diff_x < diff_y && diff_x < 0) {
//			rigidbody2D.velocity = Vector3.right;
//		} else if (diff_x > diff_y && diff_x > 0) {
//			rigidbody2D.velocity = Vector3.left;
//		} else if (diff_y < diff_x && diff_y < 0) {
//			rigidbody2D.velocity = Vector3.up;
//		} else if (diff_y > diff_x && diff_y > 0) {
//			rigidbody2D.velocity = Vector3.down;
//		}
//

	}


