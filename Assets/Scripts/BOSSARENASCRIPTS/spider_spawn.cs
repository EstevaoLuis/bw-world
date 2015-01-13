using UnityEngine;
using System.Collections;

public class spider_spawn : MonoBehaviour {

	public GameObject enemy;
	private Animator MagicAppereance;
	private GameObject king;
	private EnemyController enemy_king;
	private int number_of_Swarm = 4;
	private EnemyController [] spider;
	private GameObject [] swarm;
	public GameObject exp;
	private GameObject exp_cop;
	private int enemy_deaths = 5;
	bool  [] spider_alive; 
	

	float dist;
	float actual_dist;

	void create_army(){
		//if (enemy_deaths == 0) {

			swarm [0] = (GameObject)Instantiate (enemy, new Vector2 (transform.position.x + 1, transform.position.y + 15), transform.rotation); 
			swarm [1] = (GameObject)Instantiate (enemy, new Vector2 (transform.position.x + 25, transform.position.y + 15), transform.rotation);
			swarm [2] = (GameObject)Instantiate (enemy, new Vector2 (transform.position.x + 30, transform.position.y + 1), transform.rotation);
			swarm [3] = (GameObject)Instantiate (enemy, new Vector2 (transform.position.x + 1, transform.position.y - 5), transform.rotation);
			//Instantiate(exp, swarm[i].transform.position,transform.rotation);
			//exp.animation.Stop();
			//MagicAppereance.Play("AppearSpider");
			//Destroy (exp);
			int i = 0;
			for (i=0; i < number_of_Swarm; i++) {
					spider [i] = swarm [i].GetComponent <EnemyController> ();
					spider [i].enemyName = "Spider (Noob)";
			//}
		}

	}
	void killed_minion(){
		int i;
		if (spider_alive [0] == false && spider_alive [1] == false && spider_alive [2] == false && spider_alive [3] == false) {
			create_army();
			for (i = 0; i< number_of_Swarm; i++) {
				spider_alive[i] = true;
			}

		}

			if (spider [0].getHealth () < 0) {
					spider_alive [0] = false;
			}
			if (spider [1].getHealth () < 0) {
					spider_alive [1] = false;
			}
			if (spider [2].getHealth () < 0) {
					spider_alive [2] = false;
			}
			if (spider [3].getHealth () < 0) {
					spider_alive [3] = false;
			}
	}


//	bool swarm_creator(){
//
//		int i = 0;
//		for (i = 0; i < number_of_Swarm; i++) {
//			if(spider[i].getHealth() > 0){
//				return false;
//			}
//		}
//		//create_army ();
//		return true;
//	}
	bool check_The_king(){
		//print (enemy_king.getHealth ());
		if (enemy_king.getHealth () <= 0) {

//			int i = 0;
//			for(i = 0; i< number_of_Swarm; i ++){
//				if(swarm[i] != null){
//					//MagicAppereance.Play("AppearSpider");
//					Destroy(swarm[i]);
//				}
//			}
			return false;
		}

		return true;

	}



	// Use this for initialization
	void Start () {

		//king = (GameObject) Instantiate (enemy,new Vector2 (this.transform.position.x + 5*i,this.transform.position.y + 10) ,transform.rotation);
		//MagicAppereance = gameObject.GetComponent <Animator> () as Animator;
		king = GameObject.Find("Mantis");
		enemy_king = king.GetComponent<EnemyController> ();


		int i = 0;

		exp.animation.wrapMode = WrapMode.Once;

		swarm = new GameObject[number_of_Swarm];
		spider = new EnemyController[number_of_Swarm];
		spider_alive = new bool[number_of_Swarm];
		for (i = 0; i< number_of_Swarm; i++) {
			spider_alive[i] = false;
		}
		//create_army();

	}


	// Update is called once per frame
	void Update () {

		print (enemy_deaths);

		if (check_The_king () == true) {
			killed_minion();
		}
	}
}

