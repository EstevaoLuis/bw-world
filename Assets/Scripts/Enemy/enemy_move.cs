using UnityEngine;
using System.Collections;

public class enemy_move : MonoBehaviour {

	public float MoveSpeed = 1f;
	public Animator animator = null;

	public int counter = 0;
	public int max_value = 7;
	private int random_direction = 0;

	void Start () {
		ChangeDirection ();
	}

	void ChangeDirection(){
		random_direction = Random.Range (0, 5);
	}
	
	void random_movement(){
		if (random_direction == 0) {}

		if (random_direction == 1) {
			transform.Translate (Vector3.up * MoveSpeed * Time.deltaTime);
		}

		if (random_direction == 2) {
			transform.Translate (Vector3.down * MoveSpeed * Time.deltaTime);
		}

		if (random_direction == 3) {
			transform.Translate (Vector3.left * MoveSpeed * Time.deltaTime);
		}

		if (random_direction == 4) {
			transform.Translate (Vector3.right * MoveSpeed * Time.deltaTime);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (counter == max_value) {
			ChangeDirection();
			counter = 0;
				}
		random_movement ();
		counter++;
	}

//
//	IEnumerator WaitFunc() {
//			yield return new WaitForSeconds(2f);
//	}
}
