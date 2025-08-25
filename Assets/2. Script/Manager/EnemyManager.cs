using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;      // 생성할 적 프리팹
    public Transform[] spawnPoints;     // 생성 위치들
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 6f;

    private float timer = 0f;
    private float nextSpawnTime;

    void Start()
    {
        SetNextSpawnTime();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            SpawnEnemy();
            timer = 0f;
            SetNextSpawnTime();
        }
    }

    void SpawnEnemy()
    {
        int spawnCount = Random.Range(1, Mathf.Min(4, spawnPoints.Length + 1));

        List<Transform> shuffled = new List<Transform>(spawnPoints);
        ShuffleList(shuffled);

        for (int i = 0; i < spawnCount; i++)
        {
            var spawnPos = shuffled[i];
            GameObject enemy = EnemyPool.instance.GetEnemy();
            enemy.transform.position = spawnPos.position;
            enemy.transform.rotation = Quaternion.identity;
        }
    }
    void ShuffleList(List<Transform> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            Transform temp = list[i];
            list[i] = list[rand];
            list[rand] = temp;
        }
    }
    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}