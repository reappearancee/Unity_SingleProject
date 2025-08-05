using UnityEngine;

public class PlayerStats : MonoBehaviour, I_Stats
{
    [SerializeField] private float player_Damage = 3f;
    [SerializeField] private float player_MoveSpeed = 5f;
    [SerializeField] private float player_Hp = 3f;
    [SerializeField] private float player_MaxHp = 3f;
    
    public float maxHp => player_MaxHp;
    public float damage => player_Damage;
    public float moveSpeed => player_MoveSpeed;

    public float hp
    {
        get => player_Hp;
        set => player_Hp = Mathf.Clamp(value, 0f, player_MaxHp);
    }
}