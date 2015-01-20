using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingText : MonoBehaviour {

	Text loadingText;

	private float lastChange = 0f;
	
	// Use this for initialization
	void Start () {
		loadingText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > lastChange + 0.5f) {
			lastChange = Time.time;
			if(loadingText.text == "Loading") loadingText.text = "Loading .";
			else if(loadingText.text == "Loading .") loadingText.text = "Loading ..";
			else if(loadingText.text == "Loading ..") loadingText.text = "Loading ...";
			else loadingText.text = "Loading";
		}
	}
}
