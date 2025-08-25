using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyStats enemyStats;
    private Vector3 moveDirection;
    private Rigidbody2D rb;
    public GameObject targetPlayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyStats = GetComponent<EnemyStats>();
    }

    void OnEnable()
    {
        // 무조건 정지 후 시작
        rb.linearVelocity = Vector2.zero;
    }

    public void ResetMovement()
    {
        if (targetPlayer == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                targetPlayer = player;
        }

        int ranValue = UnityEngine.Random.Range(0, 10);
        if (ranValue < 7 && targetPlayer != null)
        {
            moveDirection = (targetPlayer.transform.position - transform.position).normalized;
        }
        else
        {
            moveDirection = Vector3.down;
        }

        rb.linearVelocity = moveDirection * enemyStats.moveSpeed;
    }

    void Update()
    {
        // 이동은 velocity에 맡기기 때문에 별도 로직 없음
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponentInParent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.hp -= enemyStats.damage;
                GameManager.instance?.UpdateHeartUI();
                CameraShakeAndFlash.instance?.ShakeAndFalsh(0.2f, 0.1f);
            }
        }
    }
}