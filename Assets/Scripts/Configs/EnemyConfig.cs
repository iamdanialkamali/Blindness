using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    public float xLeft = (float) -8.0951;
    public float xRight = (float)  0.2427;
    public float maxLife = (float) 100;
    public float normalEnemyLife = (float) 100;
    public float bossEnemyLife = (float) 300;
    public float deadTorque = (float) 200;
    public float deadUpForce = (float) 300;
}