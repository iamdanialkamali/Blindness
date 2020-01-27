using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel : MonoBehaviour
{
    [System.Serializable]
    private class BulleteData
    {
        public int ak47;
        public int colt;
        public int damage;
        public string type;
    }
    
    private BulleteData data = new BulleteData();
    
    public void setConfig(BulletConfig config)
    {
        data.ak47 = config.ak47;
        data.colt = config.colt;
    }

    public int getDamage(GameObject damage, string type)
    {
        int res = 100;
        if (type == "colt")
        {
            res = data.colt;
        } else if (type == "ak47")
        {
            res = data.ak47;
        }

        return res;
    }

    public void setType(string type)
    {
        data.type = type;
    }

    public string getType()
    {
        return data.type;
    }
}