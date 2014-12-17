using UnityEngine;
using System.Collections;

public class PuzzleMaster : MonoBehaviour {

	// 0 = Red
	// 1 = Green
	// 2 = Blue
	public int[] correctSequence = new int[]{0,1,2};

	public int attempt = 0;
	public bool active = true;
	public GameObject door;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int Size (){
		return correctSequence.Length;
	}
}
