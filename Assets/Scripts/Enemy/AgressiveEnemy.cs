using UnityEngine;
using System.Collections;

public class AgressiveEnemy : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public Animator animation = null;

	private float distance_to_player;

	float detection_distance = 100f;
	public float MoveSpeed = 1f;
	Vector3 position_player;
	float x_pos;
	float y_pos;
	float x_player_pos;
	float y_player_pos;
	float diff_x;
	float diff_y;

	void Start () {
		animation = GetComponent<Animator> ();
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

		if (dtc_player == true) {

			if(diff_x < diff_y && diff_x < 0){
				transform.Translate (Vector3.right * MoveSpeed * Time.deltaTime);
				animation.Play("Aggressive_E_right");
			}
			else if (diff_x > diff_y && diff_x > 0){
				transform.Translate (Vector3.left * MoveSpeed * Time.deltaTime);
				animation.Play("Aggressive_E_left");
			}
			else if(diff_y < diff_x && diff_y < 0){
				transform.Translate (Vector3.up * MoveSpeed * Time.deltaTime);
				animation.Play("Aggressive_E_up");
			}
			else if(diff_y > diff_x && diff_y > 0){
				transform.Translate (Vector3.down * MoveSpeed * Time.deltaTime);
				animation.Play("Aggressive_E_down");
			}
			else{}

//			position_player = new Vector3(target.transform.position.x,target.transform.position.y,0);
		}
		if (dtc_player == false) {
			transform.Translate (Vector3.down * MoveSpeed * Time.deltaTime);
		}

	}


	// Update is called once per frame
	void Update () {

		distance_between ();
		detect_player ();
		move_enemy ();
	
	}
}
