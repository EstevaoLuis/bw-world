using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float MoveSpeed = 3f;
	

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

	}
}
