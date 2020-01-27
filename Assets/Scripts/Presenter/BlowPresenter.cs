using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowPresenter : MonoBehaviour
{
    public BlowConfig config;
    // Start is called before the first frame update
    public void makeFire(Transform position)
    {
        GameObject fire = Instantiate(config.fire, position.position,new Quaternion(0,0,0,0));
        Destroy(fire,0.5f);
    }
}
