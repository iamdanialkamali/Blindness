using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrGunManager : MonoBehaviour {

	// Use this for initialization
	private MapManager mapManager;
	private PlayerManager playerManager;
	private EnemyManager enemyManager;
	private bool shooting;
	private bool shooted;

	private void Awake()
	{
		playerManager = GetComponent<PlayerManager>();
		mapManager = GetComponent<MapManager>();
		enemyManager = GetComponent<EnemyManager>();
	}

	void Start ()
	{
		Vector3 playerloc = mapManager.genrateMap(2);
		playerManager.createPlayer(playerloc);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (playerManager.isAlive())
		{
			bool arrived = playerManager.movePlayer();
			if (arrived && !shooted)
			{
				enemyManager.createEnemy(playerManager.getSign(), playerManager.getPlayer());
				shooting = true;
			}

			if (shooting && Input.GetKeyDown(KeyCode.Space))
			{
				playerManager.shoot();
				StartCoroutine(enemyManager.shoot());
				shooted = true;
				shooting = false;
			}

			if (shooted && enemyManager.isEnemyDead())
			{
				shooted = false;
				playerManager.checkMovement();
			}
		}
		else
		{
			Debug.Log("YOU ARE FUCKING DEAD");
		}

	}
	
}
