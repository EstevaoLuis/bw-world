using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float MoveSpeed = 3f;

	public GameObject RedSphere;
	
	public Animator animator = null;
	//private GameInstance game = GameInstance.instance;
	private Vector2 direction; //0 is face-down, then increases clockwise

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		direction = new Vector2(0.0f,-1.0f);
	}


	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.DownArrow)) {
			//transform.position -= transform.up * MoveSpeed * Time.deltaTime;
			animator.Play ("DownWalk");
			direction = new Vector2 (0.0f, -1.0f);
			rigidbody2D.velocity = direction*MoveSpeed;
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			//transform.position += transform.up * MoveSpeed * Time.deltaTime;
			animator.Play ("UpWalk");
			direction = new Vector2 (0.0f, 1.0f);
			rigidbody2D.velocity = direction*MoveSpeed;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			//transform.position -= transform.right * MoveSpeed * Time.deltaTime;
			animator.Play ("LeftWalk");
			direction = new Vector2 (-1.0f, 0.0f);
			rigidbody2D.velocity = direction*MoveSpeed;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			//transform.position += transform.right * MoveSpeed * Time.deltaTime;
			animator.Play ("RightWalk");
			direction = new Vector2 (1.0f, 0.0f);
			rigidbody2D.velocity = direction*MoveSpeed;
		} else {
			rigidbody2D.velocity = new Vector2(0,0);
		}

		if (Input.GetMouseButtonDown(0)) {
			GameObject Fireball = (GameObject) Instantiate(RedSphere, (transform.position + new Vector3(direction.x, direction.y, 0)), transform.rotation);
			Fireball.rigidbody2D.velocity = transform.TransformDirection(direction * 3);
			GameInstance.instance.setHealth(100);
		}

	}
}
