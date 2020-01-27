using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using DG.Tweening;
using UnityEngine;

public class EnemyPresenter : MonoBehaviour
{

	private EnemyModel enemyModel;
	public EnemyConfig enemyConfig;
	private GameObject enemy;
	private GunModel gunModel;
	private Enemy _enemy;
	private GunPresenter gunManager;
	private Rigidbody2D enemyRigidbody;
	private Transform enemyTransform;
	void Start ()
	{
	}

	public void Setup(EnemyModel model,GunModel gunModel)
	{
		enemyModel = model;
		enemyModel.setConfig(enemyConfig);

		this.gunModel = gunModel;

	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public bool isHited()
	{
		return _enemy.isHited();
	}
	public void createEnemy(int playerSign,GameObject gamePlayer,int enemyCount)
	{
		if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
		{	
			enemyModel.setPlayer(gamePlayer);
			enemy = Instantiate(enemyModel.GetEnemyPrefab());
			_enemy = enemy.GetComponent<Enemy>();
			_enemy.Setup(enemyModel);
			if (enemyCount == 1)
			{
				_enemy.setLife((int)enemyModel.getBossEnemyLife());
				enemyModel.setIsBoss(true);
			}
			
			enemyModel.setSign(playerSign);
			gunManager = enemy.GetComponent<GunPresenter>();
			gunManager.Setup(gunModel);
			enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
			enemyTransform = enemy.GetComponent<Transform>();
			int lastLayerId = enemyModel.getPlayer().GetComponent<SpriteRenderer>().sortingOrder;
			enemy.GetComponent<SpriteRenderer>().sortingOrder = lastLayerId + 2;
			enemyRigidbody.freezeRotation = true;
			enemy.transform.position =
				GameObject.FindGameObjectsWithTag("stair2")[
					GameObject.FindGameObjectsWithTag("stair2").Length - lastLayerId - 1].transform.position +
				new Vector3(0, (float) 0.25);
			enemy.transform.position -= new Vector3(9 * enemyModel.getSign(), 0);
			if (enemyTransform.position.x > -4)
			{
				enemyModel.setFlip(true);
				flipEnemey();
			}
		}
	}

	private void checkStillPlaying()
	{
		if (enemyModel.getPlayer() != null && enemy != null && _enemy.getIsShooting())
		{
			enemyModel.setStillPlaying(true);
		} 
	}

	public bool getStillPlaying()
	{
		return enemyModel.getStillPlaying();
	}

	public bool isEnemyDead()
	{
		if (enemy == null)
		{
			return true;
		}

		return false;
	}

	public bool isShooting()
	{
		return _enemy.getIsShooting();
	}
	public void disableShooting()
	{
		_enemy.setIsShooting(false);
	}
	public IEnumerator shoot()
	{
		_enemy.setIsShooting(true);
		yield return new WaitForSeconds(3);
		
		if (_enemy.getIsShooting() && enemy != null && !isHited())
		{
			gunManager.shootToPLayer(enemyModel.getPlayer().transform,enemy.transform);
			
		}
		yield return new WaitForSeconds(2);
		checkStillPlaying();
		
	}

	public void checkMovment()
	{
		_enemy.killGround();
		_enemy.setDynamic();
		if (Math.Abs(enemyTransform.position.x - enemyModel.getX1()) < 0.9)
		{
			enemyModel.setPos(enemyModel.getX2());
			enemyModel.setSign(1);
		}
		else
		{
			enemyModel.setPos(enemyModel.getX1());

			enemyModel.setSign(-1);

		}
	}
	private void flipEnemey()
	{ 
		enemy.GetComponent<SpriteRenderer>().flipX = enemyModel.getFlip()  ;

	}
	

	public bool moveEnemy()
	{
		_enemy.clearHited();
		double w = Math.Abs(enemyTransform.position.x - enemyModel.getPos());
		if (w >0.1)
		{
			enemyTransform.position += new Vector3((float) ( enemyModel.getSign() * 0.05), 0) * Time.timeScale;
			enemyRigidbody.AddForce(new Vector2(0, -10));
			return false;
		}
		else
		{
			enemyTransform.position = new Vector3((float)enemyModel.getPos() , enemyTransform.position.y);
			enemyRigidbody.velocity = new Vector2(0, 0);
			_enemy.CreateGround();
			_enemy.setKinematic();
			enemyModel.setFlip(!enemyModel.getFlip());
			flipEnemey();
			return true;

		}


	}

}
