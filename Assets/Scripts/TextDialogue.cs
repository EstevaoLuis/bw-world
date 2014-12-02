using UnityEngine;
using System.Collections;

public class TextDialogue : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}



	// Update is called once per frame
	void Update () {
		if (GameInstance.show_text)
						guiText.text = GameInstance.text_to_show;

		if (Input.GetKeyDown (KeyCode.A))
						GameInstance.show_text = false;
	}
}
