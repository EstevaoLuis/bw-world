﻿using UnityEngine;
using System.Collections;

public class GemCannon : MonoBehaviour {

	public GameObject bullet;
	private GameObject target;
	private SpriteRenderer sprite;
	private SpriteRenderer targetSprite;
	private float diff_x;
	private float diff_y;
	private float speed = 2f;
	private float lastShot = 0.5f;
	private Vector3 direction;
	public float intensity = 0.1f;
	// Use this for initialization
	void Start () {
		target = GameObject.Find("GemPost_2");
		sprite = GetComponent<SpriteRenderer> ();
		targetSprite = target.GetComponent<SpriteRenderer> ();
	}

	Vector3 compute_startshot(){
		diff_x = transform.position.x - target.transform.position.x;
		diff_y = transform.position.y - target.transform.position.y;

		if (diff_x < diff_y && diff_x < 0) {
				return new Vector3 (1, 0);
		} else if (diff_x > diff_y && diff_x > 0) {
				return new Vector3 (-1, 0);
		} else if (diff_y < diff_x && diff_y < 0) {
				return new Vector3 (0, 1);
		} else if (diff_y > diff_x && diff_y > 0) {
				return new Vector3 (0, -1);
		} else {
				return new Vector3 (0, 0);
		}
	}

	// Update is called once per frame
	void Update () {

		if (Time.time > lastShot + 0.5f && sprite.color.r < 1f && sprite.color.g > 0f) {
			direction += compute_startshot ();
			direction.Normalize();
			Instantiate (bullet, direction+transform.position, transform.rotation);
			lastShot = Time.time;
		}
//		bullet.rigidbody2D.velocity = Vector3.right * speed;
		//shoot_to_other_portal ();
	
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Spell") {
			Spell spell = other.gameObject.GetComponent("Spell") as Spell;
			Spell spellParameters = (Spell)other.gameObject.GetComponent ("Spell");
			if (spellParameters == null) return;
			string kolor = spellParameters.color;
			if (kolor == "green") colorMe ();
			GameInstance.instance.playAnimation ("Hit", gameObject.transform.position);
		}

		if (other.gameObject.tag == "SpellEnemy") {
			deColorMe ();
			GameInstance.instance.playAnimation ("Hit", gameObject.transform.position);
		}
	}

	void colorMe(){
		float red = sprite.color.r;
		float green = sprite.color.g;
		float blue = sprite.color.b;
				
		//Debug.Log ("RGB: " + red + " " + green + " " + blue);
		
		red = red - intensity;
		blue = blue - intensity;
		
		//Debug.Log ("RGB: " + red + " " + green + " " + blue);
		
		if (red <= 0f || blue <= 0f) {
			red = 0f;
			blue = 0f;
		}

		//Debug.Log ("RGB: " + red + " " + green + " " + blue);

		sprite.color = new Color (red, green, blue);
		targetSprite.color = new Color (red, green, blue);
	}

	void deColorMe(){
		float red = sprite.color.r;
		float green = sprite.color.g;
		float blue = sprite.color.b;
		
		//Debug.Log ("RGB: " + red + " " + green + " " + blue);
		
		red = red + 3*intensity;
		blue = blue + 3*intensity;
		
		//Debug.Log ("RGB: " + red + " " + green + " " + blue);
		
		if (red >= 1f || blue >= 1f) {
			red = 1f;
			blue = 1f;
		}
		
		//Debug.Log ("RGB: " + red + " " + green + " " + blue);
		
		sprite.color = new Color (red, green, blue);
		targetSprite.color = new Color (red, green, blue);
	}

	public bool isColoured(){
		return (sprite.color.r != 1f);
	}
}

