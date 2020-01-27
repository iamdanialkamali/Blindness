using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using RTLTMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPresenter : MonoBehaviour,EventListener
{
	private RTLTextMeshPro notif; 
	private RTLTextMeshPro point;
	private PlayerModel.PlayerData model;
	
	public void OnEvent(GameEvent gameEvent)
	{
		if (gameEvent.GetType() == typeof(NotifEvent))
		{
			notif.enabled = true;
			notif.text = gameEvent.message;
			StartCoroutine(fade());

		}

	}

	// Use this for initialization
	void Start ()
	{
		ServiceLocator.Instance.eventManager.Register(this);
		notif = GameObject.FindWithTag("notif").GetComponent<RTLTextMeshPro>();
		point = GameObject.FindWithTag("point").GetComponent<RTLTextMeshPro>();
		notif.enabled = false;
		string loadString = PlayerPrefs.GetString("PlayerData");
		model =  JsonUtility.FromJson<PlayerModel.PlayerData>(loadString);
		point.text = model.points.ToString();

	}
	public IEnumerator fade()
	{
		yield return new WaitForSeconds(2);
		notif.enabled = false;
	} 
	
	// Update is called once per frame
	void Update () {

		
		
	}

	

	
}
