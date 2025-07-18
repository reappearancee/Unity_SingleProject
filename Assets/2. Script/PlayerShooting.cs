using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;
    public float fireRate = 0.2f;
    private float timer = 0f;

    private bool flipNext = false; // 번갈아가며 Flip 여부

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePos.position, Quaternion.Euler(0, 0, 160));

            // 방향은 항상 위로 (Bullet.cs에서 처리)
            // 플립만 번갈아 적용
            if (flipNext)
            {
                bullet.transform.rotation = Quaternion.Euler(0, -180, 160); // Y축만 반전
            }
            else
            {
                bullet.transform.rotation = Quaternion.Euler(0, 0, 160); // 기본 방향
            }

            flipNext = !flipNext; // 다음 발사는 반대 방향으로

            timer = 0f;
        }
    }
}