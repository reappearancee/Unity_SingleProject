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
        var enemyStats = collision.GetComponent<EnemyStats>();
        if (enemyStats != null)
        {
            Debug.Log($"bulletDmg: {bulletDmg}");
            enemyStats.hp -= bulletDmg;
        
            // 죽으면 제거
            if (enemyStats.hp <= 0)
            {
                Destroy(collision.gameObject);
            }
            Debug.Log($"Enemy HP: {enemyStats.hp} after hit");
            // 총알 제거
            Destroy(gameObject);
        }
    }
}