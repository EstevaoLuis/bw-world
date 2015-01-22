using UnityEngine;
using System.Collections;

public class ActivateBossTheme : MonoBehaviour {

	public float test;
	private bool isActive = false;
	
	void OnTriggerEnter2D(Collider2D other) {
		if(!isActive && other.gameObject.tag == "Player") {
			GameInstance.instance.setBossBattle(true);
			isActive = true;
			Debug.Log ("Boss battle!!");
		}
	}
}
