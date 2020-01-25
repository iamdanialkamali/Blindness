using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour
{
    
    [System.Serializable] 
    public class GameData
    {
        public bool changing;
        public bool shooting;
        public bool shooted;
        public bool enemyArrived;
        public bool enemyMoving;
        public int enemys = 20;
        public bool started = true;
    }

    private GameData data = new GameData();
    public void SetStarted(bool state)
    {
        data.started = state;
    }

    public bool getStarted()
    {
        return data.started;
    }
    public bool IsShooting()
    {
        return data.shooting;
    }
    public bool SetIsShooting(bool state)
    {
        return data.shooting = state;
    }
    
    public void setChanging(bool changing)
    {
        data.changing = changing;
    }

    public bool getChanging()
    {
        return data.changing;
    }

    public void setShooted(bool shooted)
    {
        data.shooted = shooted;
    }

    public bool getShooted()
    {
        return data.shooted;
    }

    public void setEnemyArrived(bool enemyArrived)
    {
        data.enemyArrived = enemyArrived;
    }

    public bool getEnemyArrived()
    {
        return data.enemyArrived;
    }

    public void setEnemyMoving(bool enemyMoving)
    {
        data.enemyMoving = enemyMoving;
    }

    public bool getEnemyMoving()
    {
        return data.enemyMoving;
    }

    public void setEnemyCount(int enemyCount)
    {
        data.enemys = enemyCount;
    }

    public int getEnemyCount()
    {
        return data.enemys;
    }
}
