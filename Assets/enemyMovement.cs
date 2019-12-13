using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	// Use this for initialization
	private GameObject enemy;
	private int life = 200;
	void Start ()
	{
		enemy = GameObject.FindWithTag("enemy");
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "bullet")
		{
			int damage = other.gameObject.GetComponent<Bullet>().getDamage();
			life -= damage;
			if (life <= 0)
			{
				enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
				enemy.GetComponent<Rigidbody2D>().AddTorque(200);
				Vector2 a = other.gameObject.GetComponent<Rigidbody2D>().velocity;
				enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(100*Math.Sign(a[0]),300));
				Destroy(enemy.GetComponent<BoxCollider2D>());
				Destroy(enemy,1.5f);
			}
		}

	}

	// Update is called once per frame
	void Update () {
		
		
	}
}
