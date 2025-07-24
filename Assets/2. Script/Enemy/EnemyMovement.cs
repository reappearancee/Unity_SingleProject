using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private PlayerStats playerStats;
    private EnemyStats enemyStats;
    private Vector3 moveDirection;
    public GameObject targetPlayer;
    
    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }
    void OnEnable()
    {
        playerStats = GetComponent<PlayerStats>();
        enemyStats = GetComponent<EnemyStats>();
        
        // targetPlayer가 비어있다면 자동으로 찾아줌
        if (targetPlayer == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                targetPlayer = player;
        }
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 2 && targetPlayer != null) // 20%
        {
            moveDirection = targetPlayer.transform.position - transform.position; // 플레이어를 바라보는 방향 값
            moveDirection.Normalize();
        }
        else // 80%
        {
            moveDirection = Vector3.down;
        }
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
                
                if (CameraShake.instance != null)
                {
                    CameraShake.instance.Shake(0.2f, 0.1f);
                }
            }
        }
    }
}
