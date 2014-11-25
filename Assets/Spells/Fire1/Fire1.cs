﻿using UnityEngine;
using System.Collections;

public class Fire1 : MonoBehaviour {
	
	//public float speed = 3.0f;
	public GameObject animationGraphics = null;
	public int damage = 10;
	public float duration = 2.0f;

	private bool hasHit = false;
	private float hitTime, castTime;
	private GameObject animation = null;

	// Use this for initialization
	void Start () {
		audio.Play();
		castTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (hasHit) {
			if(Time.time > hitTime+0.1) {
				Destroy (gameObject);
			}
		}
		else if(Time.time > castTime+duration) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag!="Player") {
			hasHit = true;
			hitTime = Time.time;

			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
			animation = (GameObject) Instantiate(animationGraphics, transform.position, transform.rotation);

		}
	}

}