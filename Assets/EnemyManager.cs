using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	// Use this for initialization
	public GameObject enemyPrefab;
	private GameObject enemy;
	private Enemy _enemy;
	private static int health;
	private GunManager gunManager;
	private GameObject player;
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createEnemy(int sign,GameObject gamePlayer)
	{
		if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
		{
			player = gamePlayer;
			enemy = Instantiate(enemyPrefab);
			_enemy = enemy.GetComponent<Enemy>();
			gunManager = enemy.GetComponent<GunManager>();

			int lastLayerId = player.GetComponent<SpriteRenderer>().sortingOrder;
			enemy.GetComponent<SpriteRenderer>().sortingOrder = lastLayerId + 2;
			enemy.transform.position =
				GameObject.FindGameObjectsWithTag("stair2")[
					GameObject.FindGameObjectsWithTag("stair2").Length - lastLayerId - 1].transform.position +
				new Vector3(0, (float) 0.25);
			enemy.transform.position -= new Vector3(9 * sign, 0);
		}
	}


	public bool isEnemyDead()
	{
		if (enemy == null)
		{
			return true;
		}

		return false;
	}
	public IEnumerator shoot()
	{
		_enemy.setIsShooting();
		yield return new WaitForSeconds(3);
		
		if (_enemy.getIsShooting()&&enemy!=null)
		{
			gunManager.shootToPLayer(player.transform,enemy.transform);
		}
		
	}

}
