using UnityEngine;
using System.Collections;

public class WorldGen : MonoBehaviour {

	int matrix_x = 100;
    int matrix_y = 100;
	char[,] world_matrix; 
	string map;

	void Start () {
	
	}

	void write_in_file(){

				int i = 0;
				int j = 0;

				world_matrix = new char[matrix_x, matrix_y];
				for (i = 0; i< matrix_x; i++) {

						for (j = 0; j<matrix_y; j++) {

								world_matrix [i, j] = 'W';

						}
				}
		for (i=0; i<matrix_x; i++) {
			for(j=0; j<matrix_y; j++){
				print (world_matrix[i,j]);
			}
		}
//		Debug.Log (world_matrix);
		}

		//map = m.ToString ();
		//System.IO.File.WriteAllText ("Map.txt", map);

//		char [] n = new char[matrix_x];
//		for (i = 0; i< matrix_x; i++) {
//			n[i]='X';
//			//map = m.ToString ();
//		}
//		map = new string (n);
		//System.IO.File.WriteAllText ("Map.txt", map);

//		char m = '@';
//		map = m.ToString ();
//		System.IO.File.WriteAllText ("Map.txt", map);

	
//
//		int i=0;
//		int j=0;
//
//		world_matrix = new char [matrix_x,matrix_y];
//
//		for (i = 0; i< matrix_x; i++) {
//
//			for(j=0; j< matrix_y; j++){
//
//				world_matrix [i,j] = '*'; 
//				map = world_matrix[i,j].ToString();
//				System.IO.File.WriteAllText ("Map.txt", map);
//			}
//		}
////		map = world_matrix.ToString();
////		print (world_matrix);
//		//System.IO.File.WriteAllText ("Map.txt", map);
//	}
	
	// Update is called once per frame
	void Update () {
		write_in_file();

	}
}
