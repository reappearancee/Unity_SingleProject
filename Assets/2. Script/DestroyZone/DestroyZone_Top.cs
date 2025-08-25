using UnityEngine;

public class DestroyZone_Top : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            BulletPool.instance.ReturnBullet(other.gameObject);
        }
    }
}