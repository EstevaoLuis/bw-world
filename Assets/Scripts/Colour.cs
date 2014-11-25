using UnityEngine;
using System.Collections;

public class Colour : MonoBehaviour {

	public bool isColoured = false;
	public float duration = 3.0f;

	private Color spriteColor;
	private float time = 0.0f; 
	private Color hidden = new Color (1, 1, 1, 0);
	private Color visible = new Color (1, 1, 1, 1);
	private bool transition = false;

	// Use this for initialization
	void Start () {
		if (isColoured) {
			GetComponent<SpriteRenderer> ().color = hidden;
		} else {
			GetComponent<SpriteRenderer> ().color = visible;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (transition && time <= duration) {
			if (isColoured) {
				GetComponent<SpriteRenderer> ().color = Color.Lerp(hidden,visible,time/duration);
			} else {
				GetComponent<SpriteRenderer> ().color = Color.Lerp(visible,hidden,time/duration);
			}
			time += Time.deltaTime;
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (isColoured && !transition) {
			audio.Play();
		}
		transition = true;
	}

}
