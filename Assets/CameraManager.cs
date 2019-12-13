using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	private GameObject cam ;
	private GameObject player;
	
// Use this for initialization
	void Start ()
	{
		cam = GameObject.Find("Main Camera");
		player = GameObject.Find("player(Clone)");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (player == null)
		{
			player = GameObject.Find("player(Clone)");
		}
		cam.transform.position = new Vector3((float)-3.8,player.transform.position.y,-10); ;
	}
}
