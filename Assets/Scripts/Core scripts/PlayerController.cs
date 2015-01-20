using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public bool useJoystick = false;
	
	private float speed = 5f;
	private bool invincibility = false;

	private Animator animator;
	private Vector2 direction;
	private float lastSpell;
	private float lastRegeneration = 0f;
	private Spell used;
	private GameObject spell;

	private bool canMove = true;
	private bool canShoot = true;

	//test
	private float lastMovement;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> () as Animator;
		direction = new Vector2(0.0f,-1.0f);
	}
	
	
	
	// Update is called once per frame
	void FixedUpdate () {

		if(Time.timeScale > 0.2f) {
			if (!useJoystick) {
				
				if (Input.GetKey (KeyCode.DownArrow)) {
					moveDown();
				} else if (Input.GetKey (KeyCode.UpArrow)) {
					moveUp();
				} else if (Input.GetKey (KeyCode.LeftArrow)) {
					moveLeft();
				} else if (Input.GetKey (KeyCode.RightArrow)) {
					moveRight();
				} else {
					stopMovement();
				}

				/*if (Input.GetKey (KeyCode.Space)) {
					pause();
				}*/
			}
			
			if(Time.time > lastSpell + 0.1f) {
				
				if (!useJoystick){
					if (Input.GetKey (KeyCode.W)) {
						if(GameInstance.instance.canCastSpell("Red",1)) redSpell(1);
					}
					else if(Input.GetKey (KeyCode.A)) {
						if(GameInstance.instance.canCastSpell("Blue",1)) blueSpell(1);
					}
					else if(Input.GetKey (KeyCode.D)) {
						if(GameInstance.instance.canCastSpell("Green",1)) greenSpell(1);
					}
				}
			}
		}
	}


	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "SpellEnemy") {
			Spell spellParameters = (Spell)other.gameObject.GetComponent ("Spell");
			GameInstance.instance.damagePlayer(spellParameters.damage);
		} 
	}
	
	void OnTriggerStay2D (Collider2D other) {
		if(other.gameObject.tag == "Color") {
			Colour colorScript = other.gameObject.GetComponent("Colour") as Colour;
			if(colorScript.isColored()) {
				if (Time.time > lastRegeneration + 3.0f) {
					if(GameInstance.instance.regeneration()) lastRegeneration = Time.time;
				}
			}
		}
	}


	public void moveDown() {
		if(canMove) {
			animator.Play ("WalkDown");
			direction = new Vector2 (0.0f, -1.0f);
			//Vector2 newVelocity = direction * speed;
			//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
			rigidbody2D.velocity = direction * speed;
			lastMovement = Time.time;
		}
	}
	public void moveUp() {
		if (canMove) {
			animator.Play ("WalkUp");
			direction = new Vector2 (0.0f, 1.0f);
			//Vector2 newVelocity = direction * speed;
			//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
			rigidbody2D.velocity = direction * speed;
			lastMovement = Time.time;
		}
	}
	public void moveLeft() {
		if (canMove) {
			animator.Play ("WalkLeft");
			direction = new Vector2 (-1.0f, 0.0f);
			//Vector2 newVelocity = direction * speed;
			//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
			rigidbody2D.velocity = direction * speed;
			lastMovement = Time.time;
		}
	}
	public void moveRight() {
		if (canMove) {
			animator.Play ("WalkRight");
			direction = new Vector2 (1.0f, 0.0f);
			//Vector2 newVelocity = direction * speed;
			//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
			rigidbody2D.velocity = direction * speed;
			lastMovement = Time.time;
		}
	}
	public void stopMovement() {
		Vector2 newVelocity = new Vector2 (0, 0);
		//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
		rigidbody2D.velocity = newVelocity;
		lastMovement = Time.time;
	}
	public void blueSpell(int spellLevel) {
		if(canShoot) {
			GameInstance.instance.playerCastSpell("Blue "+spellLevel,transform,direction);
			lastSpell = Time.time;
		}
	}
	public void redSpell(int spellLevel) {
		if (canShoot) {
			GameInstance.instance.playerCastSpell ("Red "+spellLevel, transform, direction);
			lastSpell = Time.time;
		}
	}
	public void greenSpell(int spellLevel) {
		if(canShoot) {
			GameInstance.instance.playerCastSpell("Green "+spellLevel,transform,direction);
			lastSpell = Time.time;
		}
	}

	public void castSpell(string spellColor, int spellLevel) {
		if(canShoot) {
			GameInstance.instance.playerCastSpell(spellColor + " " + spellLevel,transform,direction);
			lastSpell = Time.time;
		}
	}

	public float GetSpeed(){
			return speed;
		}

	public Vector2 getDirection() {
		return direction;
	}

	public void SetSpeed(float Speed){
		if (Speed>0f)
				speed = Speed;
		}

	public void SetInvincibility(bool value = true){
		invincibility = value;
	}

	public bool GetInvincibility(){
		return invincibility;
	}

	public bool usingJoystick() {
		return useJoystick;
	}

	public void pause(){
		Debug.Log ("Pausing 1");
		GameInstance.instance.pauseGame ();
		Debug.Log ("Pausing Complete 1");
	}

	public void isAvailable(bool value) {
		canMove = value;
		canShoot = value;
	}
	
}
