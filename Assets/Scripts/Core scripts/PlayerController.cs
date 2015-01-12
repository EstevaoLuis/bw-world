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

	//test
	private float lastMovement;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> () as Animator;
		direction = new Vector2(0.0f,-1.0f);
	}
	
	
	
	// Update is called once per frame
	void Update () {

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
			}
			
			if(Time.time > lastSpell + 0.1f) {
				
				if (!useJoystick){
					if (Input.GetKey (KeyCode.W)) {
						redSpell();
					}
					else if(Input.GetKey (KeyCode.A)) {
						blueSpell();
					}
					else if(Input.GetKey (KeyCode.D)) {
						greenSpell();
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
		animator.Play ("WalkDown");
		direction = new Vector2 (0.0f, -1.0f);
		//Vector2 newVelocity = direction * speed;
		//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
		rigidbody2D.velocity = direction * speed;
		lastMovement = Time.time;
	}
	public void moveUp() {
		animator.Play ("WalkUp");
		direction = new Vector2 (0.0f, 1.0f);
		//Vector2 newVelocity = direction * speed;
		//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
		rigidbody2D.velocity = direction * speed;
		lastMovement = Time.time;
	}
	public void moveLeft() {
		animator.Play ("WalkLeft");
		direction = new Vector2 (-1.0f, 0.0f);
		//Vector2 newVelocity = direction * speed;
		//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
		rigidbody2D.velocity = direction * speed;
		lastMovement = Time.time;
	}
	public void moveRight() {
		animator.Play ("WalkRight");
		direction = new Vector2 (1.0f, 0.0f);
		//Vector2 newVelocity = direction * speed;
		//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
		rigidbody2D.velocity = direction * speed;
		lastMovement = Time.time;
	}
	public void stopMovement() {
		Vector2 newVelocity = new Vector2 (0, 0);
		//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
		rigidbody2D.velocity = newVelocity;
		lastMovement = Time.time;
	}
	public void blueSpell() {
		GameInstance.instance.playerCastSpell("blue",transform,direction);
		lastSpell = Time.time;
	}
	public void redSpell() {
		GameInstance.instance.playerCastSpell("red",transform,direction);
		lastSpell = Time.time;
	}
	public void greenSpell() {
		GameInstance.instance.playerCastSpell("green",transform,direction);
		lastSpell = Time.time;
	}

	public float GetSpeed(){
				return speed;
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
	
}
