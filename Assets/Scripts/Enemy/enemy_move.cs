using UnityEngine;
using System.Collections;

public class enemy_move : MonoBehaviour {

	public float MoveSpeed = 1f;
	public Animator animator = null;

	public int counter = 0;
	public int max_value = 7;
	private int random_direction = 0;

	public float box_x1 = 0f;
	public float box_x2 = 10f;
	public float box_y1 = 0f;
	public float box_y2 = 10f;

	private float enemyPosX;
	private float enemyPosY;

	private int updownlimit;
	private int leftrightlimit;

	void Start () {
		ChangeDirection ();
		animator = GetComponent<Animator> ();
	}

	void ChangeDirection(){
		enemyPosX = transform.position.x;
		enemyPosY = transform.position.y;

		updownlimit = 49 * ((int) (box_y2 - enemyPosY)) / ((int) (box_y2 - box_y1));
		leftrightlimit = 50 + (49 * ((int)(box_x2 - enemyPosX)) / ((int)(box_x2 - box_x1)));

		random_direction = Random.Range (0, 125);
	}
	
	void random_movement(){


		if (random_direction < updownlimit) {
			go_Up();
		}
		else if (random_direction < 50) {
			go_Down();
		}
		else if (random_direction < leftrightlimit) {
			go_Right();
		}
		else if (random_direction < 100) {
			go_Left();
		}
		else {
			stay ();
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

	void stay(){
		}
	void go_Up(){
		transform.Translate (Vector3.up * MoveSpeed * Time.deltaTime);
		animator.Play("UpEnemyWalk");
	}
	void go_Down(){
		transform.Translate (Vector3.down * MoveSpeed * Time.deltaTime);
		animator.Play("DownEnemyWalk");
	}
	void go_Left(){
		transform.Translate (Vector3.left * MoveSpeed * Time.deltaTime);
		animator.Play("LeftEnemyWalk");
	}
	void go_Right(){
		transform.Translate (Vector3.right * MoveSpeed * Time.deltaTime);
		animator.Play("RightEnemyWalk");
	}

//
//	IEnumerator WaitFunc() {
//			yield return new WaitForSeconds(2f);
//	}
}
