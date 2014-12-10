using UnityEngine;
using System.Collections;

public class TransparentWall : MonoBehaviour {

	// Use this for initialization
	private GameObject transpWall;
	private BoxCollider2D col;


	void Start () {

		transpWall = GameObject.FindGameObjectWithTag ("transparentWall");
		col = gameObject.GetComponent<BoxCollider2D> ();


	}

	void OnCollisionEnter2D (Collision2D other){

		if (other.gameObject.tag == "Spell") {
						//print (9);
						col.isTrigger = true;
				} 
	

	}
	
	// Update is called once per frame
	void Update () {
	
		col.isTrigger = false;

	}
}
