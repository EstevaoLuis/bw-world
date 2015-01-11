using UnityEngine;
using System.Collections;

public class pathCreator : MonoBehaviour {

	private int numbElements_x = 10;
	private int numbElements_y = 10;
	public GameObject map_border;
	private GameObject first_p;
	private int [,] status;

	// Use this for initialization
	void Start () {
		status = new int[numbElements_x, numbElements_y];
		first_matrix ();
		first_point ();
		//create_road ();

	}

	void first_matrix(){
		int i=0;
		int j=0;
		for (i = 0; i < numbElements_x; i ++) {
			for (j =0; j <numbElements_y; j++) {
				status [i, j] = 0;
			}
		}
	}

	bool first_point(){

		int i = 0;
		int j = 0;
		int a = 0;
		int r = 0;

		for (i = 0; i < numbElements_x; i ++) {
			for (j=0; j <numbElements_y; j++) {
				r = Random.Range(0,10);
				if(r == 5){
					status[i,j]=1;
					first_p = (GameObject) Instantiate( map_border, new Vector3 (transform.position.x + i , transform.position.y + j ), transform.rotation);
					return true;
				}
			}
		}
		return false;
	}

	void create_road (){

		int i = 0;
		int j = 0;
		int a = 0;
		int r;
		int [] points =  {-1,1};
		for (i=0; i < numbElements_x; i ++) {
			for (j=0; j <numbElements_y-1; j++) {
				if(status[i,j] == 1){
					//r = Random.Range(0,2);
//					if(r == 1){
						status[i,j+1] = 1;
//					}

					

				}
			
			}
		}

	}

	

	
	// Update is called once per frame
	void Update () {
	
		int i = 0;
		while (i<20) {
			create_road();
		}

	}
}
