﻿using UnityEngine;
using System.Collections;

public class Fire1 : MonoBehaviour {

	public float speed = 3.0f;
	//public Animation animation;

	// Use this for initialization
	void Start () {
		audio.Play();
		//rigidbody2D.velocity = new Vector2(3,10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D other) {
		//Animation.Blend ("Fire1", 1.0, 0.3f);
		//Destroy (gameObject);
	}
}