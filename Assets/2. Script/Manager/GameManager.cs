using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI playTimeUI;
    public TextMeshProUGUI scoreUI;

    private static float timer;
    public static int score;
    public static bool isPlay;

    void Start()
    {
        timer = 90f;
        isPlay = true;
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
    }

    public static void ResetPlayUI()
    {
        timer = 0f;
        score = 0;
    }
}
