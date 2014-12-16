using UnityEngine;
using System.Collections;
using SimpleJSON;


public class simone_says : MonoBehaviour {

	private GameObject gem_r;
	private GameObject gem_g;
	private GameObject gem_b;
	private GameObject gem;
	private Spell sp;

	private JSONNode spells;

	bool toblink;
	private int number_of_colors = 3;
	string type_of_spell;
	int max_l = 10;
	int [] arr;
	int actual_round = 10;
	int counter = 0;
	int max_counter = 10;
	double timer_0;
	double timer_1;
	double timer_2;
	double timer;
	double timer_one;
	int i = 0;
	int j = 0;
	int [] player_arr;
	//	double timer = 13;

	// Use this for initialization
	void Start () {

		gem_r = GameObject.Find("Red");
		gem_b = GameObject.Find("Blue");
		gem_g = GameObject.Find("Green");
		gem = GameObject.Find("Lever");
		arr = new int[max_l];
		create_game_random_array ();
		sp = gameObject.GetComponent<Spell> ();
//		print (arr[0]);
//		print (arr[1]);
//		print (arr[2]);

		
		timer= Time.time + 1;
		timer_one = Time.time + 2;


		gem_r.renderer.material.color = Color.red;
		gem_g.renderer.material.color = Color.green;
		gem_b.renderer.material.color = Color.blue;


		timer_0 = Time.time;
		timer_1 = Time.time;
		timer_2 = Time.time;

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

//	void display_seque(){
//		//print ("debug");
//		int i = 0;
//		timer = Time.time;
//		for (i = 0; i < actual_round; i ++) {
//
//			if(arr[i] == 0){
//				if(Time.time > timer){
//					print ("blinkeoRojo");
//					flash_red_gem();
//					timer = Time.time+ 0.5;
//				}
//		
//			}
//			if(arr[i] == 1){
//				if(Time.time > timer){
//					print ("blinkeoVerde");
//					flash_green_gem();
//					timer = Time.time+ 0.5;
//				}
//			
//			}
//			if(arr[i] == 2){
//				if(Time.time > timer){
//					print ("blinkeoAzul");
//					flash_blue_gem();
//					timer = Time.time+ 0.5;
//				}
//					
//			
//			}
//
//		}
//
//	}
//	void display_seque(){
//		//print ("debug");
//		int i = 0;
//		double timer = 3;
//		for (i = 0; i < actual_round; i ++) {
//			
//			if(arr[i] == 0){
//				print ("blinkeoRojo");
//				if (Time.time > timer) {
//					timer = Time.time + .5;
//					//print (timer);
//					//timer = Time.time + 5;
//					gem_r.renderer.enabled = false;
//					//print (gem_r.renderer.enabled);
//				} else {
//					gem_r.renderer.enabled = true;
//					//print (gem_r.renderer.enabled);
//				}
//
//			}else if(arr[i] == 1){
//				print ("blinkeoVerde");
//				if (Time.time > timer) {
//					timer = Time.time + .5;
//					//timer = Time.time + .5;
//					//print (timer);
//					//timer = Time.time + 5;
//					gem_r.renderer.enabled = false;
//					//print (gem_r.renderer.enabled);
//				} else {
//					gem_r.renderer.enabled = true;
//					//print (gem_r.renderer.enabled);
//				}
//
//			}else{
//				print ("blinkeoAzul");
//				if (Time.time > timer) {
//					timer = Time.time + .5;
//					//timer = Time.time + .5;
//					//print (timer);
//					//timer = Time.time + 5;
//					gem_r.renderer.enabled = false;
//					//print (gem_r.renderer.enabled);
//				} else {
//					gem_r.renderer.enabled = true;
//					//print (gem_r.renderer.enabled);
//				}
//			
//			}
//			
//		}
//		
//	}
//	void display_seque(int act){
//				//print ("debug");
//				int i = 0;
//
//		while (i < act) {
//				if (arr [i] == 1) {
//				print ("blinkeoRojo");
//				flash_red_gem ();
//			//	stop_blink();
//
//
//				} else if (arr [i] == 2) {
//				print ("blinkeoVerde");
//				flash_green_gem ();
//			//	stop_blink();
//
//
//
//				} else if (arr [i] == 3) {
//				print ("blinkeoAzul");
//				flash_blue_gem ();
//			//	stop_blink();
//
//
//			}
//			i ++;
//		}
//	}

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
//		gem_r.renderer.enabled = true;
//		gem_g.renderer.enabled = true;
//		gem_b.renderer.enabled = true;

		
	}

//	void blink_seq(){
//
//		int i = 0;
//
//		for (i=0; i < actual_round; i++) {
//
//			blink_gem(arr[i]);
//
//		}
//
//
//
//	}
//	void display_seque(int act){
////		print ("debug");
//		int i = 0;
//		act = actual_round;
//		
//		for (i = 0; i < act; i ++) {
//			
//			if(arr[i] == 1){
//
//				print ("blinkeoRojo");
//
//				if(Time.time > timer){
//				
//				timer = Time.time + .5;
//
//				gem_r.renderer.enabled = false;
//
//				}else{
//				
//				gem_r.renderer.enabled = true;
//				
//				}
//				
//			}else if(arr[i] == 2){
//
//				print ("blinkeoVerde");
//				
//				if(Time.time > timer){
//
//				timer = Time.time + .5;
//				
//				gem_g.renderer.enabled = false;
//					
//				}else{
//
//				gem_g.renderer.enabled = true;
//
//				}
//
//				
//			}else{
//
//				print ("blinkeoAzul");
//				
//				if(Time.time > timer){
//
//				timer = Time.time + .5;
//				
//				gem_b.renderer.enabled = false;
//					
//				}else{
//
//				gem_b.renderer.enabled = true;
//
//				}
//			}
//		}
//			
//	}
//

//	void flash_red_gem(){
//		while (counter < max_counter) {
//			gem_r.renderer.material.color = Color.black;
//			print ("black");
//			counter++;
//		}
//		gem_r.renderer.material.color = Color.red;
//		print ("red");
//		counter = 0;
//	}
//	void flash_red_gem(){
//		gem_r.renderer.material.color = Color.red;
//	}
//	void stop_blink(){
//
//		gem_r.renderer.enabled = true;
//		gem_g.renderer.enabled = true;
//		gem_b.renderer.enabled = true;
//
//	}
	void flash_red_gem(){

//
//		if (Time.time > timer_0) {
			//timer_0 = Time.time + .5;
			//print (timer);
			//timer = Time.time + 5;
			gem_r.renderer.enabled = false;
			//timer_0 = Time.time + 5;
			//print (gem_r.renderer.enabled);

//		gem_r.renderer.enabled = true;
//		gem_g.renderer.enabled = true;
//		gem_b.renderer.enabled = true;
		

		//timer_0 = Time.time + .5;
//		print ("red");
//		print (timer_0);
	}

	void flash_green_gem(){

		//if (Time.time > timer_1) {
			//print (timer);
			//timer = Time.time + 5;
			gem_g.renderer.enabled = false;
			//timer_1 = Time.time + 5;

			//print (gem_r.renderer.enabled);
		//}
//
//		gem_r.renderer.enabled = true;
//		gem_b.renderer.enabled = true;

		//timer_1 = Time.time + .5;
//		print ("green");
//		print (timer_1);
		
	}
	void flash_blue_gem(){

		//if (Time.time > timer_2) {
			//print (timer);
			//timer = Time.time + 5;
			gem_b.renderer.enabled = false;
			//timer_2 = Time.time + 5;
			//print (gem_r.renderer.enabled);
		//} 
//		gem_r.renderer.enabled = true;
//		gem_g.renderer.enabled = true;
		//timer_2 = Time.time + 5;
		//timer_2 = Time.time + .5;
//		print ("blue");
//		print (timer_2);
	}
//	void OnCollisionEnter2D(Collision2D other){
//
//		if (other.gameObject.tag == "Spell") {
//
//			sp.
//
//
//			//this.rigidbody2D.isKinematic = false;
//			//this.rigidbody2D.mass = 100;
//			//this.rigidbody2D.fixedAngle = false;
//		}
//		//this.rigidbody2D.AddForce(Vector2.up*0);
//		
//	}

	// Update is called once per frame
	void Update () {

		if (Time.time > timer ) {
			blink_gem (arr [i]);
			timer= Time.time + 2;
			i++;
		}

		if (Time.time > timer_one) {

			gem_r.renderer.enabled = true;
			gem_g.renderer.enabled = true;
			gem_b.renderer.enabled = true;
			timer_one = Time.time + 2;

		}
//		if (arr [i] == 1) {
//			gem_r.renderer.enabled = true;
//		}
//		if (arr [i] == 2) {
//			gem_g.renderer.enabled = true;
//		}
//		if (arr [i] == 3) {
//			gem_b.renderer.enabled = true;
//		}
	}
}

//		if (i == 9) {
//			i = 0;
//		}
		//display_seque ();
		//display_seque ();
//		flash_black_gem ();
		
//		flash_blue_gem ();
//			flash_red_gem ();
//			flash_green_gem ();
//			flash_blue_gem ();
		//display_seque (actual_round);
		//blink_seq ();
//		print ("END");
//		int i = 0;
//		while (i < actual_round) {
//			blink_gem (1);
//			blink_gem (2);
//			blink_gem (3);
//			i++;
//		}
		//blink_gem (1);
		//blink_gem(1);
	


//		if (arr [i] == 1) {
//			gem_r.renderer.enabled = true;
//		}
//		if (arr [i] == 2) {
//			gem_g.renderer.enabled = true;
//		}
//		if (arr [i] == 3) {
//			gem_b.renderer.enabled = true;
//		}
//			if(arr[i] == 1){
//				gem_r.renderer.enabled = true;
//			}else if(arr[i] == 2){
//				gem_g.renderer.enabled = true;
//			}else{
//				gem_b.renderer.enabled = true;
//			}
//			if (Time.time < timer_0) {
//				
//				gem_r.renderer.enabled = true;
//				
//			}
//			if (Time.time < timer_1) {
//				
//				gem_g.renderer.enabled = true;
//				
//			}
//			if (Time.time < timer_2) {
//				
//				gem_b.renderer.enabled = true;
//				
//			}
		

//		if (Time.time < 5 * i) {
//
//			gem_r.renderer.enabled = true;
//			gem_g.renderer.enabled = true;
//			gem_b.renderer.enabled = true;
//
//		}

//		print_seq ();



//		display_seque (actual_round);


