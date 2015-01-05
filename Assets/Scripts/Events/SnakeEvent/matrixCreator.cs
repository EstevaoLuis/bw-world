using UnityEngine;
using System.Collections;

public class matrixCreator : MonoBehaviour {

	// Use this for initialization
	private int number_cells = 8;
	//private int actual_cells = 0;
	public GameObject cellTrap;
	//private GameObject [] trapMatrix;


	void Start () {
	
		create_trapMatrix ();

	}

	void create_trapMatrix(){
		int i = 0;
		int j = 0;
		int k = 0;
		int row_counter = 0;

		while(row_counter < 9){

			if (row_counter < 3) {
				Instantiate (cellTrap, new Vector3 (transform.position.x, transform.position.y + 7f * i), transform.rotation);
				i++;
				row_counter++;
			}
			if (row_counter >= 3 && row_counter < 6) {
				Instantiate (cellTrap, new Vector3 (transform.position.x + 7f, transform.position.y + 7f * j), transform.rotation);
				j++;
				row_counter++;
			}
			if (row_counter >= 6 && row_counter <= 8) {
				Instantiate (cellTrap, new Vector3 (transform.position.x + 14f, transform.position.y + 7f * k), transform.rotation);
				k++;
				row_counter++;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
