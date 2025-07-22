using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private PlayerStats playerStats;
    private EnemyStats enemyStats;
    private Vector3 moveDirection = Vector3.down; // 기본값 (혹시라도 설정 안 됐을 때 대비)

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }
    
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        enemyStats = GetComponent<EnemyStats>();
    }

    void Update()
    {
        transform.position += moveDirection * enemyStats.moveSpeed * Time.deltaTime;
    }
    
    //플레이어와 충돌
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.hp -= enemyStats.damage;
                Debug.Log("Player Hit");
            }
        }
    }
}
