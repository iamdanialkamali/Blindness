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
    }

    private EnemyData data = new EnemyData();

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