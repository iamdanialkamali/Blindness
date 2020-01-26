using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioPresenter : MonoBehaviour {
    public AudioSource gunAudio;
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playGunSound()
	{
		gunAudio.Play();
	}
}
