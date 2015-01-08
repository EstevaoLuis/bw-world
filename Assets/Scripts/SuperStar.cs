using UnityEngine;
using System.Collections;

public class SuperStar : MonoBehaviour {

	private PlayerController p;
	private Rigidbody2D rigid;

	//private bool prev_status;
	//private float prev_mass;

	public float inv_time_effect = 5f;
	
	private bool inv_lock = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player" && !inv_lock) {
			inv_lock = true;
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<PolygonCollider2D>().enabled = false;
			p = other.gameObject.GetComponent<PlayerController>();
			rigid = other.gameObject.GetComponent<Rigidbody2D>();

			if (GameInstance.instance.star_tot == 0){
				GameInstance.instance.star_prev_mass = rigid.mass;
			}

			GameInstance.instance.star_tot++;
			p.SetInvincibility();
			rigid.mass = 100;
			StartCoroutine("normalStatus");
			//Destroy(gameObject);
		}
	}
	
	
	IEnumerator normalStatus(){
		Debug.Log ("You are INV");
		yield return new WaitForSeconds(inv_time_effect);
		Debug.Log ("Time ended");
		GameInstance.instance.star_tot--;
		if (GameInstance.instance.star_tot == 0) {
			rigid.mass = GameInstance.instance.star_prev_mass;
			p.SetInvincibility (false);
		}
		Debug.Log ("NOT INV ANYMORE");
		Destroy(gameObject);
	}
}
