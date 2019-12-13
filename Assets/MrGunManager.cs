using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class MrGunManager : MonoBehaviour {

	// Use this for initialization
	private MapManager mapManager;
	private PlayerManager playerManager;
	private EnemyManager enemyManager;
	private bool changing;
	private bool shooting;
	private bool shooted;
	private bool enemyArrived;
	private bool enemyMoving;

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

			if (!enemyManager.isEnemyDead() && enemyMoving)
			{
				enemyArrived = enemyManager.moveEnemy();
				if (enemyArrived)
				{
					playerManager.checkMovement();
					enemyMoving = false;
					shooted = false;
				}

			}
			if (shooted && enemyManager.isEnemyDead())
			{
				shooted = false;
				playerManager.checkMovement();
			}
			if(enemyManager.getStillPlaying() && !changing )
			{
				changing = true;
//				playerManager.checkMovement();
				enemyManager.checkMovment();
				enemyMoving = true;
			}
		}
		else
		{
			Debug.Log("YOU ARE FUCKING DEAD");
		}

	}
	
}
