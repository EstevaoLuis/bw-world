using UnityEngine;
using System.Collections;

public class IceSwordBullet : MonoBehaviour {

	private GameObject player;
	private float speed = 8;

	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");

	}
//
//	void OnCollisionEnter2D (Collision2D other){
//
//		if (other.gameObject.tag == "Player") {
//			GameInstance.instance.damagePlayer (10);
//			//Destroy(gameObject);
//			//this.collider2D.enabled = false;
//		}
//	}

	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3 (-1, -1,0)*speed* Time.deltaTime;
		if (Vector3.Distance (player.transform.position, transform.position) < 1f) {
			GameInstance.instance.damagePlayer (3);
			GameInstance.instance.playAnimation("Hit",player.transform.position);
		}
	}
}
