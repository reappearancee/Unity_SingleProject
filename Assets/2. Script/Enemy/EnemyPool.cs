using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Tree } // 필요시 Shooter 등 추가

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool instance;

    [System.Serializable]
    public class Pool
    {
        public EnemyType enemyType;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    private Dictionary<EnemyType, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        instance = this;
        poolDictionary = new Dictionary<EnemyType, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.enemyType, objectPool);
        }
    }

    public GameObject GetEnemy(EnemyType type)
    {
        if (!poolDictionary.ContainsKey(type))
            return null;

        if (poolDictionary[type].Count > 0)
        {
            GameObject enemy = poolDictionary[type].Dequeue();
            enemy.SetActive(true);
            return enemy;
        }
        else
        {
            // 풀을 벗어났으면 예외 처리 (추가 생성해도 OK)
            Debug.LogWarning($"Pool exhausted for {type}, instantiating new.");
            var prefab = pools.Find(p => p.enemyType == type).prefab;
            return Instantiate(prefab);
        }
    }

    public void ReturnEnemy(EnemyType type, GameObject enemy)
    {
        enemy.SetActive(false);
        poolDictionary[type].Enqueue(enemy);
    }
}