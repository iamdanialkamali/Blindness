using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private MapManager mapManager;
    private PlayerPresenter playerPresenter;
    private PlayerModel playerModel = new PlayerModel();
    private EnemyModel enemyModel = new EnemyModel();
    private EnemyPresenter enemyPresenter;
    private GameModel gameModel = new GameModel();
    

    private void Awake()
    {
        playerPresenter = GetComponent<PlayerPresenter>();
        mapManager = GetComponent<MapManager>();
        enemyPresenter = GetComponent<EnemyPresenter>();
        playerPresenter.Setup(playerModel);
        enemyPresenter.Setup(enemyModel);
    }

    void Start ()
    {
        playerModel.Load();
        int level = playerModel.GetLevel();
        gameModel.SetStarted( true);
        gameModel.setEnemyCount(playerModel.GetLevel());
        Vector3 playerloc = mapManager.genrateMap((int) level+6);
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
                playerModel.SetLevel(playerModel.GetLevel()+1);
                playerModel.SaveData();     
                Debug.Log("I WIN I WIN");
                gameModel.SetStarted(false);
            }
            else if (playerPresenter.isAlive())
            {
                bool arrived = playerPresenter.movePlayer();
                if (arrived && !gameModel.getShooted())
                {
                    enemyPresenter.createEnemy(playerModel.GetSign(), playerPresenter.getPlayer(), gameModel.getEnemyCount());
                    gameModel.SetIsShooting(true);
                }

                if (gameModel.IsShooting() && Input.GetKeyDown(KeyCode.Space))
                {
                    playerPresenter.shoot();
                    StartCoroutine(enemyPresenter.shoot());
                    gameModel.setShooted(true);
                    gameModel.SetIsShooting(false);
                }
                Debug.Log("Enemy Presenter"+enemyPresenter.isEnemyDead().ToString());
                Debug.Log("Enemy Model"+gameModel.getEnemyMoving().ToString());
                if (!enemyPresenter.isEnemyDead() && gameModel.getEnemyMoving())
                {
                    gameModel.setEnemyArrived(enemyPresenter.moveEnemy());
                    if (gameModel.getEnemyArrived())
                    {
                        playerPresenter.checkMovement();
                        gameModel.setEnemyMoving(false);
                        gameModel.setShooted(false);
                    }

                }

				
                if (gameModel.getShooted() && enemyPresenter.isEnemyDead())
                {
                    
                    gameModel.setEnemyCount(gameModel.getEnemyCount() -1 );
                    gameModel.setShooted(false);
                    playerPresenter.checkMovement();
                }

                if (enemyPresenter.getStillPlaying() && !gameModel.getChanging())
                {
                    gameModel.setChanging(true);
                    enemyPresenter.checkMovment();
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
