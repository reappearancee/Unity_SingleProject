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

        if (targetPlayer == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                targetPlayer = player;
        }

        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 7) // 70%
        {
            moveDirection = targetPlayer.transform.position - transform.position; // 플레이어를 바라보는 방향 값
            moveDirection.Normalize();
        }
        else // 30%
        {
            moveDirection = Vector3.down;
        }
    }
    void Update()
    {
        // 🔥 moveDirection을 normalized로 보정해서 일정한 속도로 이동
        transform.position += moveDirection.normalized * enemyStats.moveSpeed * Time.deltaTime;
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

                if (CameraShakeAndFalsh.instance != null)
                {
                    CameraShakeAndFalsh.instance.ShakeAndFalsh(0.2f, 0.1f);
                }
            }
        }
    }
}