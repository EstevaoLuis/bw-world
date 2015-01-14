using UnityEngine;
using System.Collections;

public class MusicChange : MonoBehaviour {

	private bool isActive = false;
	private ThemeAudio themeAudio;

	void Start () {
		GameObject audioController = GameObject.FindWithTag ("AudioController");
		themeAudio = audioController.GetComponent ("ThemeAudio") as ThemeAudio;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(!isActive && other.gameObject.tag=="Player") {
			isActive = true;
			themeAudio.playTheme("Battle4");
		}
	}
}
