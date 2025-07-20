using UnityEngine;

public class EnemyStats : MonoBehaviour, I_Stats
{
    [SerializeField] private float enemy_Damage = 1f;
    [SerializeField] private float enemy_MoveSpeed = 1f;
    [SerializeField] private float enemy_Hp = 3f; 

    public float damage => enemy_Damage;
    public float moveSpeed => enemy_MoveSpeed;

    public float hp
    {
        get => enemy_Hp;
        set => enemy_Hp = value;
    }
}