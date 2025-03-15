using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    private GameManager _gameManager;

    private int killCount;
    private int missCount;
    private int totalSpawnedTargets;

    private int seconds;
    private int minutes;

    private float timeSpeed = 1f;
    private float lastTime = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        if (_gameManager.GameStart)
        {
            StartTimer();
        }
    }

    private void StartTimer()
    {
        if (seconds == 60)
        {
            minutes += 1;
            seconds = 0;
        }

        if (Time.time >= lastTime + timeSpeed)
        {
            seconds += 1;
            lastTime = Time.time;
        }
    }

    public void AddKill()
    {
        killCount += 1;
    }

    public int GetKillCount()
    {
        return killCount;
    }
    public void AddMiss()
    {
        missCount += 1;
    }

    public int GetMissCount()
    {
        return missCount;
    }

    public void AddTotalSpawnedTargets()
    {
        totalSpawnedTargets += 1;
    }

    public void RemoveOneFromTotalSpawnedTargets()
    {
        totalSpawnedTargets -= 1;
    }

    public int GetTotalSpawnedTargets()
    {
        return totalSpawnedTargets;
    }

    public string GetTime()
    {
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ClearAll()
    {
        killCount = 0;
        missCount = 0;

        totalSpawnedTargets = 0;

        seconds = 0;
        minutes = 0;
    }
}
