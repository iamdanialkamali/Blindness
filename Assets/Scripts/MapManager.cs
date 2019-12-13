using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	// Use this for initialization

	private Vector3 loc;
	public GameObject R3;
	public GameObject L3;
	private const double dif =  2.85;

	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 genrateMap(int count)
	{
		Color[] a = {Color.black, Color.blue, new Color(0.08f,0.5f,0.78f,1f) , Color.red, Color.yellow,Color.grey};
		
		for (int i = count; i >0 ; i--)
		{
			GameObject s2 = Instantiate(R3);
			s2.name = (2*i).ToString();
			foreach (var sp in s2.GetComponentsInChildren<SpriteRenderer>())
			{
				sp.sortingOrder = 2 * i ;
				sp.color = a[(2 * i) % a.Length];
				
			}
			s2.transform.position = loc;
			loc += new Vector3(0, (float) dif, 0);
			
			GameObject s1 = Instantiate(L3);
			s1.transform.position = loc;
			s1.name = (2 * i - 1).ToString();
			foreach (var sp in s1.GetComponentsInChildren<SpriteRenderer>())
			{
				sp.sortingOrder = 2 * i -1;
				sp.color = a[(2 * i-1) % a.Length];

			}
			loc += new Vector3(0, (float) dif, 0);
			
		}

		return loc;
	}
}
