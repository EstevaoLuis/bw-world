using UnityEngine;
using System.Collections;
using SimpleJSON;


public class simone_says : MonoBehaviour {

	private GameObject gem_r;
	private GameObject gem_g;
	private GameObject gem_b;
	private GameObject gem;
	private GameObject spell;
	private Spell sp;

	private JSONNode spells;

	bool toblink;
	private int number_of_colors = 3;
	string type_of_spell;
	int max_l = 3;
	int [] arr;
	int actual_round = 1;
	int actual = 1;
	int counter = 0;
	int max_counter = 10;
	double timer_0;
	double timer_1;
	double timer_2;
	double timer;
	double timer_one;
	double timer_two;
	int i = 0;
	int j = 0;
	int [] player_arr;
	bool playing;

	// Use this for initialization
	void Start () {

		gem_r = GameObject.Find("Red");
		gem_b = GameObject.Find("Blue");
		gem_g = GameObject.Find("Green");
		gem = GameObject.Find("Lever");
		arr = new int[max_l];
		//create_game_random_array ();

		
		timer= Time.time + 1;
		timer_one = Time.time + 2;
		timer_two = Time.time + 3;


		gem_r.renderer.material.color = Color.red;
		gem_g.renderer.material.color = Color.green;
		gem_b.renderer.material.color = Color.blue;


		timer_0 = Time.time;
		timer_1 = Time.time;
		timer_2 = Time.time;

		arr [0] = 1;
		arr [1] = 2;
		arr [2] = 3;

//		spells = GameObject.FindGameObjectWithTag("Spell");
//		sp = spell.GetComponent<Spell> ();
	}

	void create_game_random_array(){

		int i;

		Random rand = new Random ();

		int r; 

		for (i = 0; i< max_l; i++) {

			r = Random.Range (1 , number_of_colors+1);

			arr [i] = r;

		}

	}
	void print_seq(){
		int i;
		for (i = 0; i < max_l; i++) {
				print (arr [i]);
		}
	}

	void blink_gem(int type){

		if (type == 1) {

			flash_red_gem();
			print ("red");

		}
		if (type == 2) {
			
			flash_green_gem();
			print ("green");

			
		}
		if (type == 3) {
			
			flash_blue_gem();
			print ("blue");
		
		}
	}


	void flash_red_gem(){
		gem_r.renderer.enabled = false;
	}

	void flash_green_gem(){
		gem_g.renderer.enabled = false;
	}
	void flash_blue_gem(){
		gem_b.renderer.enabled = false;
	}
	
	bool check_spell(int player_t, int gem_color){
	if (player_t == gem_color) {
			return true;
		} else {
			return false;
		}
	}

	void disp(){
	
		if (Time.time > timer) {

			blink_gem (arr [i]);
			timer = Time.time + 2;
	
		}
		if (Time.time > timer_one) {

			gem_r.renderer.enabled = true;
			gem_g.renderer.enabled = true;
			gem_b.renderer.enabled = true;
			timer_one = Time.time + 2;
		}
	}



	// Update is called once per frame
	void Update () {

		disp ();
	}
}
