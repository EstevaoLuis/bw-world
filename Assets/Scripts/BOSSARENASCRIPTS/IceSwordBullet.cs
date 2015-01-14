using UnityEngine;
using System.Collections;

public class IceSwordBullet : MonoBehaviour {

	private float timer = 5f;
	private string nam;
	//private GameObject sword;
	// Use this for initialization
	void Start () {
		nam = this.name;
		print (nam);
	}

	void OnCollisionEnter2D (Collision2D other){
		Destroy(GameObject.Find(nam));
	}

	// Update is called once per frame
	void Update () {

//		if (Time.time > timer) {
//			Destroy(GameObject.Find(nam));
//		
//		}
	}
}
