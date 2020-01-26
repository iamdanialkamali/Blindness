using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
        public bool shooting = true;
        public int sign = 1;
        public double degree = 1;
        public int level = 1;
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

    public int GetLevel()
    {
        return data.level;
    }
    public void SetLevel(int level)
    {
        data.level = level;
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            string loadString = PlayerPrefs.GetString("PlayerData");
            data = JsonUtility.FromJson<PlayerData>(loadString);
        }
    }
    public void SaveData()
    {
        string jsonString = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("PlayerData", jsonString);
    }
    
}