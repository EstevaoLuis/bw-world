using UnityEngine;
using System.Collections;

public class ImprovedEnemies : MonoBehaviour {

	private float attack;
	private float defense; 
	private float distance_to_player;
	private int counter = 0;
	private int counter_2 =0;
	private int max_fire_rate = 50;
	private int max_move = 30;
	private Vector2 direction;

	public float detection_distance = 1000f;
	public float speed = 100f;
	public GameObject target;

	public int life;
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

	float distance_between(){
		
		x_pos = transform.position.x;
		y_pos = transform.position.y;
		
		x_player_pos = target.transform.position.x;
		y_player_pos = target.transform.position.y;
		
		diff_x = x_pos - x_player_pos;
		diff_y = y_pos - y_player_pos;
		
		return Mathf.Sqrt ((diff_x) * (diff_x) + (diff_y) * (diff_y));
		
	}
	int choose_attack(){

		float distance = distance_between ();

		if (distance > 2.5 && distance < 10) {

			return 1;

		} else if (distance > 15 ) {

			return 0;		

		} else {

			return -1;
		}
	}
	void attacking(){



		if (choose_attack () == 1) {
		//spell 1
			generate_spell_1();
		} else if (choose_attack () == 0) {
		//spell 2
			generate_spell_2();
		} else if (choose_attack () == -1) {
		//melee
			generate_melee();
		}

	}
	int position_of_target_respect_enemy(){

		if (diff_x < diff_y) {

			return 1;
		}
			return 0;

	}


	void generate_spell_1(){

		GameObject attack;
		attack=(GameObject)Instantiate(spell_1,new Vector3(transform.position.x+direction.x,transform.position.y+direction.y,0),transform.rotation);

	}
	
	void generate_spell_2(){
		
		GameObject attack;
		attack=(GameObject)Instantiate(spell_2,new Vector3(transform.position.x+direction.x,transform.position.y+direction.y,0),transform.rotation);
		
	}
	void generate_melee(){
		
		GameObject attack;
		attack=(GameObject)Instantiate(melee,new Vector3(transform.position.x+direction.x,transform.position.y+direction.y,0),transform.rotation);
		
	}

	bool detect_player (){
		
		distance_to_player = distance_between ();
		
		if (distance_to_player < detection_distance) {
			return true;
			
		}
		return false;
	}

	void move_towards_player(){

		if (diff_x < diff_y && diff_x < 0) {
			direction = new Vector2 (1.0f, 0.0f);
			rigidbody2D.velocity = Vector3.right * speed;
		} else if (diff_x > diff_y && diff_x > 0) {
			direction = new Vector2 (-1.0f, 0.0f);
			rigidbody2D.velocity = Vector3.left * speed;

		} else if (diff_y < diff_x && diff_y < 0) {
			direction = new Vector2 (0.0f, 1.0f);
			rigidbody2D.velocity = Vector3.up * speed;
		
		} else if (diff_y > diff_x && diff_y > 0) {
			direction = new Vector2 (0.0f, -1.0f);
			rigidbody2D.velocity = Vector3.down * speed;


		} else {
			//rigidbody2D.velocity = Vector3.left * speed;
			rigidbody2D.velocity = new Vector3 (0, 0, 0);
		}

	}

	int random_number(){
		int rand = Random.Range (0, 5);
		print (rand);
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

//	void Collision (Collider col){
//		if (col.ta == true) {
//			life--;		
//		}
//
//	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Spell") {
			life--;
			if(life == 0){
				Destroy(gameObject);
			}
		}
	}
//	void collision_detected(){
//		if (this.collider2D != true) {
//						print ("hit!!!");
//				}
//	}
//	void OnTriggerEnter (BoxCollider other){
//		life--;
//		if (life == 0) {
//			Destroy(this);
//		}
//	}
			
	// Use this for initialization
	void Start () {
		rand = random_number ();
		direction = new Vector2(0.0f,-1.0f);
		//Physics.IgnoreCollision(Spell_1Enemy.collider, collider);
	}
	
	// Update is called once per frame
	void Update () {

		if (detect_player () != true) {
			if (counter == max_move) {
				rand = random_number ();
				counter = 0;
			}
			movement_random (rand);
			//print (counter);
			counter++;

		} else {

			move_towards_player ();

		}
		//collision_detected ();
//		Collision (this.collider);
//		Death_of_Enemy ();
		if (counter_2 == max_fire_rate) {
			//attacking ();
		
			attacking ();

			counter_2=0;
		} else {
			counter_2++;
		}
	}
}


	

