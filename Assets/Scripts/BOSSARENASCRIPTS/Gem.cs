using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

	private Colour isCol;
	private float timer = 5;


	// Use this for initialization
	void Start () {
		isCol = this.GetComponent<Colour> ();
	}

	bool timer_colored(){

		if (Time.time > timer) {
			timer = timer + 5;
			return true;
		} 

		timer = timer + 5;
		this.renderer.material.color = Color.white;
		return false;

	}

	void OnCollisionEnter2D (Collision2D other){

		timer = Time.time + 5;
	}


	// Update is called once per frame
	void Update () {
		bool aux = isCol.getColoured();
		if (aux == true && Time.time > timer) {
			//this.renderer.material.color = Color.white;
			timer = Time.time + 5;
			isCol.setColoured(false);
		}


	}
}
