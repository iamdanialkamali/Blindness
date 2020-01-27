using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	private EnemyModel enemyModel;
	private Rigidbody2D enemyRigibody;
	private Collider enemyCollider;
	private GameObject ground;
	private GameObject killedGround;

	public void Setup(EnemyModel model)
	{
		enemyModel = model;
	}
	private void OnDestroy()
	{
		Debug.Log(this.transform.rotation);
		if (this.transform.rotation != new Quaternion(0, 0, 0, 1))
		{
			gameObject.transform.Blow();
		}
	}

	void Start ()
	{
		enemyRigibody = GetComponent<Rigidbody2D>();
		enemyCollider = GetComponent<Collider>();
		gameObject.transform.DOJump(gameObject.transform.position + new Vector3(0, 1),2, 1000,  1000)
			.SetEase(Ease.InBounce);
		
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		ground = other.gameObject;

	}

	public void setLife(int targetLife)
	{
		enemyModel.setLife(targetLife);

	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("bullet"))
		{
			gameObject.transform.DOKill();
			int damage = other.gameObject.GetComponent<Bullet>().getDamage();
        	enemyModel.setLife(enemyModel.getLife() - damage);
            enemyModel.setHitted(true);
			if (enemyModel.getLife() <= 0)
        	{
	            Debug.Log(Math.Abs(other.transform.position.y - gameObject.transform.position.y));
	            if (Math.Abs(other.transform.position.y - gameObject.transform.position.y) > 0.4)
	            {
		            ServiceLocator.Instance.eventManager.Propagate(new PointEvent(ServiceLocator.Instance.gameConfig.headShotPoint));
		            Debug.Log("HEADSHOT");
	            }
	            else
	            {
		            ServiceLocator.Instance.eventManager.Propagate(new PointEvent(ServiceLocator.Instance.gameConfig.normalShotPoint));

	            }
	            Destroy(enemyCollider);
	            enemyRigibody.freezeRotation = false;
	            enemyRigibody.bodyType = RigidbodyType2D.Dynamic; 
	            enemyRigibody.AddTorque(enemyModel.getDeadTorque());
	            Vector2 a = other.gameObject.GetComponent<Rigidbody2D>().velocity;
	            enemyRigibody.AddForce(new Vector2(100*Math.Sign(a[0]),enemyModel.getDeadUpForce()));
	            Destroy(gameObject,1f);

        	} Destroy(other.gameObject);
		}

	}

	public void setIsShooting(bool shooting)
	{
		enemyModel.setIsShooting(shooting);
	}

	public bool isHited()
	{
		return enemyModel.getHitted();
	}
	public void clearHited()
	{
		enemyModel.setHitted(false);
	}
	
	public bool getIsShooting()
	{
		return enemyModel.getIsShooting();
	}

	public void killGround()
	{
		killedGround = ground;
		ground.GetComponent<Collider2D>().enabled = false;

	}
	public void CreateGround()
	{
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
	void Update ()
	{
		


	}
}
