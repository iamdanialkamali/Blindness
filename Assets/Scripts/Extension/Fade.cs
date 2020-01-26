using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class FadeExtension
{
    // Start is called before the first frame update
    public static void Blow(this Transform transform)
    {
     ServiceLocator.Instance.blowPresenter.makeFire(transform);
    }
}