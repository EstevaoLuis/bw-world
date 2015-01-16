using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	public GameObject panel;

	// Use this for initialization
	void Start () {
		StartCoroutine ("ChangeScreen");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ChangeScreen()
	{
		yield return new WaitForSeconds(2);
		Destroy (panel);
		yield return new WaitForSeconds(2);
		Application.LoadLevel ("Main Menu");
	}
}
