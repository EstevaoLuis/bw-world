using UnityEngine;
using System.Collections;

public class FloatingText : MonoBehaviour {
	
	
	private float hidden = 1f;
	private float visible = 20f;

	public string message;
	private TextMesh displayText;

	// Use this for initialization
	void Start () {
		displayText = GetComponent<TextMesh> ();
		displayText.text = message;
	}
	
	// Update is called once per frame
	void Update () {

	}

}
