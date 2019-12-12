using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

//	public GameObject 
	private GameObject player;
	public GameObject enemy;
	private Rigidbody2D rb;
	private GameObject ground;
	private int sign = 1;
	private SpriteRenderer sp;
	private double x1 = 3;
	private double x2 = -10.5;
	private double pos = 3;
	private int cnt;	// Use this for initialization
	public bool clickAble = false;
	private GameObject enemy1;
	private double timeCount;
	public GameObject bulletPrefab;
	double degree = 1;
	public bool shooting = false;
	private GameObject line;

	private void Awake()
	{
	}

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("player");
		sp = player.GetComponent<SpriteRenderer>();
		rb = player.GetComponent<Rigidbody2D>();
		cnt = 1;
		line = GameObject.FindGameObjectWithTag("line");
		rb.freezeRotation = true;
		line.GetComponent<RectTransform>().position += new Vector3(sign*1.5f,0); 


		}
	
//	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.GetComponent<SpriteRenderer>().sortingOrder ==
		    player.GetComponent<SpriteRenderer>().sortingOrder)
		{
			ground = other.gameObject;
		}
			

	}

	void Update()
	{
		
		
		if (shooting)
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				GameObject bullet = Instantiate(bulletPrefab);
				bullet.transform.position = player.transform.position - new Vector3(0, (float) -0.5);
//				bullet.transform.position = player.transform.position;//+ new Vector3(line.GetComponent<RectTransform>().rotation.x,line.GetComponent<RectTransform>().rotation.y);
				bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300*(float) Math.Cos(line.GetComponent<RectTransform>().eulerAngles[2]*Math.PI/(180)),-300*(float) Math.Sin(line.GetComponent<RectTransform>().eulerAngles[2]*Math.PI/(180))));
//				bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(10*line.GetComponent<RectTransform>().rotation.w,10*line.GetComponent<RectTransform>().rotation.z));
				//				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(100*line.GetComponent<RectTransform>().rotation.x,100*line.GetComponent<RectTransform>().rotation.y);
//				(100*new Vector2(line.GetComponent<RectTransform>().rotation.x,100*line.GetComponent<RectTransform>().rotation.y));
//				line.transform.eulerAngles
//Math.Cos()
//				Debug.Log(line.GetComponent<RectTransform>().rotation);
//				Debug.Log("COSINE:"+Math.Cos(line.GetComponent<RectTransform>().eulerAngles[2]/(2*Math.PI)));
//				Debug.Log("SINE:"+Math.Sin(line.GetComponent<RectTransform>().eulerAngles[2]/(2*Math.PI)));
//				Debug.Log(line.GetComponent<RectTransform>().eulerAngles);
			}
			degree += 1*Time.timeScale;
			degree = degree % 13;
			degree = degree  - 6;
//			Debug.Log(degree);
//			Debug.Log(degree);
			line.GetComponent<RectTransform>().RotateAround(new Vector3(0,0,1),0.01f);

			
		}
		if (Input.GetKeyDown(KeyCode.W)  & shooting)
		{
			shooting = false;
			clickAble = false;
			Destroy(enemy1);
			if (pos == x1)
			{
				
				Destroy(ground.GetComponent<Collider2D>());
				player.GetComponent<SpriteRenderer>().sortingOrder += 1;
				pos = x2;
				sign = -1;
			}
			else
			{
				sign = 1;
				pos = x1;
				Destroy(ground.GetComponent<Collider2D>());
				player.GetComponent<SpriteRenderer>().sortingOrder += 1;

			}

		}
		if (Input.GetKeyDown(KeyCode.Space) && clickAble && !shooting)
		{
			shooting = true;
			clickAble = false;
			line.transform.position = player.transform.position - new Vector3((float)( sign* 1.5),(float)-0.5);
			enemy1 = Instantiate(enemy);
			int lastLayerId = sp.sortingOrder;
			enemy1.GetComponent<SpriteRenderer>().sortingOrder = lastLayerId + 2;
			enemy1.transform.position= GameObject.FindGameObjectsWithTag("stair2")[GameObject.FindGameObjectsWithTag("stair2").Length-lastLayerId-1].transform.position + new Vector3(0,(float)0.25);
			enemy1.transform.position -= new Vector3(9*sign,0);
////				
			
			
			
		}
		
		
		double w = Math.Abs(player.transform.position.x - (pos)) ;
//		Debug.Log(w + player.name);
		if (w < 0.1 )
		{
			rb.velocity = new Vector2(0, 0);
			rb.position =  new Vector2((float)pos,rb.position.y);
			if (!shooting)
			{
				clickAble = true;
				
			}

		}
		else
		{
			rb.position += new Vector2((float) ((float)sign * 0.05), 0) * Time.timeScale;
			clickAble = false;

		}
		
		
	}
}
