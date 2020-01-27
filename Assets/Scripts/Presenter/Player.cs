using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using UnityEngine;

public class Player : MonoBehaviour {
	
	
		// Use this for initialization
	private Collider2D ground;
	private PlayerModel playerModel;


	public void Setup(PlayerModel model)
	{
		playerModel = model;
	}
	

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
			 playerModel.setLife(  playerModel.getLife()- damage);
			if ( playerModel.getLife()<= 0)
			{
				Destroy(GetComponent<Collider>());
				GetComponent<Rigidbody2D>().freezeRotation = false;
				GetComponent<Rigidbody2D>().AddTorque(playerModel.getDeadTorque());
				Vector2 a = other.gameObject.GetComponent<Rigidbody2D>().velocity;
				GetComponent<Rigidbody2D>().AddForce(new Vector2(100*Math.Sign(a[0]),playerModel.getDeadUpForce()));
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
