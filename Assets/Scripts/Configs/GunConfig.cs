using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "GunConfig")]
public class GunConfig : ScriptableObject
{
    public GameObject bulletPrefab;
    public float bulletPosX = (float) 0;
    public float bulletPosY = (float) -0.5;
    public int bulletShootForce = 500;

}