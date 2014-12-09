using UnityEngine;
using System.Collections;

public class movementTut : MonoBehaviour {

	// Use this for initialization
	private Vector3 point_1;
	private Vector3 point_2;
	private GameObject player;
	int check_point_1 = -1;
	int check_point_2 = -1;

	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player");
		point_1 = new Vector3 (5f, 5f, 0);
		point_2 = new Vector3 (-5f, -5f, 0);

	}

	void on_point_1(){
		if (Vector3.SqrMagnitude(player.transform.position - point_1) < 0.1f) {
			check_point_1 = 1; 		
		}
	}

	void on_point_2(){
		if (Vector3.SqrMagnitude(player.transform.position - point_2) < 0.1f) {
			check_point_2 = 1;		
		}
	}

	bool mov_tutorial_completed(){

		if (check_point_1 == 1 && check_point_2 == 1) {
			return true;
		}
		return false;

	}

	// Update is called once per frame
	void Update () {
		on_point_1 ();
		on_point_2 ();
		print (mov_tutorial_completed());
	}
}
