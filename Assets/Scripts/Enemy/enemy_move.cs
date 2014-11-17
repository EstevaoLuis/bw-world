using UnityEngine;
using System.Collections;

public class enemy_move : MonoBehaviour {

	public float MoveSpeed = 3f;
	public Animator animator = null;
	//int random_direction = Random.Range (0, 5);
	// Use this for initialization
	void Start () {
	
	}

	IEnumerator wait_for_five() {
		yield return new WaitForSeconds(5f); 
	}
	
	
	void random_movement(){
		int counter = 0;
		int random_direction = Random.Range (0, 5);



		if (random_direction == 1) {
						while (counter<10) {
								transform.Translate (Vector3.up * Time.deltaTime);
								counter++;
						}
		}
		if (random_direction == 2) {
						while (counter<10) {
								transform.Translate (Vector3.down * Time.deltaTime);
								counter++;
						}
				}
		
		if (random_direction == 3) {
						while (counter<10) {
								transform.Translate (Vector3.left * Time.deltaTime);
								counter++; 
						}
				}
						
		if (random_direction == 4) {
						while (counter<10) {
								transform.Translate (Vector3.right * Time.deltaTime);
								counter++;
						}
				}
							
		
		if (random_direction == 5) {
						while (counter<20) {
								counter++;
						}
				}
	}

	
	// Update is called once per frame
	void Update () {

		random_movement ();
		StartCoroutine(wait_for_five ());


	}
}
