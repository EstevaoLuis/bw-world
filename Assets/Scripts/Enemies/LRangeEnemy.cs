using UnityEngine;
using System.Collections;
using SimpleJSON;

public class LRangeEnemy : MonoBehaviour {

	//Enemy name to retrieve parameters
	public string enemyName;
	
	//Parameters
	private int health;
	private int attack;
	private int defense;
	public float speed;
	
	//Spells & Melees
	private JSONNode spells;
	private JSONNode melees;
	
	private float distance_to_player;
	private int counter = 0;
	private int counter_2 =0;
	private int max_fire_rate = 50;
	private int max_move = 30;
	private Vector2 direction;
	
	private float attack_distance = 30;
	
	public float detection_distance = 1000f;
	public GameObject target;
	
	private float deadTime;
	private bool isAlive = true;
	
	public GameObject spell_1;
	public GameObject spell_2;
	public GameObject melee;
	
	float x_pos;
	float y_pos;
	float x_player_pos;
	float y_player_pos;
	float diff_x;
	float diff_y;
	
	int rand;
	
	// Use this for initialization
	void Start () {
		//Get enemy parameters
		JSONNode parameters = GameInstance.instance.getEnemyParameters (enemyName);
		
		//If not found, destroy
		if (parameters == null) Destroy (gameObject);
		
		//Set parameters
		health = parameters ["health"].AsInt;
		attack = parameters ["attack"].AsInt;
		defense = parameters ["defense"].AsInt;
		speed = parameters ["speed"].AsFloat;
		rigidbody2D.mass = parameters ["mass"].AsInt;
		spells = parameters ["spells"];
		melees = parameters ["melees"];
		
		
		rand = random_number ();
		direction = new Vector2(0.0f,-1.0f);
	}
	
	int random_number(){
		int rand = Random.Range (0, 5);
		return rand;
	}
	void movement_random(int r){
		
		//int rand = random_number ();
		
		if (rand == 0) {
			//stay still
		} else if (rand == 1) {
			move_up();			//move_up
		} else if (rand == 2) {
			move_down ();		//move_down
		} else if (rand == 3) {
			move_left();		//move_left		
		} else if (rand == 4) {
			move_right();		//move right
		}
		
	}
	
	void move_up(){
		rigidbody2D.velocity = Vector3.up * speed;
	}
	void move_down(){
		rigidbody2D.velocity = Vector3.down * speed;
	}
	void move_right(){
		rigidbody2D.velocity = Vector3.right * speed;
	}
	void move_left(){
		rigidbody2D.velocity = Vector3.left * speed;
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
	bool detect_player(){
		
		if (distance_between () < detection_distance) {
			return true;		
		} else {
			return false;
		}
	}
	
	int what_quadrant (){
		
		if (transform.position.x > 0 && transform.position.y > 0) {
			return 0;
		} else if (transform.position.x < 0 && transform.position.y > 0) {
			return 1;
		} else if (transform.position.x < 0 && transform.position.y < 0) {
			return 2;		
		} else if (transform.position.x > 0 && transform.position.y < 0) {
			return 3;
		}
		return -1;
	}
	
	
	void run_away(){
		
		int quad = what_quadrant ();
		
		if (quad == 0) {
			if (diff_x > diff_y) {
				move_right ();
			} else {
				move_up ();
			}
		} else if (quad == 1) {
			if (diff_x > diff_y) {
				move_left ();
			} else {
				move_up ();
			}
		} else if (quad == 2) {
			if (diff_x > diff_y) {
				move_left ();
			} else {
				move_down ();	
			}
		} else if (quad == 3) {
			if(diff_x > diff_y){
				move_right();	
			}else{
				move_down();
			}
		}
	}
	
	bool go_into_range(){
		if (distance_between () < attack_distance) {
			run_away ();
			return false;
		} 
		return true;
	}
	
	// Update is called once per frame
	void Update () {

				if (detect_player () == true) {
						go_into_range ();

//		} else {
//
//			if (counter == max_move) {
//				rand = random_number ();
//				counter = 0;
//			}
//			movement_random (rand);
//			counter ++;
//		}

				} else {
			rigidbody2D.velocity = Vector3.up * 0f;
		}
		}
}