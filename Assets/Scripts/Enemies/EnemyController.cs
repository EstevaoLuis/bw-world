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
	private float maxSpeed;
	private int experience;
	private float detectionDistance;
	private float scale;
	private float delay;
	private float mass;
	private int behaviourA, behaviourB, behaviourC;

	//Spells & Melees
	private JSONNode spells;
	private JSONNode melees;

	private float distanceToPlayer;
	private float distanceToInitialPosition;
	private Vector2 direction;
	private float minMovementDuration = 0.8f;
	private float minDashDuration = 0.3f;
	private float lastDirectionChange = 0f;
	private float meleeDistance;
	private float range;

	private float colliderDiameter;
	private float initialPositionX, initialPositionY;
	
	private GameObject player;

	private float deadTime;
	private bool isAlive = true;
	private float lastAttack;

	float x_pos;
	float y_pos;
	Vector2 target;
	float diff_x;
	float diff_y;

	int randomDirection;

	private Color hidden = new Color (1, 1, 1, 0);
	private Color visible = new Color (1, 1, 1, 1);

	// Use this for initialization
	void Start () {

		//Get enemy parameters
		JSONNode parameters = GameInstance.instance.getEnemyParameters (enemyName);

		//If not found, destroy
		if (parameters == null) Destroy (gameObject);

		//Initial coordinates
		initialPositionX = transform.position.x;
		initialPositionY = transform.position.y;

		//Animator
		animator = GetComponent<Animator> () as Animator;

		//Set up target
		player = GameObject.FindGameObjectWithTag ("Player");

		//Set parameters
		health = parameters ["health"].AsInt;
		attack = parameters ["attack"].AsInt;
		defense = parameters ["defense"].AsInt;
		maxSpeed = parameters ["speed"].AsFloat;
		delay = parameters ["delay"].AsFloat;
		scale = parameters ["scale"].AsFloat;
		mass = parameters ["mass"].AsInt;
		spells = parameters ["spells"];
		melees = parameters ["melees"];
		experience = parameters ["experience"].AsInt;
		detectionDistance = parameters["detection"].AsFloat;
		behaviourA = parameters["behaviour"][0].AsInt;
		behaviourB = parameters["behaviour"][1].AsInt;
		behaviourC = parameters["behaviour"][2].AsInt;

		rigidbody2D.mass = mass;
		rigidbody2D.transform.localScale = new Vector3 (scale,scale,1);

		//Collider
		BoxCollider2D collider = GetComponent<BoxCollider2D> () as BoxCollider2D;
		colliderDiameter = Mathf.Max (collider.size.x, collider.size.y);


		//Calculate range
		range = 0f;
		for (int i=0; i < spells.Count; i++) {
			if(GameInstance.instance.getSpellRange(spells[i]["name"]) > range) range = GameInstance.instance.getSpellRange(spells[i]["name"]);
		}
		if (range == 0) range = detectionDistance * (3f / 4f);
		meleeDistance = colliderDiameter / 2 + 2.5f;

		randomDirection = randomNumber ();
		direction = new Vector2(0.0f,-1.0f);

		Debug.Log ("Range: " + range);
	}
	public int getHealth(){
		return health;
	}
	
	// Update is called once per frame
	void Update () {
		//Enemy not already dead
		if (isAlive) {

			setTarget(0);
			distanceToPlayer = detectDistance();

			//If player NOT detected
			if (distanceToPlayer > detectionDistance) {

				speed = maxSpeed / 1.5f;

				setTarget(1);
				distanceToInitialPosition = detectDistance();

				//Movimento casuale
				if(distanceToInitialPosition > detectionDistance * (3f/4f)) {
					//Debug.Log("Torno a " + target + ", distanze = " + distanceToInitialPosition);
					moveTowardsTarget();
				}
				//Torna alla base
				else {
					randomMovement();
				}

			//If player detected
			} else {

				Debug.Log (distanceToPlayer);

				speed = maxSpeed;
				//If too distant
				if(distanceToPlayer > range + (colliderDiameter / 2f)) {

					behaviour (behaviourA);

				}
				//In spell range
				else if(distanceToPlayer > meleeDistance) {

					if(spells.Count > 0 && Time.time > lastAttack + delay) {

						castSpell();
					}

					behaviour (behaviourB);

				}
				//Melee attack
				else if(Time.time > lastAttack + delay) {

					if(Time.time > lastAttack + delay) {
						//Close attack
						if(melees.Count > 0) meleeAttack();
						else castSpell();
					}
					
					behaviour (behaviourC);

				}
			}

		//If hit by a death spell
		} else {
			GetComponent<SpriteRenderer> ().color = Color.Lerp(visible,hidden,(Time.time-deadTime)/ 1f);
			if(Time.time>deadTime+1f) {
				//Destroy the enemy
				Destroy (gameObject);

			}
		}

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

	float detectDistance(){
		
		x_pos = transform.position.x;
		y_pos = transform.position.y;
		
		diff_x = x_pos - target.x;
		diff_y = y_pos - target.y;
		
		return Mathf.Sqrt ((diff_x) * (diff_x) + (diff_y) * (diff_y));
		
	}

	void setTarget(int type) {
		switch(type) {
			case 0: target = new Vector2(player.transform.position.x,player.transform.position.y); break;
			case 1:	target = new Vector2(initialPositionX,initialPositionY); break;
		}
	}

	void castSpell(){
		GameInstance.instance.castSpell (choose_spell (), transform, getPlayerDirection(), "SpellEnemy", colliderDiameter / 2 + 1.5f, speed);
		lastAttack = Time.time;
	}


	int position_of_target_respect_enemy(){

		if (diff_x < diff_y) {

			return 1;
		}
			return 0;

	}

	void behaviour(int type) {
		switch(type) {
			case 0: standStill(); break;
			case 1: randomMovement (); break;
			case 2: moveTowardsTarget (); break;
			case 3: runAway (); break;
		}
	}

	void meleeAttack(){
		GameInstance.instance.meleeAttack (choose_melee(), attack, direction);
		lastAttack = Time.time;
	}


	void runAway() {

		if (diff_x < diff_y && diff_x < 0) {
			moveLeft();
		} else if (diff_x > diff_y && diff_x > 0) {
			moveRight();
		} else if (diff_y < diff_x && diff_y < 0) {
			moveDown();
		} else if (diff_y > diff_x && diff_y > 0) {
			moveUp();
		} else {
			standStill();
		}

	}

	void moveTowardsTarget(){

		if (diff_x < diff_y && diff_x < 0) {
			moveRight();
		} else if (diff_x > diff_y && diff_x > 0) {
			moveLeft();
		} else if (diff_y < diff_x && diff_y < 0) {
			moveUp();
		} else if (diff_y > diff_x && diff_y > 0) {
			moveDown();
		} else {
			standStill();
		}

	}

	Vector2 getPlayerDirection() {
		if (diff_x < diff_y && diff_x < 0) return new Vector2 (1.0f, 0.0f);
		if (diff_x > diff_y && diff_x > 0) return new Vector2 (-1.0f, 0.0f);
		if (diff_y < diff_x && diff_y < 0) return new Vector2 (0.0f, 1.0f);
		if (diff_y > diff_x && diff_y > 0) return new Vector2 (0.0f, -1.0f);
		return new Vector2 (1.0f, 0.0f);
	}

	int randomNumber(){
		int rand = Random.Range (0, 5);
		return rand;
	}

	void randomMovement(){
		if (Time.time > lastDirectionChange + minMovementDuration) {
				randomDirection = randomNumber ();
				if (randomDirection == 0) {
						standStill ();
				} else if (randomDirection == 1) {
						moveUp ();			//move_up
				} else if (randomDirection == 2) {
						moveDown ();		//move_down
				} else if (randomDirection == 3) {
						moveLeft ();		//move_left		
				} else if (randomDirection == 4) {
						moveRight ();		//move right
				}
		}
	}

	//Moving functions
	void moveUp(){
		if (Time.time > lastDirectionChange + minDashDuration) {
			direction = new Vector2 (0.0f, 1.0f);
			rigidbody2D.velocity = Vector3.up * speed;
			animator.Play ("WalkUp");
			lastDirectionChange = Time.time;
		}
	}
	void moveDown(){
		if (Time.time > lastDirectionChange + minDashDuration) {
			direction = new Vector2 (0.0f, -1.0f);
			rigidbody2D.velocity = Vector3.down * speed;
			animator.Play ("WalkDown");
			lastDirectionChange = Time.time;
		}
	}
	void moveRight(){
		if (Time.time > lastDirectionChange + minDashDuration) {
			direction = new Vector2 (1.0f, 0.0f);
			rigidbody2D.velocity = Vector3.right * speed;
			animator.Play ("WalkRight");
			lastDirectionChange = Time.time;
		}
	}
	void moveLeft(){
		if (Time.time > lastDirectionChange + minDashDuration) {
			direction = new Vector2 (-1.0f, 0.0f);
			rigidbody2D.velocity = Vector3.left * speed;
			animator.Play ("WalkLeft");
			lastDirectionChange = Time.time;
		}
	}
	void standStill() {
		if (Time.time > lastDirectionChange + minDashDuration) {
			rigidbody2D.velocity = new Vector3 (0, 0, 0);
			lastDirectionChange = Time.time;
			Vector3 standDirection = new Vector3(direction.x,direction.y,0);
			if(standDirection == Vector3.up) animator.Play ("StandUp");
			else if(standDirection == Vector3.left) animator.Play ("StandLeft");
			else if(standDirection == Vector3.right) animator.Play ("StandRight");
			else if(standDirection == Vector3.down) animator.Play ("StandDown");
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Spell") {
				Spell spellParameters = (Spell)other.gameObject.GetComponent ("Spell");
				int randomModification = spellParameters.damage / 10;
				int levelModification = spellParameters.damage / 10;
				int finalDamage = spellParameters.damage + Random.Range(-randomModification,randomModification) + levelModification*(GameInstance.instance.getPlayerLevel()-1) - defense;
				if(finalDamage<=1) finalDamage = 1;
				health -= finalDamage;
				GameInstance.instance.damageValueAnimation(finalDamage, transform.position);
				if (health <= 0 && isAlive) {
					isAlive = false;
					deadTime = Time.time;
					GameInstance.instance.increaseExperience(experience);
					//Destroy(gameObject);
				}
		} else if (other.gameObject.tag == "SpellEnemy") {
			Destroy (other.gameObject);
		}
	}


}


	

