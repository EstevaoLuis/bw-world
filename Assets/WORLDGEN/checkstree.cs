using UnityEngine;
using System.Collections;

public class checkstree : MonoBehaviour {


	private GameObject bad_tree;
	public GameObject new_tree;
	Vector3 aux;
	float timer = 1;


	void Start () {
	
//		bad_tree = GameObject.Find ("tree_coloured-01(Clone)");

	}

	bool check_Trees(){
		bad_tree = GameObject.Find ("tree_coloured-01(Clone)");

		if(bad_tree != null){
		aux = bad_tree.transform.position;
		Destroy (bad_tree);
		Instantiate (new_tree, aux, transform.rotation);
		return true;
		}else{

		return false;

		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timer) {
			check_Trees ();
			timer = timer + 1;	
		}
	}
}
