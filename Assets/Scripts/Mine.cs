using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public GameObject exp;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D (Collision2D other){
		
		Instantiate (exp, transform.position,transform.rotation);
		//Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
