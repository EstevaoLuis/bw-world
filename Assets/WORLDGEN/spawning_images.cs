using UnityEngine;
using System.Collections;

public class spawning_images : MonoBehaviour {

	public TextAsset imag;

	// Use this for initialization
	void Start () {
		Texture2D tex = new Texture2D(4, 4);
		tex.LoadImage(imag.bytes);
		renderer.material.mainTexture = tex;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
