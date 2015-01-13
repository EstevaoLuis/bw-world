using UnityEngine;
using System.Collections;

public class CameraControllerV2 : MonoBehaviour {

	public float horizontalSize = 4f;
	public float verticalSize = 4f;

	private GameObject player;
	private PlayerController controller;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		controller = player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = player.transform.position;
		float dX = player.transform.position.x - transform.position.x;
		float dY = player.transform.position.y - transform.position.y;
		Vector2 direction = controller.getDirection ();
		if(direction.y == 1 && dY > verticalSize) transform.position = new Vector3(transform.position.x, player.transform.position.y - verticalSize, transform.position.z);
		else if(direction.y == -1 && dY < -verticalSize) transform.position = new Vector3(transform.position.x, player.transform.position.y + verticalSize, transform.position.z);
		else if(direction.x == 1 && dX > horizontalSize) transform.position = new Vector3(player.transform.position.x - horizontalSize, transform.position.y, transform.position.z);
		else if(direction.x == -1 && dX < -horizontalSize) transform.position = new Vector3(player.transform.position.x + horizontalSize, transform.position.y, transform.position.z);
	}
}
