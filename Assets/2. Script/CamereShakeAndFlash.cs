using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraShakeAndFlash : MonoBehaviour
{
    public static CameraShakeAndFlash instance;

    private Vector3 originalPos;

    public Image damagedImage;
    public float flashDuration = 0.1f;

    private Coroutine flashCoroutine; // 코루틴 중복 방지용

    private void Awake()
    {
        instance = this;
        originalPos = transform.localPosition;
    }

    public void ShakeAndFalsh(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));

        // 중복 실행 없이, 기존 코루틴이 끝나면 다시 실행
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

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }

    private IEnumerator FlashRoutine()
    {
        Color originalColor = damagedImage.color;

        damagedImage.color = new Color(1, 0, 0, 10f / 255f);
        yield return new WaitForSeconds(flashDuration);

        damagedImage.color = originalColor;
        flashCoroutine = null; // 종료되면 null로 초기화
    }
}