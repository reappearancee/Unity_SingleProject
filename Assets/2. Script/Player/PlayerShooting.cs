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
<<<<<<< HEAD

=======
    
>>>>>>> parent of eded1a6 (Revert "8월 8일 금 Toss Project")
    public void FireLeft()
    {
        Fire(true); // flip = true
    }
<<<<<<< HEAD
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

=======

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

>>>>>>> parent of eded1a6 (Revert "8월 8일 금 Toss Project")
        var bullet = bulletObj.GetComponent<Bullet>();
        if (bullet != null)
            bullet.SetDamage(playerStats.damage);
    }
}