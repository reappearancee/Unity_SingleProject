using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyType[] enemyTypes;         // 🔁 등장 가능한 적 타입들
    public Transform[] spawnPoints;        // 스폰 위치들
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
        if (enemyTypes == null || enemyTypes.Length == 0)
        {
            Debug.LogError("enemyTypes가 비어 있습니다!");
            return;
        }

        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("spawnPoints가 비어 있습니다!");
            return;
        }

        int maxSpawn = Mathf.Min(4, spawnPoints.Length);
        int spawnCount = Random.Range(1, maxSpawn + 1);

        List<Transform> shuffled = new List<Transform>(spawnPoints);
        ShuffleList(shuffled);

        for (int i = 0; i < spawnCount; i++)
        {
            if (i >= shuffled.Count)
            {
                Debug.LogError($"i = {i}, but shuffled.Count = {shuffled.Count}");
                continue;
            }

            Transform spawnPos = shuffled[i];
            int randIndex = Random.Range(0, enemyTypes.Length);
            EnemyType typeToSpawn = enemyTypes[randIndex];

            GameObject enemy = EnemyPool.instance.GetEnemy(typeToSpawn);
            if (enemy != null)
            {
                enemy.transform.position = spawnPos.position;
                enemy.transform.rotation = Quaternion.identity;
                
                enemy.SetActive(true);
            }
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