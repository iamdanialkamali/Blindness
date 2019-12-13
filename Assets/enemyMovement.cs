using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	// Use this for initialization
	private GameObject enemy;
	void Start ()
	{
		enemy = GameObject.FindWithTag("enemy");
//		GameObject player = GameObject.FindGameObjectWithTag("player");
//		int lastLayerId = player.GetComponent<SpriteRenderer>().sortingOrder;
//		Debug.Log(GameObject.FindGameObjectsWithTag("stair2").Length);
//		Debug.Log(GameObject.FindGameObjectsWithTag("stair2")[lastLayerId-1].transform.position);
//		GameObject enemy = Instantiate(gameObject, GameObject.FindGameObjectsWithTag("stair2")[lastLayerId - 1].transform);
//		enemy.GetComponent<SpriteRenderer>().sortingOrder = lastLayerId + 1;

		//		g
//		this.transform.position = GameObject.Find().GetComponent<>()
//		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "bullet")
		{
			enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			enemy.GetComponent<Rigidbody2D>().AddTorque(200);
			Vector2 a = other.gameObject.GetComponent<Rigidbody2D>().velocity;
			enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(100*Math.Sign(a[0]),300));
			Destroy(enemy.GetComponent<BoxCollider2D>());
			Debug.Log("KIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIR");
			Debug.Log(enemy.name);
			Destroy(enemy,1);
		}

	}

	// Update is called once per frame
	void Update () {
		
		
	}
}
