using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	public string message;

	public float yCorrection = 0f;

	private GameObject textObject;

	private bool isCentered = false;
	private bool isVisible = false;

	FadeObjectInOut fadingText;

	// Use this for initialization
	void Start () {
		BoxCollider2D collider = GetComponent<BoxCollider2D> () as BoxCollider2D;
		Vector3 textPosition = new Vector3 (transform.position.x, transform.position.y + collider.bounds.size.y, -1f);
		textObject = GameInstance.instance.showNPCText (message, textPosition);
		fadingText = textObject.GetComponent("FadeObjectInOut") as FadeObjectInOut;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isCentered) {
			textObject.transform.position = new Vector3(textObject.transform.position.x - (textObject.renderer.bounds.size.x / 2f),textObject.transform.position.y + (textObject.renderer.bounds.size.y) - 1f + yCorrection, -1f);
			isCentered = true;
			textObject.SetActive (false);
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			textObject.SetActive (true);
			fadingText.FadeIn (1);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			textObject.SetActive (true);
			fadingText.FadeOut (1);
		}
	}
}
