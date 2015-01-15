using UnityEngine;
using System.Collections;

public class cutscene : MonoBehaviour {

	public GameObject cameraObjective;
	private float speed_of_cam =5f;
	private float speed_of_cam_vib =6f;
	private float cam_height = -5f;
	private float timer;
	private float timer_aux;
	private int counter;
	int trigger = 0;
	int trigger_2 = 0;
	int trigger_3 = 0;
	Vector3 original_pos;
	private GameObject player;
	private PlayerController pl;
	// Use this for initialization
	void Start () {
	
		this.camera.enabled = false;
		player = GameObject.FindGameObjectWithTag("Player");
		pl = player.GetComponent <PlayerController> ();

	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {
			this.camera.enabled = true;
			trigger = 1;
			pl.isAvailable (false);
//			this.camera.
		}
		//Destroy (this.collider2D);
		this.collider2D.enabled = false;
		
	}
	void move_camera_to_objective(){

		transform.position = Vector3.MoveTowards (transform.position, cameraObjective.transform.position, speed_of_cam * Time.deltaTime);
		transform.position = new Vector3 (transform.position.x,transform.position.y, cam_height);
		//original_pos = cameraObjective.transform.position;
	}
	void vibrationalCamera(){
		float x = Random.Range(-5, 5);
		float y = Random.Range (-5, 5);

		Vector3 aux = new Vector3 (cameraObjective.transform.position.x + x, cameraObjective.transform.position.y + y,cam_height);
		transform.position = Vector3.MoveTowards (transform.position, aux, speed_of_cam_vib * Time.deltaTime);
		//transform.position = new Vector3 (cameraObjective.transform.position.x+x,cameraObjective.transform.position.y+y, cam_height);
		//transform.position = original_pos;


	}
//	bool onObjective(){
//		float dist = Vector3.Distance (transform.position, cameraObjective.transform.position);
//		if (dist < 3) {
//			//trigger_2 = 1;
//			return true;
//		}
//		return false;
//	}
	void delete(){
		pl.isAvailable (true);
		Destroy (gameObject);
	}

	
	// Update is called once per frame
	void Update () {
	
		timer = Time.time;

		if (trigger == 1) {
			move_camera_to_objective();
			trigger_2 = 1;
			}
			//vibrationalCamera();
	
		if (trigger_2 == 1) {
			vibrationalCamera();
			trigger_3 = 1;
			Invoke ("delete", 10f);
		}
//			if(onObjective() == true){
//				trigger_3 = 1;
//			}
	}
}


