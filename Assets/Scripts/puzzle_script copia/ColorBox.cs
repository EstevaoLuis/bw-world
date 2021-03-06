﻿using UnityEngine;
using System.Collections;

public class ColorBox : MonoBehaviour {

	// 0 = Red
	// 1 = Green
	// 2 = Blue
	public int color = 0;
	//public GameObject puzzleMaster = null;
	//private PuzzleMaster pm;
	public PuzzleMaster pm = null;
	public float lastTouch;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (pm.active == true && other.gameObject.tag == "Player" && Time.time > lastTouch + 1f) {
			lastTouch = Time.time;
			if (color != pm.correctSequence[pm.attempt]){
				Debug.Log("WRONG! " + pm.attempt);
				pm.attempt = 0;
				//return;
			}
			if (color == pm.correctSequence[pm.attempt]){
				var a = ++pm.attempt;
				Debug.Log("CORRECT! " + pm.attempt);
				//Debug.Log("HEYSUKE! " + pm.Size ());
				if (pm.Size() == a){
					GameInstance.instance.playAudio("Up1");
					Debug.Log("COMPLETE! " + pm.attempt);
					Destroy(pm.door);
					pm.active = false;
				}
			}
			GameInstance.instance.damageValueAnimation(pm.attempt, transform.position);
		}
		if (!pm.active) {
			Destroy(gameObject.GetComponent<Rigidbody2D>());
			Destroy(gameObject.GetComponent<PolygonCollider2D>());
		}
	}
}
