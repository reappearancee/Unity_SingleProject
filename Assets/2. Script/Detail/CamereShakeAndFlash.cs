using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraShakeAndFlash : MonoBehaviour
{
    public static CameraShakeAndFlash instance;

    private Vector3 originalPos;

    public Image damagedImage;
    public float flashDuration = 0.1f;

    private Coroutine flashCoroutine;

    private void Awake()
    {
        instance = this;
        originalPos = transform.localPosition;
    }

    public void ShakeAndFalsh(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));

        if (flashCoroutine == null)
        {
            flashCoroutine = StartCoroutine(FlashRoutine());
        }
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPos + new Vector3(offsetX, offsetY, 0f);

            elapsed += Time.unscaledDeltaTime; // ✅ 시간 정지 무시
            yield return null;
        }

        transform.localPosition = originalPos;
    }

    private IEnumerator FlashRoutine()
    {
        Color originalColor = damagedImage.color;

        damagedImage.color = new Color(1, 0, 0, 10f / 255f);
        yield return new WaitForSecondsRealtime(flashDuration); // ✅ 시간 정지 무시

        damagedImage.color = originalColor;
        flashCoroutine = null;
    }
}