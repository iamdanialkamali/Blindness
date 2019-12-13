using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D enemyRigibody;
	private Collider enemyCollider;
	private bool isShooting = false;
	private int life = 100;
	void Start ()
	{
		enemyRigibody = GetComponent<Rigidbody2D>();
		enemyCollider = GetComponent<Collider>();
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("bullet"))
		{
//			Destroy(enemyCollider);
//			enemyRigibody.bodyType = RigidbodyType2D.Dynamic;
//			
//			enemyRigibody.AddTorque(2);
//			Vector2 a = other.gameObject.GetComponent<Rigidbody2D>().velocity;
//			enemyRigibody.AddForce(new Vector2(100*Math.Sign(a[0]),1));

			int damage = other.gameObject.GetComponent<Bullet>().getDamage();
        	life -= damage;
        	if (life <= 0)
        	{
        		Destroy(gameObject,1.5f);

        	}
//        	Destroy(other.);meObject    			
		}

	}

	public void setIsShooting()
	{
		isShooting = true;
	}

	public bool getIsShooting()
	{
		return isShooting;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
