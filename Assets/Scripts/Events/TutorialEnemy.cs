using UnityEngine;
using System.Collections;

public class TutorialEnemy : MonoBehaviour {

	private int status_lever = -1;
	private GameObject Tutorial_Enemy;
	private EnemyController tut_enem;

	// Use this for initialization

	public int getStatus_Lever(){

		return status_lever;

	}

	void Start () {
		Tutorial_Enemy = GameObject.FindGameObjectWithTag("Enemy");
		tut_enem = Tutorial_Enemy.GetComponent<EnemyController> ();
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Spell") {
			status_lever = 1;
		}
	}

//	void check_status(){
//		//print (-1);
//		if () {
//			status_lever = 1;
//		print (status_lever);
//		}
//	}



	// Update is called once per frame
	void Update () {
		print (status_lever);

	}
}
