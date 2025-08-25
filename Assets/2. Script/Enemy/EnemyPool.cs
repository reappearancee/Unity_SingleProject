using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool instance;

    public GameObject prefab;
    public int size = 10;

    private Queue<GameObject> pool = new Queue<GameObject>();

    void Awake()
    {
        instance = this;

        for (int i = 0; i < size; i++)
        {
            var obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetEnemy()
    {
        if (pool.Count > 0)
        {
            var enemy = pool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        }
        else
        {
            var enemy = Instantiate(prefab);
            return enemy;
        }
    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        pool.Enqueue(enemy);
    }
}