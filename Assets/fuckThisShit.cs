using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuckThisShit : MonoBehaviour
{
	public GameObject playerPrefab;
	public GameObject L3;
//	public GameObject L2;
	public GameObject R3;
//	public GameObject R2;
	private const double dif =  2.8;
	private Vector3 loc = new Vector3(0,0,0);
	// Use this for initialization
	void Start ()
	{
		
		Color[] a = {Color.black, Color.blue, new Color(0.08f,0.5f,0.78f,1f) , Color.red, Color.yellow,Color.grey};
			
		for (int i = 5; i >0 ; i--)
		{
			GameObject s2 = Instantiate(R3);
			foreach (var sp in s2.GetComponentsInChildren<SpriteRenderer>())
			{
				sp.sortingOrder = 2 * i ;
				sp.color = a[(2 * i) % a.Length];
			}
			s2.transform.position = loc;
			loc += new Vector3(0, (float) dif, 0);
			GameObject s1 = Instantiate(L3);
			s1.transform.position = loc;
			foreach (var sp in s1.GetComponentsInChildren<SpriteRenderer>())
			{
				sp.sortingOrder = 2 * i -1;
				sp.color = a[(2 * i-1) % a.Length];

			}
			loc += new Vector3(0, (float) dif, 0);

		}

		GameObject player = Instantiate(playerPrefab);
		player.transform.position = loc- new Vector3(10,1);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
