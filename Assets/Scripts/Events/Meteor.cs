using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	public float hitTime = 0.3f;
	private float explosionFinishedTime = 1f; 
	public int meteorDamage = 2;

	private float startTime;
	private bool explosionActivated = false;
	private CircleCollider2D collider;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		collider = GetComponent ("CircleCollider2D") as CircleCollider2D;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > startTime + hitTime ) {
			if(!explosionActivated) {
				explosionActivated = true;
				audio.Play();
			}
			collider.radius = Mathf.Lerp(0f,10f,Time.time-startTime);
			//collider.size = new Vector3(Mathf.Lerp(0f,8f,Time.time-startTime),Mathf.Lerp(0f,5f,Time.time-startTime),4f);
			if(Time.time > startTime + explosionFinishedTime) Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Player") {
			GameInstance.instance.damagePlayer(meteorDamage);
		}
	}
}
