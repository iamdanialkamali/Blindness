using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunModel : MonoBehaviour
{
    [System.Serializable]
    private class GunData
    {
        public GameObject bulletPrefab;
        public float bulletPosX;
        public float bulletPosY;
        public int bulletShootForce;
    }
    
    private GunData data = new GunData();
    
    public void setConfig(GunConfig config)
    {
        data.bulletPrefab = config.bulletPrefab;
        data.bulletPosX = config.bulletPosX;
        data.bulletPosY = config.bulletPosY;
        data.bulletShootForce = config.bulletShootForce;
    }

    public GameObject getBulletPrefab()
    {
        return data.bulletPrefab;
    }

    public float getBulletPosX()
    {
        return data.bulletPosX;
    }

    public float getBulletPosY()
    {
        return data.bulletPosY;
    }

    public int getBulletShootForce()
    {
        return data.bulletShootForce;
    }
}