using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playTimeUI;
    public TextMeshProUGUI scoreUI;
    public GameObject GameOverUI;

    private static float timer;
    public static int score;
    public static bool isPlay;

    void Start()
    {
        timer = 15f;
        isPlay = true;
        Time.timeScale = 1f; // 다시 게임 시작할 때 시간 정상화
    }

    void Update()
    {
        if (!isPlay) return;

        timer -= Time.deltaTime;
        if (timer < 0f) timer = 0f;

        scoreUI.text = $"점수 : {score}";

        int seconds = Mathf.FloorToInt(timer); // 정수 초
        int millis = Mathf.FloorToInt((timer - seconds) * 100); // 밀리초 두 자리
        playTimeUI.text = $"{seconds:00}:{millis:00}";

        if (timer <= 0f)
        {
            GameOverUI.gameObject.SetActive(true);
            isPlay = false;
            Time.timeScale = 0f; // 🔥 게임 전체 정지
        }
    }

    public static void ResetPlayUI()
    {
        timer = 0f;
        score = 0;
    }
}