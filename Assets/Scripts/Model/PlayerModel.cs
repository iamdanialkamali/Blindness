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
        public float x1;
        public float pos;
        public float x2;
        public float maxLife;
        public float deadTorque;
        public float deadUpForce;
        public int level = 1;
        public int points;
        public int life;
        public int headShot = 0;
    }
    
    
    private PlayerData data = new PlayerData();

    public void ResetHeadShot()
    {
        data.headShot = 0;
    }
    public int getHeadShot()
    {
        return data.headShot;
    } 
    public void AddHeadShot()
    {
        data.headShot++;
    } 
    public void setLife(int life)
    {
        data.life = life;
    }

    public int getLife()
    {
        return data.life;
    }
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
            PlayerData model =  JsonUtility.FromJson<PlayerData>(loadString);
            data.level = model.level;
            data.points = model.points;
            Debug.Log("POINTS : "+model.points.ToString());
        }
    }

    public void SaveData()
    {
        string jsonString = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("PlayerData", jsonString);
    }

    public int GetPoint()
    {
        return data.points;
    }

    public void SetPoint(int pnt)
    {
        data.points = pnt;
    }
    
    public void AddPoint(int pnt)
    {
        data.points += pnt;
    }


}