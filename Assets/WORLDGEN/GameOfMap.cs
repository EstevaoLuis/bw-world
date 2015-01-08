using UnityEngine;
using System.Collections;
//This program is my adapted version of Conway's game of Life. 
//By Felix Hazen Gonzalez
public class GameOfMap : MonoBehaviour {

	private int numbElements_x = 16;
	private int numbElements_y = 16;
	public GameObject water;
	public GameObject terrain;
	public GameObject icon;
	public GameObject building;
	//private GameObject icon_s = null;
	public GameObject wall;
	public GameObject minimap;
	private float timer;
	private GameObject player;
	private Vector3 minimapCoordinates = new Vector3(100,100);
	private float iconCoordinate_x = 100;
	private float iconCoordinate_y = 100;
	//private float time_map = 5f;

	private int [,] status;

	void check_if_survives(){

		int i = 0;
		int j = 0;
		int a = 0;
		int [] points = {1,-1}; 
		for (i = 1; i< numbElements_x-1; i++) {
		for (j = 1; j < numbElements_y-1; j++) {
			for (a = 0; a < 2; a++) {
					if (status [i, j] != status [i + points [a], j] && status [i, j] != status [i, j + points [a]] /**||status [i, j] != status [i + points [a], j + points [a]]**/ ) {
					if (status [i, j] == 1) {
						status [i, j] = 0;
					} else {
						status [i, j] = 1;
					}
				}
			}
		}
	}
}

	void create_level(){
		int i = 0;
		int j = 0;
		int r;
		for (i = 0; i< numbElements_x; i++) {
			for(j=0; j < numbElements_y; j++){
				r=Random.Range(0,2);
				print (r);
				if(status [i,j] != 1){
				status[i,j] = Random.Range(0,2);
				}
			}
		}
	}

	void draw_terrain(){
		int i = 0;
		int j = 0;
		for (i = 0; i< numbElements_x; i++) {
			for (j=0; j < numbElements_y; j++) {
				if(status[i,j] == 1){
					Instantiate(terrain,new Vector3(i*5,j*5), transform.rotation);
				}else{
					Instantiate(water,new Vector3(i*5,j*5), transform.rotation);
				}
			}
		}
	}
	void ruin_creator(){
		int i = 0;
		int j = 0;
		int r = 0;
		int r_h = 0;
		int [] points = {1,-1}; 
		for (i = 1; i< numbElements_x-1; i++) {
			for(j=1; j < numbElements_y-1; j++){
				r=Random.Range(0,40);
				r_h = Random.Range(0,40);
				if(r_h == 0){
				if(status[i,j] == 0  && status[i ,j + 1] == 0 && status[i,j-1]==0 && status[i + 1,j] == 0 && status[i-1,j]==0 && status[i ,j + 1] == 0 && status[i-1,j-1]==0 && status[i+1,j+1]==0){
					Instantiate(building,new Vector3(5*i,5*j),transform.rotation);
					status[i,j] = 1;
					}
				}
				if(r == 0){

					if(status[i,j] == 0  && status[i + 1,j] == 0){
						Instantiate(wall,new Vector3(5*i+5,5*j),transform.rotation);
						status[i,j]= 1;
					}
					if(status[i,j] == 0  && status[i - 1,j] == 0){
						Instantiate(wall,new Vector3(5*i-5,5*j),transform.rotation);
						status[i,j]= 1;
					}
//					if(status[i,j] == 0  && status[i ,j + 1] == 0 && status[i,j-1]==0 && status[i + 1,j] == 0 && status[i-1,j]==0 && status[i ,j + 1] == 0 && status[i-1,j-1]==0 && status[i+1,j+1]==0){
//						Instantiate(building,new Vector3(5*i,5*j),transform.rotation);
//					}
//					if(status[i,j] == 0  && status[i ,j - 1] == 0){
//					Instantiate(wall,new Vector3(5*i,j+1),transform.rotation);
//					}
				}
			}
		}
	}
	


//	void draw_minimap(){
//		int i = 0;
//		int j = 0;
//
//		for (i = 0; i< numbElements_x; i++) {
//			for (j=0; j < numbElements_y; j++) {
//				if(status[i,j] == 1){
//					Instantiate(terrain,minimapCoordinates + new Vector3(i,j), transform.rotation);
//				}else{
//					Instantiate(water,minimapCoordinates+new Vector3(i,j), transform.rotation);
//				}
//
//			}
//		}
//	}

//	void where_is_player(){
//
//
//		int i = 0;
//		int j = 0;
//		for (i = 0; i< numbElements_x; i++) {
//			for(j=0; j < numbElements_y; j++){
//				if(player.transform.position.x - 5*i < 1 && player.transform.position.y - 5*j < 1){
//					iconCoordinate_x = 5*i;
//					iconCoordinate_y = 5*j;
//				}
//
//			}
//		}
//		icon.transform.Translate (iconCoordinate_x, iconCoordinate_y,0);
//	}

	void set_first_status(){
		int i = 0;
		int j = 0;
		for (i = 0; i< numbElements_x; i++) {
			for(j=0; j < numbElements_y; j++){
				status[i,j] = 0;
			}
		}
	}

	// Use this for initialization
	void Start () {

		status = new int[numbElements_x, numbElements_y];
		player = GameObject.FindGameObjectWithTag("Player");
		//Instantiate(icon,minimapCoordinates+new Vector3(500,500,-5), transform.rotation);
		set_first_status ();
		create_level ();
		check_if_survives();
		ruin_creator ();
		draw_terrain ();
//		draw_minimap ();
//		icon.transform.position = new Vector3 (player.transform.position.x/5 + minimapCoordinates.x , 
//		                                       player.transform.position.y/5 + minimapCoordinates.y,-1);
	}
	
	// Update is called once per frame
	void Update () {

//		icon.transform.position = new Vector3 (player.transform.position.x/5 + iconCoordinate_x , 
//		                                       player.transform.position.y/5 + iconCoordinate_y ,-1);
		//icon.transform.Translate ( 100f , 100f,0);
		//where_is_player ();
//		if (Time.deltaTime > time_map) {
//		icon.transform.position = new Vector3 (iconCoordinate_x, iconCoordinate_y);
//			time_map += 5;
//		}
//		if (Time.deltaTime > timer) {
//			create_level ();
//			check_if_survives();
//			draw_terrain ();
//			timer = timer + 5;
//		}
//	}
	}
}

