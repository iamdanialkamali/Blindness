using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	private int damage = 100;
	private GameAudioManager audioManager;

	public int getDamage()
	{
		return damage;
	}
	void Start ()
	{
		audioManager = GameObject.FindGameObjectWithTag("map").GetComponent<GameAudioManager>();
		audioManager.playGunSound();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
