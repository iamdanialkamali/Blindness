using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModel : MonoBehaviour
{
    [System.Serializable]
    private class MapData
    {
        public GameObject R3;
        public GameObject L3;
        public float diff;
    }
    
    private MapData data = new MapData();
    
    public void setConfig(MapConfig config)
    {
        data.R3 = config.R3;
        data.L3 = config.L3;
        data.diff = config.diff;
    }

    public float getDiff()
    {
        return data.diff;
    }

    public GameObject getL3()
    {
        return data.L3;
    }

    public GameObject getR3()
    {
        return data.R3;
    }
}