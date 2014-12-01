using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {
	
	//public float speed = 3.0f;
	public GameObject animationGraphics1 = null;
	public GameObject animationGraphics2 = null;
	public GameObject animationGraphics3 = null;
	public int damage = 10;
	public float duration = 2.0f;


	private bool hasHit = false;
	private float hitTime, castTime;
	private GameObject animation = null;

	// Use this for initialization
	void Start () {
		audio.Play();
		castTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (hasHit) {
			if(Time.time > hitTime+0.1) {
				Destroy (gameObject);
			}
		}
		else if(Time.time > castTime+duration) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag != "Player") {


						GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
			if(!hasHit) {
					GameObject animation = null;
					switch (Random.Range (1, 3)) {
					case 1:
							animation = animationGraphics1;
							break;
					case 2:
							animation = animationGraphics2;
							break;
					case 3:
							animation = animationGraphics3;
							break;
					}
					animation = (GameObject)Instantiate (animation, transform.position, transform.rotation);
			}

			hasHit = true;
			hitTime = Time.time;

		}
	}

}
