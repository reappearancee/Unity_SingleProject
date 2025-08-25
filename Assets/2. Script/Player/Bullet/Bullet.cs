using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    private float bulletDmg;
    private Vector3 moveDirection = Vector3.up; // 기본값 (혹시라도 설정 안 됐을 때 대비)

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }
    
<<<<<<< HEAD:Assets/2. Script/Player/Bullet.cs
=======

>>>>>>> parent of eded1a6 (Revert "8월 8일 금 Toss Project"):Assets/2. Script/Player/Bullet/Bullet.cs
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }
    public void SetDamage(float dmg) 
    {
        bulletDmg = dmg;
    }

    void OnTriggerEnter2D(Collider2D collision) // 적에게 데미지
    {
        EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
        if (enemyStats != null)
        {
            enemyStats.TakeHit(bulletDmg);
        }

        BulletPool.instance.ReturnBullet(gameObject);
    }
}