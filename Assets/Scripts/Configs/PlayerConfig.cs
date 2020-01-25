using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public float xLeft = (float) -10.5 ;
    public float xRight = (float) 3;
    public float maxLife = (float) 100;
    public float deadTorque = (float) 210;
    public float deadUpForce = (float) 320;
					
}