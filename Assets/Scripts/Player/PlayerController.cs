using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float MoveSpeed = 3f;

	public float direction = 0f;

	public Animator animator = null;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}


	
	// Update is called once per frame
	void Update () {
		//var directionVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

		
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.position -= transform.up * MoveSpeed * Time.deltaTime;
			direction = 0f;
			animator.Play("DownWalk");
			//animation.Play( "walk_cycle" );
		}

		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += transform.up * MoveSpeed * Time.deltaTime;
			direction = 1f;
			animator.Play("UpWalk");
			//animation.Play( "walk_cycle" );
		}

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position -= transform.right * MoveSpeed * Time.deltaTime;
			direction = 2f;
			animator.Play("LeftWalk");
			//animation.Play( "walk_cycle" );
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += transform.right * MoveSpeed * Time.deltaTime;
			direction = 3f;
			animator.Play("RightWalk");
			//animation.Play( "walk_cycle" );
		}

		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			animator.Play("DownNop");
		}

		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			animator.Play("UpNop");
		}
	}
}
