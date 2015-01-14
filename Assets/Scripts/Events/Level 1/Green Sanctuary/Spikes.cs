using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	public int damage;
	public float period = 4f;
	//public Sprite enabledSprite;
	//public Sprite disabledSprite;
	public GameObject onPrefab, offPrefab;


	private GameObject onAnimation, offAnimation;
	private float hitTime, lastChange;
	private bool isEnabled = false;
	private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent <SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > lastChange + period) {
			isEnabled = !isEnabled;
			if(isEnabled) {
				renderer.sprite = null;
				onAnimation = (GameObject) GameObject.Instantiate(onPrefab, transform.position, new Quaternion(0f,0f,0f,1f));
				if(offAnimation != null) Destroy(offAnimation);
			}
			else {
				renderer.sprite = null;
				offAnimation = (GameObject) GameObject.Instantiate(offPrefab, transform.position, new Quaternion(0f,0f,0f,1f));
				if(onAnimation != null) Destroy(onAnimation);
			}
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
