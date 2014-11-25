using UnityEngine;
using System.Collections;

public class AgressiveEnemy : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public Animator animation = null;
	public GameObject attack;
	GameObject aux;

	private float distance_to_player;
	private bool isHit = false;
	//private float hitTime;

	float detection_distance = 100f;
	public float MoveSpeed = 1f;
	Vector3 position_player;
	float x_pos;
	float y_pos;
	float x_player_pos;
	float y_player_pos;
	float diff_x;
	float diff_y;
	float hitTime;
	float attack_range = 3f;


	void Start () {
		animation = GetComponent<Animator> ();
	//	attack = GetComponent<Animator> ();
	}

	float distance_between(){

		x_pos = transform.position.x;
		y_pos = transform.position.y;

		x_player_pos = target.transform.position.x;
		y_player_pos = target.transform.position.y;

		diff_x = x_pos - x_player_pos;
		diff_y = y_pos - y_player_pos;

		return Mathf.Sqrt ((diff_x) * (diff_x) + (diff_y) * (diff_y));

	}

	bool detect_player (){

		distance_to_player = distance_between ();

		if (distance_to_player < detection_distance) {
			return true;

		}
		return false;
	}


	void move_enemy(){

		bool dtc_player = detect_player();

		if (!isHit) {
				if (dtc_player == true) {

						if (diff_x < diff_y && diff_x < 0) {
								//transform.Translate (Vector3.right * MoveSpeed * Time.deltaTime);
								animation.Play ("Aggressive_E_right");
								rigidbody2D.velocity = Vector3.right * MoveSpeed;
						} else if (diff_x > diff_y && diff_x > 0) {
								//transform.Translate (Vector3.left * MoveSpeed * Time.deltaTime);
								animation.Play ("Aggressive_E_left");
								rigidbody2D.velocity = Vector3.left * MoveSpeed;
						} else if (diff_y < diff_x && diff_y < 0) {
								//transform.Translate (Vector3.up * MoveSpeed * Time.deltaTime);
								animation.Play ("Aggressive_E_up");
								rigidbody2D.velocity = Vector3.up * MoveSpeed;
						} else if (diff_y > diff_x && diff_y > 0) {
								//transform.Translate (Vector3.down * MoveSpeed * Time.deltaTime);
								animation.Play ("Aggressive_E_down");
								rigidbody2D.velocity = Vector3.down * MoveSpeed;
						} else {
								rigidbody2D.velocity = new Vector3 (0, 0, 0);
						}

						//			position_player = new Vector3(target.transform.position.x,target.transform.position.y,0);
				} else {
						transform.Translate (Vector3.down * MoveSpeed * Time.deltaTime);
				}
		} else if(Time.time > hitTime+0.8f) {
			isHit = false;
		}


	}
	bool enemy_in_range(){
		distance_to_player = distance_between ();
		if (distance_to_player < attack_range) {
						return true;

				} else {
						return false;
				}
	}

	// Update is called once per frame
	void Update () {
	
		if (enemy_in_range() && Time.time > hitTime + 1) {
			aux = (GameObject) Instantiate (attack,target.transform.position,Quaternion.identity);
			hitTime = Time.time;

		}
		if (aux != null && Time.time > hitTime + 0.7) {
			Destroy(aux);
		}
		distance_between ();
		detect_player ();
		move_enemy ();
	
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Spell") {
			isHit = true;
			hitTime = Time.time;
		}
	}

}
