using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RTLTMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private MapPresenter mapManager;
    private PlayerPresenter playerPresenter;
    private BulletPresenter bulletPresenter;
    private EnemyPresenter enemyPresenter;
    private GunPresenter gunPresenter;
    private MapPresenter mapPresenter;
    private PlayerModel playerModel = new PlayerModel();
    private EnemyModel enemyModel = new EnemyModel();
    private BulletModel bulletModel = new BulletModel();
    private GameModel gameModel = new GameModel();
    private GunModel gunModel = new GunModel();
    private MapModel mapModel = new MapModel();
    private RTLTextMeshPro point;
    private RTLTextMeshPro life;

    private void Awake()
    {
        playerPresenter = GetComponent<PlayerPresenter>();    
        mapPresenter = GetComponent<MapPresenter>();
        enemyPresenter = GetComponent<EnemyPresenter>();
        bulletPresenter = GetComponent<BulletPresenter>();
        gunPresenter = GetComponent<GunPresenter>();
        playerPresenter.Setup(playerModel,gunModel);
        enemyPresenter.Setup(enemyModel,gunModel);
        bulletPresenter.Setup(bulletModel);
        gunPresenter.Setup(gunModel);
        mapPresenter.Setup(mapModel);
    }

    void Start ()
    {
        DOTween.Init();
        point = GameObject.FindWithTag("point").GetComponent<RTLTextMeshPro>();
        life = GameObject.FindWithTag("life").GetComponent<RTLTextMeshPro>();
        playerModel.Load();
        int level = playerModel.GetLevel();
        gameModel.SetStarted( true);
        gameModel.setEnemyCount(playerModel.GetLevel());
        Vector3 playerloc = mapPresenter.genrateMap( level+6);
        playerPresenter.createPlayer(playerloc);
    }
    
    // Update is called once per frame
    void Update()
    {
        point.text = playerModel.GetPoint().ToString();
        life.text = playerModel.getLife().ToString();
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
