using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

	private Colour Col;
	private bool trigger;
//	private Spell sp;
//	private float timer;


	// Use this for initialization
	void Start () {
		Col = this.GetComponent <Colour> ();
	}

//	bool timer_colored(){
//
//		if (Time.time > timer) {
//			timer = timer + 5;
//			return true;
//		} 
//
//		timer = timer + 5;
//		this.renderer.material.color = Color.white;
//		return false;
//
//	}

	void OnCollisionEnter2D (Collision2D other){

		if (other.gameObject.tag == "Spell") {

			//sp = other.gameObject.GetComponent<Spell>();
			//string aux = sp.color;
//			timer = Time.time + 5;
			trigger = true;
			
		}
//		timer = Time.time + 5;
		//this.renderer.material.color = Color.black;
	}


	// Update is called once per frame
	void Update () {




//		if (Time.time > timer) {

				//Col.decolor();


				//	timer = Time.time + 5;
	}
		//this.renderer.material.c		olor = Color.black;
}

