using UnityEngine;
using System.Collections;

public class IceSwordBullet : MonoBehaviour {


	void Start () {

	}

	void OnCollisionEnter2D (Collision2D other){
		
		if (other.gameObject.tag == "Player") {
			GameInstance.instance.damagePlayer (5);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
