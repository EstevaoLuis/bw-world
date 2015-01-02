using UnityEngine;
using System.Collections;

public class shieldSpell : MonoBehaviour {

	private GameObject player;
	private int quad;
	private int radio = 5;
	private int ang_velocity=2;
	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag("Player");

	}
	int quadrant(){

		if (player.transform.position.x < transform.position.x && player.transform.position.y < transform.position.y) {
			return 1;
		}
		if (player.transform.position.x < transform.position.x && player.transform.position.y > transform.position.y) {
			return -1;
		}
		if (player.transform.position.x > transform.position.x && player.transform.position.y < transform.position.y) {
			return 2;
		}
		if (player.transform.position.x > transform.position.x && player.transform.position.y > transform.position.y) {
			return -2;
		}
		return 0;

	}
	void moveRotate2D(){

		if (quadrant() == 1) {
			transform.position = new Vector3(player.transform.position.x+radio*ang_velocity,player.transform.position.y+radio*ang_velocity);	
		}
		if (quadrant() == -1) {
			transform.position = new Vector3(player.transform.position.x+radio*ang_velocity,player.transform.position.y-radio*ang_velocity);	
		}
		if (quadrant() == 2) {
			transform.position = new Vector3(player.transform.position.x-radio*ang_velocity,player.transform.position.y+radio*ang_velocity);	
		}
		if (quadrant() == -2) {
			transform.position = new Vector3(player.transform.position.x-radio*ang_velocity,player.transform.position.y-radio*ang_velocity);	
		}

	}
	// Update is called once per frame
	void Update () {
		quadrant ();
		moveRotate2D ();
		//transform.RotateAround (Player.transform.position, Vector2.up, 20 * Time.deltaTime);
		//transform.Rotate (0, 1, 0);
		//transform.rigidbody2D.angularVelocity = 20;


	}
}
