using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour, I_Stats
{
    [SerializeField] private float enemy_Damage = 1f;
    [SerializeField] private float enemy_MoveSpeed = 1f;
    [SerializeField] private float enemy_MaxHp = 3f;
    [SerializeField] private int enemy_Score = 10;
    private float enemy_CurrentHp;
    
    [Header("사망 이펙트")]
    public GameObject deathEffect;

    [Header("체력바")]
    public Slider healthBar;

    void Awake()
    {
        enemy_CurrentHp = enemy_MaxHp;

        if (healthBar != null)
        {
            healthBar.value = 1f; // 처음엔 꽉 찬 상태
        }
    }

    public float damage => enemy_Damage;
    public float moveSpeed => enemy_MoveSpeed;

    public float hp
    {
        get => enemy_CurrentHp;
        set
        {
            enemy_CurrentHp = Mathf.Clamp(value, 0, enemy_MaxHp);

            // 슬라이더 업데이트
            if (healthBar != null)
            {
                healthBar.value = enemy_CurrentHp / enemy_MaxHp;
            }
        }
    }
 public void TakeHit(float dmg)
{
    hp -= dmg;

    if (hp <= 0)
    {
        GameManager.currScore += enemy_Score;

        // 💥 죽었을 때 이펙트 실행
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        EnemyPool.instance.ReturnEnemy(EnemyType.Tree, gameObject);
        return;
    }
}
    
}