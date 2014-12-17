using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float speed = 5f;
	
	private Animator animator;
	private Vector2 direction;
	private float lastSpell;
	private float lastRegeneration = 0f;
	private Spell used;
	private GameObject spell;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> () as Animator;
		direction = new Vector2(0.0f,-1.0f);
//		spell= GameObject.FindGameObjectWithTag("Spell");
//		used = spell.GetComponent <Spell> ();
	}


	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.DownArrow)) {
			//transform.position -= transform.up * MoveSpeed * Time.deltaTime;
			animator.Play ("WalkDown");
			direction = new Vector2 (0.0f, -1.0f);
			rigidbody2D.velocity = direction*speed;
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			//transform.position += transform.up * MoveSpeed * Time.deltaTime;
			animator.Play ("WalkUp");
			direction = new Vector2 (0.0f, 1.0f);
			rigidbody2D.velocity = direction*speed;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			//transform.position -= transform.right * MoveSpeed * Time.deltaTime;
			animator.Play ("WalkLeft");
			direction = new Vector2 (-1.0f, 0.0f);
			rigidbody2D.velocity = direction*speed;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			//transform.position += transform.right * MoveSpeed * Time.deltaTime;
			animator.Play ("WalkRight");
			direction = new Vector2 (1.0f, 0.0f);
			rigidbody2D.velocity = direction*speed;
		} else {
			rigidbody2D.velocity = new Vector2(0,0);
		}

		//Input.GetMouseButtonDown(0)
		if(Time.time > lastSpell + 0.1f) {
			if (Input.GetKey (KeyCode.W)) {
				GameInstance.instance.playerCastSpell("Red 1",transform,direction);
				//used.setType(1);
				lastSpell = Time.time;
			}
			else if(Input.GetKey (KeyCode.A)) {
				GameInstance.instance.playerCastSpell("Blue 1",transform,direction);
				//used.setType(3);
				lastSpell = Time.time;
			}
			else if(Input.GetKey (KeyCode.D)) {
				GameInstance.instance.playerCastSpell("Green 1",transform,direction);
				//used.setType(2);
				lastSpell = Time.time;
			}
			else if(Input.GetKey (KeyCode.S)) {
				GameInstance.instance.playerCastSpell("Red 4",transform,direction);
				//used.setType(1);
				lastSpell = Time.time;
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

}
