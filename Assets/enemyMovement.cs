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

				Destroy(enemy);	

	}

	// Update is called once per frame
	void Update () {
		
		
	}
}
