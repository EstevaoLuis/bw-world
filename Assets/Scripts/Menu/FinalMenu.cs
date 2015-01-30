using UnityEngine;
using System.Collections;

public class FinalMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("ChangeScreen");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ChangeScreen()
	{
		yield return new WaitForSeconds(3);
		Application.LoadLevel ("Main Menu");
	}
}
