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
	private float initialRadius;

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
			if(area>0f) collider.radius = Mathf.Lerp(initialRadius,initialRadius + area, (Time.time - hitTime)/0.1f);
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
			if(other.gameObject.tag == "SpellEnemy") {
				Spell otherSpell = (Spell) other.gameObject.GetComponent<Spell>() as Spell;
				if(damage > 2*otherSpell.damage) {
					rigidbody2D.mass = 10*rigidbody2D.mass;
					return;
				}
			}
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
			if(!hasHit) {
					Instantiate (animationGraphics, transform.position, transform.rotation);
			}

			hasHit = true;
			hitTime = Time.time;
		}
	}

}
