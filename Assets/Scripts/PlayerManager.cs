using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	// Use this for initialization
	public GameObject playerPrefab;
	public GameObject linePrefab;
	private Rigidbody2D playerRigidbody;
	private Transform playerTransform;
	private SpriteRenderer playerSpriteRenderer;
	private GunManager gunManager;
	private Transform lineTransform;
	private GameObject player;
	private Player _player;
	private GameObject line;
	private double pos = 3;
	private double x1 = 3;
	private double degree = 1;
	private double x2 = -10.5;
	private GameObject ground;
	private int sign = 1;
	private bool shooting = true;
	void Start ()
{
}
	
	// Update is called once per frame
	void Update () {
		
	}
	

	public void createPlayer(Vector3 loc)
	{
		
		player = Instantiate(playerPrefab);
		player.transform.position = loc- new Vector3(10,1);
		line = Instantiate(linePrefab);
		line.GetComponentInChildren<SpriteRenderer>().sortingOrder = -10;
		lineTransform = line.GetComponent<Transform>();
		playerRigidbody = player.GetComponent<Rigidbody2D>();
		playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
		playerTransform = player.transform;
		_player = player.GetComponent<Player>();
		playerRigidbody.freezeRotation = true;
		gunManager = player.GetComponent<GunManager>();

	}

	public GameObject getPlayer()
	{
		return player;
	}
	
	public bool movePlayer()
	{
		
		double w = Math.Abs(player.transform.position.x - (pos));
		if (w < 0.1)
		{
			playerRigidbody.velocity = new Vector2(0, 0);
			playerRigidbody.position = new Vector2((float) pos, playerRigidbody.position.y);
			if (!shooting)
			{
				_player.killLastGround();
				shooting = true;
				showLine();
			}

			flipPlayer();
			rotateLine();
			
			return true;
		}
		else
		{
			shooting = false;
			playerRigidbody.position += new Vector2((float) (sign * 0.05), 0) * Time.timeScale;
			playerRigidbody.AddForce(new Vector2(0,-10));
			return false;
		}
	}

	private void flipPlayer()
	{
		if (sign == 1)
		{
			playerSpriteRenderer.flipX = true ;
			
		}
		else
		{
			playerSpriteRenderer.flipX = false ;
			
		}
	}
	public void showLine()
	{

		line.transform.position = player.transform.position - new Vector3( 0,(float) -0.5);
		foreach (SpriteRenderer v in line.GetComponentsInChildren<SpriteRenderer>())
		{
			v.enabled = true;

		}

		line.GetComponent<SpriteRenderer>().enabled = true;
		if (sign == -1)
		{
			line.transform.rotation = new Quaternion(0, 0, 1, 0);
		}
		else
		{
			line.transform.rotation = new Quaternion(0, 0, 0, 0);
					
		}

		
	}

	public void hideLine()
	{
		foreach (SpriteRenderer v in line.GetComponentsInChildren<SpriteRenderer>())
		{
			v.enabled = false;

		}

		line.GetComponent<SpriteRenderer>().enabled = false;
	}
	public void rotateLine()
	{
		if (sign == 1)
		{
			if (line.GetComponent<RectTransform>().eulerAngles[2] > 40 ||
			    line.GetComponent<RectTransform>().eulerAngles[2] < -40)
			{
				degree = -degree;
			}
		}
		else
		{
			if (line.GetComponent<RectTransform>().eulerAngles[2] > 220 ||
			    line.GetComponent<RectTransform>().eulerAngles[2] < 120)
			{
				degree = -degree;
			}
		}

		line.GetComponent<RectTransform>().RotateAround(new Vector3(0, 0, 1), (float)degree*0.01f*Time.timeScale);

	}

	public int  getSign()
	{
		return sign;
	}

	public int getPlayerSortingOrder()
	{
		return playerSpriteRenderer.sortingOrder;
	}

	public void shoot()
	{
		if(gunManager != null){
			gunManager.shootOnLine(playerTransform,lineTransform);
			hideLine();
		}
	}

	public void checkMovement()
	{
		if (pos == x1)
		{
			player.GetComponent<SpriteRenderer>().sortingOrder += 1;
			pos = x2;
			sign = -1;
		}
		else
		{
			sign = 1;
			pos = x1;
			player.GetComponent<SpriteRenderer>().sortingOrder += 1;
		}
		
		
	}

	public bool isAlive()
	{
		if (player==null)
		{
			return false;
		}

		return true;
	}
}

