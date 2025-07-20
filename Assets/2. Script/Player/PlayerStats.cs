using UnityEngine;

public class PlayerStats : MonoBehaviour, I_Stats
{
    [SerializeField] private float player_Damage = 3f;
    [SerializeField] private float player_MoveSpeed = 5f;
    [SerializeField] private float player_Hp = 10f; // 인스펙터에서 체력 조정

    public float damage => player_Damage;
    public float moveSpeed => player_MoveSpeed;

    public float hp
    {
        get => player_Hp;
        set => player_Hp = value;
    }
}