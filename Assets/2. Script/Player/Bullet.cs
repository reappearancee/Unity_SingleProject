using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PlayerStats playerStats;
    private EnemyStats enemyStats;
    public float speed = 5f;
    private float bulletDmg;
    private Vector3 moveDirection = Vector3.up; // 기본값 (혹시라도 설정 안 됐을 때 대비)

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }
    
    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }
    public void SetDamage(float dmg) 
    {
        bulletDmg = dmg;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyMovement enemy = collision.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            enemy.TakeHit(bulletDmg);  // 데미지전달
            Destroy(gameObject);
        }
    }
    
}