using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour,EventListener {

	// Use this for initialization
	private Rigidbody2D playerRigidbody;
	private Transform playerTransform;
	private SpriteRenderer playerSpriteRenderer;
	private GunPresenter gunManager;
	private Transform lineTransform;
	private GameObject player;
	private Player _player;
	private GunModel gunModel;
	private GameObject line;
	private PlayerModel playerModel;
	private GameObject ground;
	public PlayerConfig playerConfig;
	
	public void OnEvent(GameEvent gameEvent)
	{
		
		if (gameEvent.GetType() == typeof(PointEvent))
		{
			if (gameEvent.number == ServiceLocator.Instance.gameConfig.headShotPoint)
			{
				ServiceLocator.Instance.eventManager.Propagate(new NotifEvent("HeadShot"));
				playerModel.AddHeadShot();
				if (playerModel.getHeadShot() == 5)
				{
					playerModel.setLife(playerConfig.maxLife);
					playerModel.ResetHeadShot();
				} 
			}
			playerModel.AddPoint(gameEvent.number);
			Debug.Log("POINTS : "+playerModel.GetPoint().ToString());
		}
		

	}
	public void Setup(PlayerModel model,GunModel gunModel)
	{
		playerModel = model;
		playerModel.setConfig(playerConfig);
		this.gunModel = gunModel;
	}
	void Start ()
	{
		ServiceLocator.Instance.eventManager.Register(this);
	}
	

	// Update is called once per frame
	void Update ()
	{
//		Debug.Log("WTTTTTTTTTTTTTTG" + playerModel.playerConfig.xLeft);
	}
	

	public void createPlayer(Vector3 loc)
	{
		
		player = Instantiate(playerConfig.playerPrefab);
		player.transform.position = loc - new Vector3(10,1);
		line = Instantiate(playerConfig.linePrefab);
		line.GetComponentInChildren<SpriteRenderer>().sortingOrder = -10;
		lineTransform = line.GetComponent<Transform>();
		playerRigidbody = player.GetComponent<Rigidbody2D>();
		playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
		playerTransform = player.transform;
		_player = player.GetComponent<Player>();
		playerRigidbody.freezeRotation = true;
		gunManager = player.GetComponent<GunPresenter>();
		gunManager.Setup(gunModel);
		playerModel.setLife(playerConfig.maxLife);
//		_player.setup(playerModel.getMaxLife(), playerModel.getDeadTorque(), playerModel.getDeadUpForce());
		_player.Setup(playerModel);
	}

	public GameObject getPlayer()
	{
		return player;
	}
	
	public bool movePlayer()
	{
		
		double w = Math.Abs(player.transform.position.x - (playerModel.getPos()));
		if (w < 0.1)
		{
			playerRigidbody.velocity = new Vector2(0, 0);
			playerRigidbody.position = new Vector2(playerModel.getPos(), playerRigidbody.position.y);
			if (!playerModel.GetShooting())
			{
				_player.killLastGround();
				playerModel.SetShooting(true);
				showLine();
			}
			flipPlayer();
			rotateLine();
			
			return true;
		}
		else
		{
			playerModel.SetShooting(false);
			playerRigidbody.position += new Vector2((float) (playerModel.GetSign() * 0.05), 0) * Time.timeScale;
			playerRigidbody.AddForce(new Vector2(0,-10));
			return false;
		}
	}

	private void flipPlayer()
	{
		if (playerModel.GetSign() == 1)
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
		if (playerModel.GetSign() == -1)
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
		if (playerModel.GetSign() == 1)
		{
			if (line.GetComponent<RectTransform>().eulerAngles[2] > 40 ||
			    line.GetComponent<RectTransform>().eulerAngles[2] < -40)
			{
				playerModel.SetDegree(-1 * playerModel.getDegree());
			}
		}
		else
		{
			if (line.GetComponent<RectTransform>().eulerAngles[2] > 220 ||
			    line.GetComponent<RectTransform>().eulerAngles[2] < 120)
			{
				playerModel.SetDegree(-1 * playerModel.getDegree());
			}
		}

		line.GetComponent<RectTransform>().RotateAround(new Vector3(0, 0, 1), ((float)playerModel.getDegree() * 0.01f*Time.timeScale));

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
		if (playerModel.getPos() == playerModel.getX1())
		{
			player.GetComponent<SpriteRenderer>().sortingOrder += 1;
			playerModel.setPos(playerModel.getX2());
			playerModel.SetSign(-1);
		}
		else
		{
			playerModel.SetSign(1);
			playerModel.setPos(playerModel.getX1());
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

