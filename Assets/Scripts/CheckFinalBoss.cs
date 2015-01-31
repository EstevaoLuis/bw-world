using UnityEngine;
using System.Collections;

public class CheckFinalBoss : MonoBehaviour {

	public GameObject boss;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (boss == null)
			StartCoroutine ("ChangeScreen");
	}

	IEnumerator ChangeScreen()
	{
		yield return new WaitForSeconds(3);
		GameInstance.instance.destroyInstance ();
		UserInterface.instance.destroyInstance ();
		Application.LoadLevel ("FinalScene");
	}
}
