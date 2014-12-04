using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Vector2 direction;
	public GameObject camera;

	private bool isColliding = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D() {
		isColliding = true;
	}

	void OnCollisionExit2D() {
		isColliding = false;
	}

}
