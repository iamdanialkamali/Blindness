using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	
		// Use this for initialization
	private Collider2D ground;
	private float life;
	private float deadTorque;
	private float deadUpForce;

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
				Destroy(GetComponent<Collider>());
				GetComponent<Rigidbody2D>().freezeRotation = false;

				GetComponent<Rigidbody2D>().AddTorque(deadTorque);
				Vector2 a = other.gameObject.GetComponent<Rigidbody2D>().velocity;
				GetComponent<Rigidbody2D>().AddForce(new Vector2(100*Math.Sign(a[0]),deadUpForce));
	            

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
	public void setup(float maxLife, float deadTorque, float deadUpForce)
	{
		this.life = maxLife;
		this.deadTorque = deadTorque;
		this.deadUpForce = deadUpForce;
	}
}
