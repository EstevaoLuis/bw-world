using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float MoveSpeed = 3f;

	public GameObject RedSphere;

	public Animator animator = null;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}


	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.position -= transform.up * MoveSpeed * Time.deltaTime;
			animator.Play("DownWalk");
		}

		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += transform.up * MoveSpeed * Time.deltaTime;
			animator.Play("UpWalk");
		}

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position -= transform.right * MoveSpeed * Time.deltaTime;
			animator.Play("LeftWalk");
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += transform.right * MoveSpeed * Time.deltaTime;
			animator.Play("RightWalk");
		}

		if (Input.GetMouseButtonDown(0)) {
			GameObject Fireball = (GameObject) Instantiate(RedSphere, (transform.position + new Vector3(3,3,0)), transform.rotation);
			Fireball.rigidbody2D.velocity = transform.TransformDirection(Vector2.right * 3);
		}

	}
}
