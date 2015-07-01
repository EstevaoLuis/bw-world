using UnityEngine;
using System.Collections;


public class BattlehordeGen : MonoBehaviour {

	private int number_enemies_to_gen = 1;
	private bool enemies_alive;
	public GameObject [] enemies_to_create;
	private GameObject [] enemies_on_game;
	public GameObject player;
	public Font f;
	private float t;
	private float start_time;

	private bool display;
	//public GameObject text;

	int type_of_enemy;


	// Use this for initialization
	void Start () {
		create_Random_swarm ();
		t = Time.deltaTime;
		start_time = Time.time;
		Time.timeScale = 1;


		//text = this.GetComponent<GUIText>();
	}

	void create_Random_swarm (){

		//enemies_alive = true;

		int x = Random.Range (0, 2);
		type_of_enemy = x;
		print(enemies_to_create [type_of_enemy].name);	

		int i = 0;
		enemies_on_game = new GameObject[number_enemies_to_gen];

		for (i=0; i<number_enemies_to_gen; i++) {

			int cor = Random.Range (0, 2);
			int pos_y;
			if (cor == 0) {
				pos_y = 5;		
			} else if (cor == 1) {
				pos_y = -5;
			} else {
				pos_y = 0;
			}
			cor = Random.Range (0, 2);
			
			int pos_x;
			
			if (cor == 0) {
				pos_x = 5;		
			} else if (cor == 1) {
				pos_x = -5;
			} else {
				pos_x = 0;
			}

			if (x == 0) {
				enemies_on_game[i] = (GameObject) Instantiate (enemies_to_create [0], new Vector2 (pos_x, pos_y), Quaternion.identity);	
			} else if (x == 1) {
				enemies_on_game[i] = (GameObject) Instantiate (enemies_to_create [1], new Vector2 (pos_x, pos_y), Quaternion.identity);	
			} else {
				enemies_on_game[i] = (GameObject) Instantiate (enemies_to_create [2], new Vector2 (pos_x, pos_y), Quaternion.identity);	
			}
		}
	}

	void check_status(){

		int i;
		int dead_guys = 0;
		display = true;
		for (i=0; i<number_enemies_to_gen; i++) {
			if(enemies_on_game[i] == null ){
				dead_guys++;
			}
		}
		if (dead_guys == number_enemies_to_gen) {
			//text.guiText.text = "SWARM";
			//display = true;
			number_enemies_to_gen++;
			create_Random_swarm();
		}
	}
	void turnOff(){
		GUI.enabled = false;
	}
	void OnGUI(){

		if (display == true) {
			GUI.color = Color.black;
			if (t >= 50) {
					GUI.color = Color.red;
			}
			//GUI.skin.label.fontSize = 18;
			GUI.skin.font = f;
			GUI.Label (new Rect (Screen.width / 2, (Screen.height / 2) - 230, 200f, 200f), "HORDE " + number_enemies_to_gen);
			GUI.Label (new Rect (Screen.width / 2 - 400, (Screen.height / 2) - 150, 500f, 200f), "TIME: " + t);

			if (t > 59) {
				GUI.color = Color.white;
				if (GUI.Button (new Rect ((Screen.width / 2) - 200, ((Screen.height / 2) - 50), 500f, 200f), "SCORE: " + number_enemies_to_gen + "\n" + "REPLAY?")) {
					RestartGame();
				}
			}
		}
	}
	void RestartGame(){

		t = 0;
		//Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevel);
	}
	bool EndGame(){

		Time.timeScale = 0;
		return true;
	}

//	void OnClick(){
//		//Application.LoadLevel (0);
//	}
		
	// Update is called once per frame
	void Update () {

	 t = (int) (Time.time - start_time);

	 if (t > 59) {
		EndGame();
	 }
	 check_status ();
	 //Invoke("turnOff",3f);
		
	}
}
