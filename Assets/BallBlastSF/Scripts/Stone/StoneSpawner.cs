using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.Events;

public class StoneSpawner : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;

    [Header("Balance")]
    [SerializeField] private Turret turret;
    [SerializeField] private int stonesAmount;
    [SerializeField][Range(0.0f, 1.0f)] private float minHitpointsPercentage;
    [SerializeField] private int maxHitpointesRate;

    [Space(4)]
    [SerializeField] private float spawnRateIncreasePerLevel = 0;
    [SerializeField] private int additionalStonesPerLevel = 1;
    [SerializeField] private int maxHitpointsIncreasePerLevel = 1;
    [SerializeField][Range(0.0f, 1.0f)] private float minHitpointsIncreasePerLevel = 0.1f;


    [Space(10)] public UnityEvent Complete;

    public int StonesAmount => stonesAmount;

    private int stoneMaxHitpoints;
    private int stoneMinHitpoints;
    private float timer;
    private int amountSpawned = 0;


    public void Start()
    {
        int damagePerSecond = (int)(turret.ProjectileDamage * turret.ProjectileAmount * (1 / turret.FireRate));

        stoneMaxHitpoints = damagePerSecond * maxHitpointesRate;
        stoneMinHitpoints = (int)(stoneMaxHitpoints * minHitpointsPercentage);

        timer = spawnRate;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            Spawn();
            Debug.Log("Spawn");
            timer = 0;
        }

        if (amountSpawned == stonesAmount)
        {
            enabled = false;

            Complete.Invoke();
        }
    }

    private void Spawn()
    {
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stone.SetSize((Stone.Size)Random.Range(1, 4));
        stone.maxHitPoints = Random.Range(stoneMinHitpoints, stoneMaxHitpoints + 1);
        stone.SetRandomColor();

        amountSpawned++;
        stone.CounterId = stone.gameObject.GetInstanceID();
    }

    public void ResetLevel()
    {
        amountSpawned = 0;
        enabled = true;
        Start();
    }

    public void NextLevel()
    {
        spawnRate += spawnRateIncreasePerLevel;
        stonesAmount += additionalStonesPerLevel;
        maxHitpointesRate += maxHitpointsIncreasePerLevel;
        minHitpointsPercentage += minHitpointsIncreasePerLevel;

        ResetLevel();
    }
}
