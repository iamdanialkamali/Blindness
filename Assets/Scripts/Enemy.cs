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
	private int life = 100;
	private bool hited;
	void Start ()
	{
		enemyRigibody = GetComponent<Rigidbody2D>();
		enemyCollider = GetComponent<Collider>();
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		ground = other.gameObject;
	}

	public void setLife(int targetLife)
	{
		life = targetLife;

	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("bullet"))
		{
			int damage = other.gameObject.GetComponent<Bullet>().getDamage();
        	life -= damage;
            hited = true;
        	if (life <= 0)
        	{
	            Destroy(enemyCollider);
	            enemyRigibody.freezeRotation = false;
	            enemyRigibody.bodyType = RigidbodyType2D.Dynamic;
					enemyRigibody.AddTorque(200);
	            Vector2 a = other.gameObject.GetComponent<Rigidbody2D>().velocity;
	            enemyRigibody.AddForce(new Vector2(100*Math.Sign(a[0]),300));
	            
	            Destroy(gameObject,1f);

        	}
Destroy(other.gameObject);
//        	Destroy(other.);meObject    			
		}

	}

	public void setIsShooting(bool shooting)
	{
		isShooting = shooting;
	}

	public bool isHited()
	{
		return hited;
	}
	public void clearHited()
	{
		hited = false;
	}
	
	public bool getIsShooting()
	{
		return isShooting;
	}

	public void killGround()
	{
//		Debug.Log("KILLLING HA HA HA HA");
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
