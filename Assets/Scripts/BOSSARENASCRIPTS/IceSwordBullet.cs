using UnityEngine;
using System.Collections;

public class IceSwordBullet : MonoBehaviour {

	private float timer = 4f;
	public GameObject iceBomb;
	private string nam;
	//private GameObject sword;
	// Use this for initialization
	void Start () {
		nam = this.name;
		print (nam);
	}


	// Update is called once per frame
	void Update () {

	}
}
