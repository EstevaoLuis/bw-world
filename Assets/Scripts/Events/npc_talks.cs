using UnityEngine;
using System.Collections;
using SimpleJSON;

public class npc_talks : MonoBehaviour {

	// Use this for initialization
	private GameObject player;
	private GameObject npc;
	public GameObject text;
	//private GUI gui_npc;
	private JSONNode Talk;
	private TextMesh actual_text;

	private string text_to_say;
	private string color;
	private float distance_to_talk = 3;
	private float actual_dist;

	private string tag;
	private float x;
	private float y;
	private float pos_x;
	private float pos_y;
	private float w;
	private float h;
	public string type_of_npc;
		
	void Start () {
		Talk = GameInstance.instance.getNPCTalkingParameters (type_of_npc);
		if (Talk == null) {
			Destroy (gameObject);
			print ("deadObj");
		}
		player = GameObject.FindGameObjectWithTag("Player");


		color = Talk ["color"];
		distance_to_talk = Talk ["distance"].AsFloat;
		tag = Talk ["tag"];
		x = Talk ["x"].AsFloat;
		y = Talk ["y"].AsFloat;
		w = Talk ["w"].AsFloat;
		h = Talk ["h"].AsFloat;

		npc =  GameObject.FindGameObjectWithTag(tag);
		//text = GameObject.FindGameObjectWithTag("text");
		Instantiate (text, new Vector2(npc.transform.position.x,npc.transform.position.y), transform.rotation); 
		actual_text = text.GetComponent<TextMesh> ();
		actual_text.text = " ";
	}

	void check_dist() {

		actual_dist = Vector3.Distance (player.transform.position, npc.transform.position);
		//print (actual_dist);

		if (actual_dist < distance_to_talk) {

			text_to_say = Talk ["phrase"];
			print ("Detected");


		} else {

			text_to_say = "...";
		}

	}


		//GUI.TextField(new Rect (this.transform.position.x, this.transform.position.y, 100, 100), "");	

	//}
	
	// Update is called once per frame
	void Update () {

		//check_dist ();

		if (actual_dist < distance_to_talk) {
			
			text_to_say = Talk ["phrase"];
			print ("Detected");
			
			
		} else {
			
			text_to_say = "...";
		}

		actual_text.text = text_to_say;
//		pos_x = npc.transform.position.x;
//		pos_y = npc.transform.position.y;


//		
		//guiText.text = "HELLOOOOOOO";
//				
//		Txt = GameObject.FindGameObjectWithTag("Text");

		//print (dist);

//			this.guiText.enabled = true;
//			this.guiText.text = text_to_say;
//
//				} else {
//			this.guiText.text = "";
//			this.guiText.enabled = false;
//		
	}
}


