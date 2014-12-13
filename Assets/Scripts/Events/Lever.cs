using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {

	// Use this for initialization
	//private GameObject lever_1;
	public int status_lever = -1;



	void Start () {

	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			status_lever = 1;
		}
	}

	

	void Update () {
	
		//print (status_lever);


	}
}
