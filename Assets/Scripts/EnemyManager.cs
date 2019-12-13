using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	// Use this for initialization
	public GameObject enemyPrefab;
	private GameObject enemy;
	private Enemy _enemy;
	private static int health;
	private GunManager gunManager;
	private Rigidbody2D enemyRigidbody;
	private Transform enemyTransform;
	private GameObject player;
	private bool stillPlaying;
	private double pos ;
	private double x1 = -8.0951 ;
	private double degree = 1;
	private int sign;
	private bool flip;
	private double x2 = 0.2427;
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool isHited()
	{
		return _enemy.isHited();
	}
	public void createEnemy(int playerSign,GameObject gamePlayer,int enemyCount)
	{
		if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
		{
			player = gamePlayer;
			enemy = Instantiate(enemyPrefab);
			_enemy = enemy.GetComponent<Enemy>();
			if (enemyCount == 1)
			{
				_enemy.setLife(200);
			}

			sign = playerSign;
			gunManager = enemy.GetComponent<GunManager>();
			enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
			enemyTransform = enemy.GetComponent<Transform>();
			int lastLayerId = player.GetComponent<SpriteRenderer>().sortingOrder;
			enemy.GetComponent<SpriteRenderer>().sortingOrder = lastLayerId + 2;
			enemyRigidbody.freezeRotation = true;
			enemy.transform.position =
				GameObject.FindGameObjectsWithTag("stair2")[
					GameObject.FindGameObjectsWithTag("stair2").Length - lastLayerId - 1].transform.position +
				new Vector3(0, (float) 0.25);
			enemy.transform.position -= new Vector3(9 * sign, 0);
			if (enemyTransform.position.x > -4)
			{
				flip = true;
				flipEnemey();
			}
		}
	}

	private void checkStillPlaying()
	{
		if (player != null && enemy != null && _enemy.getIsShooting())
		{
			stillPlaying = true;
		} 
	}

	public bool getStillPlaying()
	{
		return stillPlaying;
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
		
		if (_enemy.getIsShooting()&&enemy!=null && !isHited())
		{
			gunManager.shootToPLayer(player.transform,enemy.transform);
			
		}
		yield return new WaitForSeconds(2);
		checkStillPlaying();
		
	}

	public void checkMovment()
	{
		_enemy.killGround();
		_enemy.setDynamic();
		if (Math.Abs(enemyTransform.position.x - x1) < 0.9)
		{
			pos = x2;
			sign = 1;
		}
		else
		{
			pos = x1;
			sign = -1;
		}
	}
	private void flipEnemey()
	{ 
		Debug.Log(flip);
		enemy.GetComponent<SpriteRenderer>().flipX = flip ;

	}
	

	public bool moveEnemy()
	{
		_enemy.clearHited();
		double w = Math.Abs(enemyTransform.position.x - pos);
		if (w >0.1)
		{
			enemyTransform.position += new Vector3((float) (sign * 0.05), 0) * Time.timeScale;
			enemyRigidbody.AddForce(new Vector2(0, -10));
			return false;
		}
		else
		{
			enemyTransform.position = new Vector3((float)pos, enemyTransform.position.y);
			enemyRigidbody.velocity = new Vector2(0, 0);
			_enemy.CreateGround();
			_enemy.setKinematic();
			flip = !flip;
			flipEnemey();
			return true;

		}


	}

}
