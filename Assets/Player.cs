using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	
		// Use this for initialization
	private Collider2D ground;
	private int life = 200;
	void Start () {
		
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		
		if (other.gameObject.GetComponent<SpriteRenderer>().sortingOrder ==
		    gameObject.GetComponent<SpriteRenderer>().sortingOrder)
		{
			ground = other.gameObject.GetComponent<Collider2D>();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.CompareTag("enemyBullet"))
		{
			int damage = other.gameObject.GetComponent<Bullet>().getDamage();
			life -= damage;
			if (life <= 0)
			{
				Destroy(gameObject,1f);
			}
			Destroy(other.gameObject);

		}

	}


	// Update is called once per frame
	void Update () {
		
	}

	public void killLastGround()
	{
		Destroy(ground);
	}
}
