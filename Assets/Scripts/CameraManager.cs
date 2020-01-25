﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	private GameObject cam ;
	private GameObject player;
	public CameraConfig cameraConfig;
	
// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		cam = GameObject.Find("Main Camera");
		player = GameObject.Find("player(Clone)");
		Debug.Log(gameObject.name);
		cam.transform.position = new Vector3(cameraConfig.constantX,player.transform.position.y,cameraConfig.z); ;
	}
}
