using UnityEngine;
using System.Collections;

public class ThemeAudio : MonoBehaviour {

	//Audio
	private AudioClip sceneAudio, battleAudio;
	private bool isBattleTheme = false;

	// Use this for initialization
	void Start () {
		sceneAudio = Resources.Load ("Music/Field4") as AudioClip;
		battleAudio = Resources.Load ("Music/Battle1") as AudioClip;
		audio.clip = sceneAudio;
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameInstance.instance.isInBattle ()) {
			if(!isBattleTheme) playBattleTheme();
		} else {
			if(isBattleTheme) playSceneTheme();
		}
	}
	
	
	private void playSceneTheme() {
		audio.clip = sceneAudio;
		audio.Play ();
		
	}
	
	private void playBattleTheme() {
		audio.clip = battleAudio;
		audio.Play ();
	}
}
