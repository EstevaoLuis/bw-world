using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {

	public float duration = 1.0f;	
	public float transition = 0.5f;	

	private float time = 0.0f;
	private Color hidden = new Color (1, 1, 1, 0);
	private Color visible = new Color (1, 1, 1, 1);

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(time > duration+transition) {
			Destroy (gameObject);
		}
		else if (time > duration) {
			GetComponent<SpriteRenderer> ().color = Color.Lerp(visible,hidden,(time-duration)/transition);
			time += Time.deltaTime;
		}
		time += Time.deltaTime;
	}
}
