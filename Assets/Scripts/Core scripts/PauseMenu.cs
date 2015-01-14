using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject menuP;
	private bool status = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			Time.timeScale = 1 - Time.timeScale;
			status = !status;
			menuP.SetActive(status);
		}
	}
}
