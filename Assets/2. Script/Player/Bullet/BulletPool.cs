using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance; // 싱글톤 패턴
    
    [Header("총알 풀 설정")]
    public GameObject bulletPrefab;
    public int poolSize = 20;
    
    private Queue<GameObject> bulletQueue = new Queue<GameObject>();

    void Awake()
    {
        instance = this;

        //총알 풀 생성
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletQueue.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (bulletQueue.Count > 0)
        {
            GameObject bullet = bulletQueue.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else //필요시 추가 생성 
        {
            GameObject bullet = Instantiate(bulletPrefab);
            return bullet;
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletQueue.Enqueue(bullet);
    }
}
