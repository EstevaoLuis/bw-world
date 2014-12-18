using UnityEngine;
using System.Collections;

public class FloatingText : MonoBehaviour {


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
