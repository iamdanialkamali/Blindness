using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameEvent
{
    public int number = 1;

    public GameEvent(int cnt)
    {
        number = cnt;
    }
}


public class PointEvent : GameEvent
{
    public PointEvent(int cnt):base(cnt)
    {
        number = cnt;
    }
}

