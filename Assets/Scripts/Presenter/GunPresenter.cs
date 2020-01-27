using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPresenter : MonoBehaviour
{
	private GameAudioManager audioManager;
	private GunModel gunModel;
	public GunConfig gunConfig;

	// Use this for initialization
	public void Setup(GunModel model)
	{
		gunModel = model;
		gunModel.setConfig(gunConfig);
	}
	void Start ()
	{
		audioManager = GetComponent<GameAudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void shootToPLayer(Transform playerTransform,Transform enemyTransform)
	{
		GameObject bullet = Instantiate(gunConfig.bulletPrefab);
		bullet.tag = "enemyBullet";
		bullet.transform.position = enemyTransform.position - new Vector3(gunModel.getBulletPosX(), gunModel.getBulletPosY());
		bullet.GetComponent<Rigidbody2D>().AddForce(gunModel.getBulletShootForce()*(playerTransform.position - enemyTransform.position).normalized);
	}

	public void shootOnLine(Transform playerTransform,Transform lineTransform)
	{
		
		GameObject bullet = Instantiate(gunConfig.bulletPrefab);
		Destroy(bullet,4);
		Debug.Log(playerTransform);
		
		bullet.transform.position = playerTransform.position - new Vector3(gunModel.getBulletPosX(), gunModel.getBulletPosY());
		bullet.GetComponent<Rigidbody2D>().AddForce(-1 * gunModel.getBulletShootForce() * new Vector2(
			  (float) Math.Cos(lineTransform.eulerAngles[2] * Math.PI / (180)),
			  (float) Math.Sin(lineTransform.eulerAngles[2] * Math.PI / (180))));
	}
}
