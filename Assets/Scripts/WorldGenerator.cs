using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour {

	public GameObject env_nature;
	public GameObject env_building;
	public GameObject Wall;
	public GameObject enemy;
	public GameObject powerups;
	public int length;
	public int width;
	public int length_1;
	public int width_1;
	public int length_2;
	public int width_2;
	public int number_enemies;
	public int number_powerups;
	public int number_of_structures;

	public int start_x;
	public int start_y;



	void create_horizontalWall(){
		int i = start_x;
		for (i = 0; i< length; i++) {
			Instantiate(Wall,new Vector3(i*5,0),transform.rotation);
		}
		for (i = 0; i< length; i++) {
			Instantiate(Wall,new Vector3(i*5,20),transform.rotation);
		}


	}
	void create_VerticalWall(){
		int i = start_y;
		int j = start_y;
		while(i < width-1){
			Instantiate(Wall,new Vector3(start_x,5*i),transform.rotation);
			i++;
		}
		while(j < width-1){
			Instantiate(Wall,new Vector3(20+start_x,5*j),transform.rotation);
			j++;
		}
	}

	void random_building(){
		int i = 0;
		for (i = 0; i < number_of_structures; i++) {
				Instantiate (env_building, new Vector3 (Random.Range (start_x, start_x + 20), Random.Range (start_y, start_y + 15)), transform.rotation);
		}
	}

	void random_enemies_spawn(){

		int i = 0;

		for (i=0; i< number_enemies; i++) {
			Instantiate (enemy, new Vector3 (Random.Range (start_x, start_x + 20), Random.Range (start_y, start_y + 15)), transform.rotation);

		}



	}

	// Use this for initialization
	void Start () {
		create_horizontalWall ();
		create_VerticalWall ();
		random_building ();
		random_enemies_spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
