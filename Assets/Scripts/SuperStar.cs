using UnityEngine;
using System.Collections;

public class SuperStar : MonoBehaviour {

	private PlayerController p;
	private Rigidbody2D rigid;
	private bool prev_status;
	private float prev_mass;

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
			//Destroy(gameObject);
			inv_lock = true;
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<PolygonCollider2D>().enabled = false;
			p = other.gameObject.GetComponent<PlayerController>();
			prev_status = p.GetInvincibility();
			rigid = other.gameObject.GetComponent<Rigidbody2D>();
			prev_mass = rigid.mass;
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
		rigid.mass = prev_mass;
		p.SetInvincibility (prev_status);
		Debug.Log ("NOT INV ANYMORE");
		Destroy(gameObject);
	}
}
