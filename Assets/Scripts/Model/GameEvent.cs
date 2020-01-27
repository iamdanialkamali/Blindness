using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameEvent
{
    public int number = 1;
    public string message  = string.Empty;

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

public class NotifEvent : GameEvent
{

    public NotifEvent(string notifMessage):base(0)
    {
        message = notifMessage;
    }
}
