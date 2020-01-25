using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EventManager
{
    void Register(EventListener listener);
    void Propagate(GameEvent gameEvent);
}

