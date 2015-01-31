using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {
	
	//public float speed = 3.0f;
	public GameObject animationGraphics;

	//Parameters
	public int damage = 10;
	public float duration = 2.0f;
	public string color;
	public float area;
	private int type;

	private bool hasHit = false;
	private float hitTime, castTime;
	private CircleCollider2D collider;
	private float initialRadius, finalRadius;

	// Use this for initialization
	void Start () {
		audio.Play();
		castTime = Time.time;
		collider = GetComponent ("CircleCollider2D") as CircleCollider2D;
		initialRadius = collider.radius;
	}

	// Update is called once per frame
	void Update () {
		if (hasHit) {
			if(area>0f) collider.radius = Mathf.Lerp(initialRadius,finalRadius, (Time.time - hitTime)/0.1f);
			if(Time.time > hitTime+0.1) {
				Destroy (gameObject);
			}
		}
		else if(Time.time > castTime+duration) {
			Destroy (gameObject);
		}
	}
	public int setType(int t){
		this.type = t;
		return type;
	}

	public int getType(){
		return type;
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (!(gameObject.tag == other.gameObject.tag) && !(gameObject.tag == "SpellEnemy" && other.gameObject.tag == "Enemy") && !(gameObject.tag == "Spell" && other.gameObject.tag == "Player")) {
				if (other.gameObject.tag == "SpellEnemy") {
						Spell otherSpell = (Spell)other.gameObject.GetComponent<Spell> () as Spell;
						if (damage > 2 * otherSpell.damage) {
								rigidbody2D.mass = 10 * rigidbody2D.mass;
								return;
						}
				}
				GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				if (!hasHit) {
						GameObject animation = (GameObject) GameObject.Instantiate (animationGraphics, transform.position, transform.rotation);
						animation.transform.localScale = transform.localScale;
				}

				hasHit = true;
				hitTime = Time.time;
				finalRadius = initialRadius + area;
				if(finalRadius > 3f) finalRadius = 3f;
		} 
		else if (gameObject.tag == "Spell" && other.gameObject.tag == "Spell" && !hasHit) {
			Spell otherSpell = other.gameObject.GetComponent<Spell>();
			if(transform.localScale.x >= other.gameObject.transform.localScale.x && !otherSpell.hasAlreadyHit()) {
				Destroy(other.gameObject);
				float scaleMultiplier = 1.2f;
				if(color != otherSpell.color) {
					Animator animator = GetComponent<Animator>();
					scaleMultiplier = 1.5f;
					GameObject spellAnimation = null;
					AudioClip soundEffect = null;
					//Cyan
					if((color == "blue" && otherSpell.color == "green") || (otherSpell.color == "blue" && color == "green")) {
						RuntimeAnimatorController newController = Resources.Load("Animators/CyanSpell") as RuntimeAnimatorController;
						color = "cyan";
						animator.runtimeAnimatorController = newController;
						spellAnimation = Resources.Load("Spells/Animations/Cyan 1") as GameObject;
						soundEffect = Resources.Load("Spells/Sound Effects/Cyan 1") as AudioClip;
					}
					//Yellow
					else if((color == "green" && otherSpell.color == "red") || (otherSpell.color == "green" && color == "red")) {
						RuntimeAnimatorController newController = Resources.Load("Animators/YellowSpell") as RuntimeAnimatorController;
						color = "yellow";
						animator.runtimeAnimatorController = newController;
						spellAnimation = Resources.Load("Spells/Animations/Yellow 2") as GameObject;
						soundEffect = Resources.Load("Spells/Sound Effects/Yellow 2") as AudioClip;
					}
					//Magenta
					else if((color == "blue" && otherSpell.color == "red") || (otherSpell.color == "blue" && color == "red")) {
						RuntimeAnimatorController newController = Resources.Load("Animators/MagentaSpell") as RuntimeAnimatorController;
						color = "magenta";
						animator.runtimeAnimatorController = newController;
						spellAnimation = Resources.Load("Spells/Animations/Magenta 1") as GameObject;
						soundEffect = Resources.Load("Spells/Sound Effects/Magenta 1") as AudioClip;

					}
					//White
					else if(
						(color == "cyan" && otherSpell.color == "magenta") || (otherSpell.color == "cyan" && color == "magenta") ||
					    (color == "magenta" && otherSpell.color == "yellow") || (otherSpell.color == "magenta" && color == "yellow") ||
						(color == "cyan" && otherSpell.color == "yellow") || (otherSpell.color == "cyan" && color == "yellow")
						) {
						RuntimeAnimatorController newController = Resources.Load("Animators/WhiteSpell") as RuntimeAnimatorController;
						color = "white";
						animator.runtimeAnimatorController = newController;
						spellAnimation = Resources.Load("Spells/Animations/White 1") as GameObject;
						soundEffect = Resources.Load("Spells/Sound Effects/White 1") as AudioClip;
						
					}

					if(spellAnimation != null && soundEffect != null) {
						animationGraphics = spellAnimation;
						audio.clip = soundEffect;
						audio.Play();
					}
				}
				castTime = Time.time;
				duration = duration + otherSpell.duration / 2f;
				damage = damage + otherSpell.damage / 2;
				area = area * 1.2f;
				if(area >= 3f) area = 3f;
				if(transform.localScale.x < 4f) transform.localScale = new Vector3(transform.localScale.x * scaleMultiplier, transform.localScale.y * scaleMultiplier, 1f);
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x / 1.1f, rigidbody2D.velocity.y / 1.1f);
			}
		}
	}

	public bool hasAlreadyHit() {
		return hasHit;
	}

}
