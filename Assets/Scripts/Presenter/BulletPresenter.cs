﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletPresenter : MonoBehaviour {

    // Use this for initialization
    private GameAudioManager audioManager;
    public BulletConfig bulletConfig;
    private BulletModel bulletModel;

    public void Setup(BulletModel model)
    {
        bulletModel = model;
        bulletModel.setConfig(bulletConfig);
    }

	
    // Update is called once per frame
    void Update () {
		
    }
}