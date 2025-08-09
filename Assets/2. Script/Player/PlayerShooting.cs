using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;
    public float fireRate = 0.2f;
    private float timer = 0f;
    private bool flipNext = false;

    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            // Instantiate
            var bulletObj = Instantiate(bulletPrefab, firePos.position, Quaternion.Euler(0, 0, 160));

            // 데미지 설정
            var bullet = bulletObj.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetDamage(playerStats.damage);
            }

            // Y축 플립 적용
            if (flipNext)
            {
                bulletObj.transform.rotation = Quaternion.Euler(0, -180, 160);
            }
            else
            {
                bulletObj.transform.rotation = Quaternion.Euler(0, 0, 160);
            }

            flipNext = !flipNext;
            timer = 0f;
        }
    }
}