using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public GameObject exp;
	//private Animator exp_anim;
	private GameObject exp_cop;
	int lifes = 3;

	//private GameObject exp_cop;
	// Use this for initialization
	void Start () {
	
		//exp_anim = exp.GetComponent<Animator> ();
		//exp = GameObject.FindGameObjectWithTag("mine");

	}

	void OnCollisionEnter2D (Collision2D other){

		lifes--;
		exp_cop = (GameObject)Instantiate (exp, transform.position,transform.rotation);
		//exp.animation.wrapMode = WrapMode.Once;


		if (lifes == 1) {
			gameObject.renderer.material.color = Color.red;
		}

//		
		if (lifes == 0) {


			Destroy (other.gameObject);
			Destroy(gameObject);

		}
//		if (counter == max_counter) {
//			Destroy (exp_cop);
//			counter = 0;
//		}
//		counter ++;
//	
	}

	// Update is called once per frame
	void Update () {

		//exp.animation.wrapMode = WrapMode.Once;

	}
}
