using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    [System.Serializable]
    private class EnemyData
    {
        public bool stillPlaying = false;
        public float pos;
        public int sign;
        public bool flip;
        public float x1;
        public float x2;
        public float maxLife;
        public float normalEnemyLife;
        public float bossEnemyLife;
        public float deadTorque;
        public float deadUpForce;
        public GameObject enemyPrefab;
        public GameObject player;
        public GameObject enemy;
        
    }
    
    private EnemyData data = new EnemyData();
    
    public void setConfig(EnemyConfig config)
    {
        data.x1 = config.xLeft;
        data.x2 = config.xRight;
        data.maxLife = config.maxLife;
        data.normalEnemyLife = config.normalEnemyLife;
        data.bossEnemyLife = config.bossEnemyLife;
        data.deadTorque = config.deadTorque;
        data.deadUpForce = config.deadUpForce;
        data.pos = config.xRight;
        data.enemyPrefab = config.enemyPrefab;
    }

    public void setEnemy(GameObject enemy)
    {
        data.enemy = enemy;

    }
    
    public GameObject getEnemy()
    {
        return data.enemy;

    }
    public void setPlayer(GameObject player)
    {
        data.player = player;
    }
    
    public GameObject getPlayer()
    {
        return data.player;
    }
    public void SetEnemyPrefab(GameObject prefab)
    {
        data.enemyPrefab = prefab;
    }
    public GameObject GetEnemyPrefab()
    {
        return data.enemyPrefab;
    }
    public void setStillPlaying(bool stillPlaying)
    {
        data.stillPlaying = stillPlaying;
    }

    public bool getStillPlaying()
    {
        return data.stillPlaying;
    }

    public void setPos(float pos)
    {
        data.pos = pos;
    }

    public float getPos()
    {
        return data.pos;
    }

    public void setSign(int sign)
    {
        data.sign = sign;
    }

    public int getSign()
    {
        return data.sign;
    }

    public void setFlip(bool flip)
    {
        data.flip = flip;
    }
    
    public bool getFlip()
    {
        return data.flip;
    }

    public float getX1()
    {
        return data.x1;
    }
    
    public float getX2()
    {
        return data.x2;
    }
    
    public float getMaxLife()
    {
        return data.maxLife;
    }
   
    public float getNormalEnemyLife()
    {
        return data.normalEnemyLife;
    }
    public float getBossEnemyLife()
    {
        return data.bossEnemyLife;
    }
    
    public float getDeadTorque()
    {
        return data.deadTorque;
    }
    
    public float getDeadUpForce()
    {
        return data.deadUpForce;
    }
}