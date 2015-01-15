using UnityEngine;
using System.Collections;

public class GemBullet : MonoBehaviour {

	private GameObject target;
	private EnemyController enemy;
	private float speed = 10f;

	// Use this for initialization
	void Start () {

		target = GameObject.Find("GemPost_2");

	}
	void aimTowardsTarget(){

		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime * speed);
	
	}


	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag != "gem") {
			Destroy (gameObject);
		}

		if (other.gameObject.tag == "Enemy") {
			enemy = other.gameObject.GetComponent<EnemyController>();
			int damage = 50 + Random.Range(-5,5);
			enemy.damageEnemy(damage);
			GameInstance.instance.playAnimation("Hit",other.gameObject.transform.position);
			GameInstance.instance.damageValueAnimation(damage,other.gameObject.transform.position);
		}
	
	}

	// Update is called once per frame
	void Update () {

		aimTowardsTarget ();

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


