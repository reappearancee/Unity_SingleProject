using UnityEngine;

public class EffectAutoDestroy : MonoBehaviour
{
    private float lifeTime = 0.7f; // 애니메이션 길이에 맞춰서

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}