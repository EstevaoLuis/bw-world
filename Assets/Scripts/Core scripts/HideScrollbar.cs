using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HideScrollbar : MonoBehaviour {

	Scrollbar scrollbar;

	// Use this for initialization
	void Start () {
		scrollbar = GetComponent<Scrollbar> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (scrollbar.size == 1) gameObject.SetActive (false);;
	}
}
