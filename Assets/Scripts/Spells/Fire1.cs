using UnityEngine;
using System.Collections;

public class Fire1 : MonoBehaviour {


	public float speed = 3.0f;
	public GameObject animationGraphics = null;

	private bool hasHit = false;
	private float hitTime;
	private GameObject animation = null;

	// Use this for initialization
	void Start () {
		audio.Play();
		//rigidbody2D.velocity = new Vector2(3,10);
	}
	
	// Update is called once per frame
	void Update () {
		if (hasHit) {
			if(Time.time > hitTime+0.1) {

			}
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		hasHit = true;
		hitTime = Time.time;
		Debug.Log (transform.position);
		animation = (GameObject) Instantiate(animationGraphics, transform.position, transform.rotation);
		Invoke("StopAnimation", 1);
	}

	void StopAnimation() {
		Destroy (animation.gameObject);
		Destroy (gameObject);
	}

}
