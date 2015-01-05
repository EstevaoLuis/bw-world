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
		//print ("DEBUG");
		if (player.transform.position.x < transform.position.x && player.transform.position.y < transform.position.y) {
				print (1);
				return 1;
		} else if (player.transform.position.x < transform.position.x && player.transform.position.y > transform.position.y) {
				print (-1);
				return -1;
		} else if (player.transform.position.x > transform.position.x && player.transform.position.y < transform.position.y) {
				print (2);
				return 2;
		} else if (player.transform.position.x > transform.position.x && player.transform.position.y > transform.position.y) {
				print (-2);
				return -2;
		} else {
				return 0;
		}

	}
//	void moveRotate2D(){
//
//		if (quadrant() == 1) {
//
//			//transform.rigidbody2D.AddForce = Vector3.down * ang_velocity;
//			
//			}
//			//transform.position = new Vector3(player.transform.position.x+radio*ang_velocity,player.transform.position.y-radio*ang_velocity);	
//
////		if (quadrant() == -1) {
////			transform.position = new Vector3(player.transform.position.x+radio*ang_velocity,player.transform.position.y-radio*ang_velocity);	
////		}
////		if (quadrant() == 2) {
////			transform.position = new Vector3(player.transform.position.x-radio*ang_velocity,player.transform.position.y+radio*ang_velocity);	
////		}
////		if (quadrant() == -2) {
////			transform.position = new Vector3(player.transform.position.x-radio*ang_velocity,player.transform.position.y-radio*ang_velocity);	
////		}
//	
//	}
	// Update is called once per frame
	void Update () {
		transform.rigidbody2D.AddForce (20 * Vector3.up);
		//transform.RotateAround (Player.transform.position, Vector2.up, 20 * Time.deltaTime);
		//transform.Rotate (0, 0, 1);
		//transform.rigidbody2D.angularVelocity = 20;


	}
}
