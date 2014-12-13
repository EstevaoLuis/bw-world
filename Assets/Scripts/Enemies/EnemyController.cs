using UnityEngine;
using System.Collections;
using SimpleJSON;

public class EnemyController : MonoBehaviour {

	//Enemy name to retrieve parameters
	public string enemyName;

	//Animator
	private Animator animator;

	//Parameters
	private int health;
	private int attack;
	private int defense;
	private float speed;
	private int experience;
	private float detectionDistance;

	//Spells & Melees
	private JSONNode spells;
	private JSONNode melees;

	private float distance_to_player;
	private int counter = 0;
	private int counter_2 =0;
	private int max_fire_rate = 50;
	private int max_move = 30;
	private Vector2 direction;

	private float colliderRadius;
	
	private GameObject target;

	private float deadTime;
	private bool isAlive = true;

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

		//Animator
		animator = GetComponent<Animator> () as Animator;

		//Collider
		BoxCollider2D collider = GetComponent<BoxCollider2D> () as BoxCollider2D;
		colliderRadius = Mathf.Max (collider.size.x, collider.size.y);

		//Set up target
		target = GameObject.FindGameObjectWithTag ("Player");

		//Set parameters
		health = parameters ["health"].AsInt;
		attack = parameters ["attack"].AsInt;
		defense = parameters ["defense"].AsInt;
		speed = parameters ["speed"].AsFloat;
		rigidbody2D.mass = parameters ["mass"].AsInt;
		spells = parameters ["spells"];
		melees = parameters ["melees"];
		experience = parameters ["experience"].AsInt;
		detectionDistance = parameters["detection"].AsFloat;


		rand = random_number ();
		direction = new Vector2(0.0f,-1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive) {
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
				
				counter_2 = 0;
			} else {
				counter_2++;
			}
		} else {


			if(Time.time>deadTime+0.2) {

				Destroy (gameObject);

			}
		}

	}
	
	public int getHealth(){

		return this.health;
	}

	public bool getIsAlive(){

		return this.isAlive;
	}

	string choose_melee () {
		if (melees == null || melees.Count == 0) return null;
		float probability = Random.Range (0, 1);
		float partial = 0f;
		string selectedMelee = melees[0]["name"];
		for (int i=0; i<melees.Count; i++) {
			if(probability>partial && (i==(melees.Count+1) || probability<partial+melees[i]["probability"].AsFloat)) selectedMelee = melees[i]["name"];
			partial += melees[i]["probability"].AsFloat;
		}
		return selectedMelee;
	}

	string choose_spell () {
		if (spells == null || spells.Count == 0) return null;
		float probability = Random.Range (0f, 1f);
		float partial = 0f;
		string selectedSpell = spells[0]["name"];
		for (int i=0; i<spells.Count; i++) {
			if(probability>partial && (i==(spells.Count+1) || probability<(partial+spells[i]["probability"].AsFloat))) selectedSpell = spells[i]["name"];
			partial += spells[i]["probability"].AsFloat;
		}
		return selectedSpell;
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
	int choose_attack(){

		float distance = distance_between ();

		if (distance > 1.5 && distance < 15) {

			return 1;

		} else if (distance > 15 ) {

			return 0;		

		} else {

			return -1;
		}
	}
	void attacking(){

		GameInstance.instance.castSpell(choose_spell(),transform,direction,"SpellEnemy",colliderRadius/2+(colliderRadius/10));
		/*
		if (choose_attack () == 1) {
		//spell 1
			GameInstance.instance.castSpell("Red 1",transform,direction,"SpellEnemy");
		} else if (choose_attack () == 0) {
		//spell 2
			GameInstance.instance.castSpell("Black 1",transform,direction,"SpellEnemy");
		} else if (choose_attack () == -1) {
		//melee
			generate_melee();
		}
		*/

	}
	int position_of_target_respect_enemy(){

		if (diff_x < diff_y) {

			return 1;
		}
			return 0;

	}


	void generate_melee(){
		
		//GameObject attack;
		//attack=(GameObject)Instantiate(melee,new Vector3(transform.position.x+direction.x,transform.position.y+direction.y,0),transform.rotation);
		
	}

	bool detect_player (){
		
		distance_to_player = distance_between ();
		
		if (distance_to_player < detectionDistance) {
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
		animator.Play ("WalkUp");
	}
	void move_down(){
		rigidbody2D.velocity = Vector3.down * speed;
		animator.Play ("WalkDown");
	}
	void move_right(){
		rigidbody2D.velocity = Vector3.right * speed;
		animator.Play ("WalkRight");
	}
	void move_left(){
		rigidbody2D.velocity = Vector3.left * speed;
		animator.Play ("WalkLeft");
	}


	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Spell") {
				Spell spellParameters = (Spell)other.gameObject.GetComponent ("Spell");
				int randomModification = spellParameters.damage / 10;
				int levelModification = spellParameters.damage / 10;
				int finalDamage = spellParameters.damage + Random.Range(-randomModification,randomModification) + levelModification*(GameInstance.instance.getPlayerLevel()-1);
				health -= finalDamage;
			GameInstance.instance.damageValueAnimation(finalDamage, transform.position);
				if (health <= 0) {
					isAlive = false;
					deadTime = Time.time;
					GameInstance.instance.increaseExperience(experience);
					//Destroy(gameObject);
				}
		} else if (other.gameObject.tag == "SpellEnemy") {
			Destroy (other.gameObject);
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
			

}


	

