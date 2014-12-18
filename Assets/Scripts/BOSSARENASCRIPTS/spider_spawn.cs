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

	float dist;
	float actual_dist;

	void create_army(){

		swarm = new GameObject[number_of_Swarm];
		spider = new EnemyController[number_of_Swarm];
		int i = 0;
		for (i = 0; i< number_of_Swarm; i++) {
			swarm [i] = (GameObject) Instantiate (enemy,new Vector2 (-16,53) ,transform.rotation); 
			//Instantiate(exp, swarm[i].transform.position,transform.rotation);
			//exp.animation.Stop();
			//MagicAppereance.Play("AppearSpider");
			spider [i] = swarm[i].GetComponent <EnemyController> ();
			spider[i].enemyName = "Spider (Noob)";
		}
		//Destroy (exp);
		
	}
	bool swarm_creator(){

		int i = 0;
		for (i = 0; i < number_of_Swarm; i++) {
			if(spider[i].getHealth() > 0){
				return false;
			}
		}
		create_army ();
		return true;
	}
	bool check_The_king(){

		if (enemy_king.getHealth () <= 0) {
			int i = 0;
			for(i = 0; i< number_of_Swarm; i ++){
				if(swarm[i] != null){
					//MagicAppereance.Play("AppearSpider");
					Destroy(swarm[i]);
				}
			}
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
		create_army ();

		int i = 0;

		exp.animation.wrapMode = WrapMode.Once;

		for (i = 0; i< number_of_Swarm; i++) {
		
			exp_cop = (GameObject)Instantiate(exp, swarm[i].transform.position,transform.rotation);
		
		}

	}


	// Update is called once per frame
	void Update () {

		if (check_The_king ()) {
			swarm_creator ();
		}

	}
}
