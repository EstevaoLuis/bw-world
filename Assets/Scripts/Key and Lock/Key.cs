using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public LockKey locker;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			locker.KeyFound();
			GameInstance.instance.damageValueAnimation(locker.GetKeyFound(), transform.position);
			Destroy (gameObject);
		}
	}
}
