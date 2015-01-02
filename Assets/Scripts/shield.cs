using UnityEngine;
using System.Collections;

public class shield : MonoBehaviour {

	private GameObject Player;
	public GameObject anim;
	private GameObject shld;
	// Use this for initialization

	void Start () {

		Player = GameObject.FindGameObjectWithTag ("Player");
	
	}

	void OnCollisionEnter2D(Collision2D other){
		int i = 0;
		if (other.gameObject == Player) {
			shld = (GameObject) Instantiate(anim,new Vector3(Player.transform.position.x,Player.transform.position.y + 5),transform.rotation);
			Destroy(gameObject);
		}

	}

//	void movement_of_shield(){
//		if (anim != null) {
//			anim.rigidbody2D.velocity = Vector3.up*5;
//		}
//
//	}

	
	// Update is called once per frame
	void Update () {
	
		//movement_of_shield ();

	}
}
