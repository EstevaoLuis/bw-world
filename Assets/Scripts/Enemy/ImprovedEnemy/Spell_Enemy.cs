using UnityEngine;
using System.Collections;

public class Spell_Enemy: MonoBehaviour {

	// Use this for initialization
	private float speed = 5f;
	public int damage;
	private GameObject target;
	int counter = 0;
	public int max_spawn_of_spell;
	private Vector2 direction;

	float x_pos;
	float y_pos;
	float x_player_pos;
	float y_player_pos;
	float diff_x;
	float diff_y;
	
	void shoot_to_player(){

		x_pos = transform.position.x;
		y_pos = transform.position.y;
		
		x_player_pos = target.transform.position.x;
		y_player_pos = target.transform.position.y;
		
		diff_x = x_pos - x_player_pos;
		diff_y = y_pos - y_player_pos;

		if (diff_x < diff_y && diff_x < 0) {
			direction = new Vector2 (1.0f, 0.0f);
			rigidbody2D.velocity = Vector3.right * speed;
		} else if (diff_x > diff_y && diff_x > 0) {
			direction = new Vector2 (-1.0f, 0.0f);
			rigidbody2D.velocity = Vector3.left * speed;
			
		} else if (diff_y < diff_x && diff_y < 0) {
			direction = new Vector2 (0.0f, 1.0f);
			rigidbody2D.velocity = Vector3.up * speed;
			
		} else if (diff_y > diff_x && diff_y > 0) {
			direction = new Vector2 (0.0f, -1.0f);
			rigidbody2D.velocity = Vector3.down * speed;
		}

	}
		

	void Start () {
	
		target = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {

		//transform.Translate (Vector3.up * Time.deltaTime);
		//distance_between ();
		if (counter == max_spawn_of_spell) {
			Destroy(gameObject);
			counter=0;
		}
		shoot_to_player ();
		counter++;
//		if (transform.position.y > 5) {
//			Destroy(gameObject);		
//		}
		
	}
}
