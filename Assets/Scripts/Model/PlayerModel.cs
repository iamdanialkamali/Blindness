using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [System.Serializable]
    private class PlayerData
    {
        public bool shooting = true;
        public int sign = 1;
        public float degree = 1;
        public float x1;
        public float pos;
        public float x2;
        public float maxLife;
        public float deadTorque;
        public float deadUpForce;
    }

    private PlayerData data = new PlayerData();

    public void SetShooting(bool shooting)
    {
        data.shooting = shooting;
    }

    public bool GetShooting()
    {
        return data.shooting;
    }

    public void SetSign(int sign)
    {
        data.sign = sign;
    }

    public int GetSign()
    {
        return data.sign;
    }

    public void SetDegree(float degree)
    {
        data.degree = degree;
    }

    public float getDegree()
    {
        return data.degree;
    }

    public void setConfig(PlayerConfig playerConfig)
    {
        data.x1 = playerConfig.xRight;
        data.x2 = playerConfig.xLeft;
        data.maxLife = playerConfig.maxLife;
        data.deadTorque = playerConfig.deadTorque;
        data.deadUpForce = playerConfig.deadUpForce;
        data.pos = playerConfig.xRight;
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

    public float getDeadTorque()
    {
        return data.deadTorque;
    }

    public float getDeadUpForce()
    {
        return data.deadUpForce;
    }

    public float getPos()
    {
        return data.pos;
    }
    public void setPos(float pos)
    {
        data.pos = pos;
    }
}