using UnityEngine;
using System.Collections;
using SimpleJSON;

public class npc_talks : MonoBehaviour {

	// Use this for initialization
	private GameObject player;
	private GameObject npc;
	//private GUI gui_npc;
	private JSONNode Talk;

	private string text_to_say;
	private string color;
	private float distance_to_talk;
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

		text_to_say = Talk ["phrase"];
		color = Talk ["color"];
		distance_to_talk = Talk ["distance"].AsFloat;
		tag = Talk ["tag"];
		x = Talk ["x"].AsFloat;
		y = Talk ["y"].AsFloat;
		w = Talk ["w"].AsFloat;
		h = Talk ["h"].AsFloat;

	  
		player = GameObject.FindGameObjectWithTag("Player");
		npc =  GameObject.FindGameObjectWithTag(tag);
	

	}

	void OnGUI() {

		actual_dist = Vector3.Distance (player.transform.position, this.transform.position);

		if (actual_dist < distance_to_talk) {
			//Color col = color as Color;
//			//color = (color)
//			GUI.color = col;
			GUI.Label (new Rect (x,y, w, h), text_to_say);



		}

		//GUI.TextField(new Rect (this.transform.position.x, this.transform.position.y, 100, 100), "");	

	}
	
	// Update is called once per frame
	void Update () {
	
//		pos_x = npc.transform.position.x;
//		pos_y = npc.transform.position.y;

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


