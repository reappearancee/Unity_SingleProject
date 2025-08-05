using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private PlayerStats playerStats;
    private EnemyStats enemyStats;
    private Vector3 moveDirection;
    public GameObject targetPlayer;
    private Rigidbody2D rb;

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.linearVelocity = moveDirection * enemyStats.moveSpeed;
    }

    //플레이어와 충돌
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponentInParent<PlayerStats>(); // 👈 여기 핵심!
            if (playerStats != null)
            {
                playerStats.hp -= enemyStats.damage;
                Debug.Log("Player Hit");
                
                if (GameManager.instance != null)
                {
                    GameManager.instance.UpdateHeartUI();
                }

                if (CameraShakeAndFlash.instance != null)
                {
                    CameraShakeAndFlash.instance.ShakeAndFalsh(0.2f, 0.1f);
                }
            }
        }
    }
}