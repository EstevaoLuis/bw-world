using UnityEngine;
using System.Collections;
//This program is my adapted version of Conway's game of Life. 
//By Felix Hazen
public class GameOfMap : MonoBehaviour {

	private int numbElements_x = 32;
	private int numbElements_y = 32;
	public GameObject water;
	public GameObject terrain;
	public GameObject high_terrain;
	private float timer;

	private int [,] status;

	void check_if_survives(){

		int i = 0;
		int j = 0;
		int a = 0;
		int [] points = {1,-1}; 
		for (i = 1; i< numbElements_x-1; i++) {
		for (j = 1; j < numbElements_y-1; j++) {
			for (a = 0; a < 2; a++) {
				if (status [i, j] != status [i + points [a], j] || status [i, j] != status [i, j + points [a]]) {
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
					Instantiate(terrain,new Vector3(i,j), transform.rotation);
				}else{
					Instantiate(water,new Vector3(i,j), transform.rotation);
				}
			}
		}
	}


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
		set_first_status ();
		create_level ();
		check_if_survives();
		draw_terrain ();

	}
	
	// Update is called once per frame
	void Update () {
//		if (Time.deltaTime > timer) {
//			create_level ();
//			check_if_survives();
//			draw_terrain ();
//			timer = timer + 5;
//		}
//	}
	}
}

