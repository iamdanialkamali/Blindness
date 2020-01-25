﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // Use this for initialization
    private MapManager mapManager;
//    private PlayerManager playerPresenter;
    private PlayerPresenter playerPresenter;
    private PlayerModel playerModel = new PlayerModel();
    private EnemyManager enemyManager;
    private GameModel gameModel = new GameModel();

    private void Awake()
    {
        playerPresenter = GetComponent<PlayerPresenter>();
        mapManager = GetComponent<MapManager>();
        enemyManager = GetComponent<EnemyManager>();
        playerPresenter.Setup(playerModel);
    }

    void Start ()
    {
        gameModel.SetStarted( true);
        Vector3 playerloc = mapManager.genrateMap(20);
        playerPresenter.createPlayer(playerloc);
		
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameModel.getEnemyCount());
        if (gameModel.getStarted())
        {
            Debug.Log("started");
            if (gameModel.getEnemyCount() == 0)
            {
                SceneManager.LoadScene("win");

                Debug.Log("I WIN I WIN");
                gameModel.SetStarted(false);
            }
            else if (playerPresenter.isAlive())
            {
                bool arrived = playerPresenter.movePlayer();
                if (arrived && !gameModel.getShooted())
                {
                    enemyManager.createEnemy(playerPresenter.getSign(), playerPresenter.getPlayer(), gameModel.getEnemyCount());
                    gameModel.SetIsShooting(true);
                }

                if (gameModel.IsShooting() && Input.GetKeyDown(KeyCode.Space))
                {
                    playerPresenter.shoot();
                    StartCoroutine(enemyManager.shoot());
                    gameModel.setShooted(true);
                    gameModel.SetIsShooting(false);
                }

                if (!enemyManager.isEnemyDead() && gameModel.getEnemyMoving())
                {
                    gameModel.setEnemyArrived(enemyManager.moveEnemy());
                    if (gameModel.getEnemyArrived())
                    {
                        playerPresenter.checkMovement();
                        gameModel.setEnemyMoving(false);
                        gameModel.setShooted(false);
                    }

                }

				
                if (gameModel.getShooted() && enemyManager.isEnemyDead())
                {
                    
                    gameModel.setEnemyCount(gameModel.getEnemyCount() -1 );
                    gameModel.setShooted(false);
                    playerPresenter.checkMovement();
                }

                if (enemyManager.getStillPlaying() && !gameModel.getChanging())
                {
                    gameModel.setChanging(true);
                    enemyManager.checkMovment();
                    gameModel.setEnemyMoving(true);
                }
            }
            else
            {
                gameModel.SetStarted(false);
                SceneManager.LoadScene("lose");
                Debug.Log("YOU ARE FUCKING DEAD");
            }

        }
    }
}
