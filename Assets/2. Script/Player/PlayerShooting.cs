using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePos;
    private float timer = 0f;
    private bool flipNext = false;

    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    
    public void FireLeft()
    {
        Fire(true); // flip = true
    }

    public void FireRight()
    {
        Fire(false); // flip = false
    }
    
    private void Fire(bool flip)
    {
        var rotY = flip ? -180f : 0f;
        var bulletObj = BulletPool.instance.GetBullet();
        bulletObj.transform.position = firePos.position;
        bulletObj.transform.rotation = firePos.rotation = Quaternion.Euler(0,rotY,160);

        var bullet = bulletObj.GetComponent<Bullet>();
        if (bullet != null)
            bullet.SetDamage(playerStats.damage);
    }
}