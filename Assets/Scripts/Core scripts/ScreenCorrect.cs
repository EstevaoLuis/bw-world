using UnityEngine;
using System.Collections;

public class ScreenCorrect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector2(Screen.width*transform.position.x,Screen.height*transform.position.y);
	}
	

}
