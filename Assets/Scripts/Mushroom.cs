using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {

	private PlayerController p;
	//private float prev_speed;

	public float mush_speed = 20f;
	public float mush_time_effect = 5f;

	private bool mush_lock = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player" && !mush_lock) {
			//Destroy(gameObject);
			mush_lock = true;
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<PolygonCollider2D>().enabled = false;
			p = other.gameObject.GetComponent<PlayerController>();

			if (GameInstance.instance.mush_tot == 0)
				GameInstance.instance.mush_prev_speed = p.GetSpeed();
			GameInstance.instance.mush_tot ++;
			p.SetSpeed(mush_speed);
			StartCoroutine("normalSpeed");
			//Destroy(gameObject);
		}
	}


	IEnumerator normalSpeed(){
		//Debug.Log ("AAAAA");
		yield return new WaitForSeconds(mush_time_effect);
		//Debug.Log ("BBBB");
		GameInstance.instance.mush_tot--;
		if (GameInstance.instance.mush_tot==0)
			p.SetSpeed (GameInstance.instance.mush_prev_speed);
		//Debug.Log ("CCCC");
		Destroy(gameObject);
	}
}


