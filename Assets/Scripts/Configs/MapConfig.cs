using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MapConfig")]
public class MapConfig : ScriptableObject
{
    public GameObject R3;
    public GameObject L3;
    public float diff = (float) 2.85;
}