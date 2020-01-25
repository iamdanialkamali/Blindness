using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
        public float currentGameSpeed = 1;
        public bool shooting = true;
        public int sign = 1;
        public double degree = 1;
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

    public void SetDegree(double degree)
    {
        data.degree = degree;
    }

    public double getDegree()
    {
        return data.degree;
    }
}