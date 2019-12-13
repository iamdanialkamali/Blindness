using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D enemyRigibody;
	private Collider enemyCollider;
	private GameObject ground;
	private GameObject killedGround;
	private bool isShooting = false;
	private int life = 2000;
	void Start ()
	{
		enemyRigibody = GetComponent<Rigidbody2D>();
		enemyCollider = GetComponent<Collider>();
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		ground = other.gameObject;
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
        		Destroy(gameObject,1f);

        	}
            Destroy(other.gameObject);

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

	public void killGround()
	{
		Debug.Log("KILLLING HA HA HA HA");
		killedGround = ground;
//		Destroy(ground.GetComponent<Collider2D>());
		ground.GetComponent<Collider2D>().enabled = false;

	}
	public void CreateGround()
	{
//		killedGround.AddComponent<Collider2D>
		killedGround.GetComponent<Collider2D>().enabled = true;
			
	}

	public void setKinematic()
	{
		enemyRigibody.bodyType = RigidbodyType2D.Kinematic;
	}

	public void setDynamic()
	{
		enemyRigibody.bodyType = RigidbodyType2D.Dynamic;
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
