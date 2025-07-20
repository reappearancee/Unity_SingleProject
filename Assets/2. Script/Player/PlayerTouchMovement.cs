using UnityEngine;

public class PlayerTouchMovement : MonoBehaviour //플레이어 이동 관련 코드
{
    private PlayerStats playerStats;
    public float boundaryX = 3f;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        Vector3 inputPos = Vector3.zero;
        bool isTouching = false;

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        if (Input.GetMouseButton(0))
        {
            inputPos = Input.mousePosition;
            isTouching = true;
        }
#else
        if (Input.touchCount > 0)
        {
            inputPos = Input.GetTouch(0).position;
            isTouching = true;
        }
#endif

        if (isTouching)
        {
            Vector3 touchPos = cam.ScreenToWorldPoint(inputPos);
            touchPos.z = 0;

            Vector3 targetPos = new Vector3(touchPos.x, transform.position.y, 0);
            transform.position = Vector3.Lerp(transform.position, targetPos, playerStats.moveSpeed * Time.deltaTime);

            float clampedX = Mathf.Clamp(transform.position.x, -boundaryX, boundaryX);
            transform.position = new Vector3(clampedX, transform.position.y, 0);
        }
    }
}