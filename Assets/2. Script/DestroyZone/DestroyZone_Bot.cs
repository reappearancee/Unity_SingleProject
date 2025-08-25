using UnityEngine;

public class DestroyZone_Bot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyPool.instance.ReturnEnemy(other.gameObject); // ← 메서드명 ReturnEnemy
        }
    }
}