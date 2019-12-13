using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
	public GameObject bulletPrefab;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void shootToPLayer(Transform playerTransform,Transform enemyTransform)
	{
		GameObject bullet = Instantiate(bulletPrefab);
		bullet.tag = "enemyBullet";
		bullet.transform.position = enemyTransform.position - new Vector3(0, (float) -0.5);
		bullet.GetComponent<Rigidbody2D>().AddForce(500*(playerTransform.position - enemyTransform.position).normalized);

	}

	public void shootOnLine(Transform playerTransform,Transform lineTransform)
	{
		
		GameObject bullet = Instantiate(bulletPrefab);
		Destroy(bullet,3);
		bullet.transform.position = playerTransform.position - new Vector3(0, (float) -0.5);
		bullet.GetComponent<Rigidbody2D>().AddForce(-500* new Vector2(
			  (float) Math.Cos(lineTransform.eulerAngles[2] * Math.PI / (180)),
			  (float) Math.Sin(lineTransform.eulerAngles[2] * Math.PI / (180))));
	}
}
