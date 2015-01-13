using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	public int damage;
	public float period = 4f;
	public Sprite enabledSprite;
	public Sprite disabledSprite;

	private float hitTime, lastChange;
	private bool isEnabled = false;
	private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent <SpriteRenderer>();
		renderer.sprite = disabledSprite;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > lastChange + period) {
			isEnabled = !isEnabled;
			if(isEnabled) renderer.sprite = enabledSprite;
			else renderer.sprite = disabledSprite;
			lastChange = Time.time;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			if(isEnabled && Time.time > hitTime + 1f) {
				GameInstance.instance.damagePlayer(damage);
				GameInstance.instance.playAnimation("Hit", other.gameObject.transform.position);
				hitTime = Time.time;
			}
		}
	}
}
