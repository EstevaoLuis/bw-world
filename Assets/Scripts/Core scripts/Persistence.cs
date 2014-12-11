using UnityEngine;
using System.Collections;

public class Persistence : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}

}
