using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playTimeUI;
    public TextMeshProUGUI scoreUI;

    public Slider slid_Score;
    public Slider slid_Time;
    public GameObject GameOverUI;

    private static float setTime = 90f;
    private static float currTime;
    public static int maxScore = 500;
    public static int currScore;
    public static bool isPlay;

    void Start()
    {
        currTime = setTime;
        isPlay = true;
        Time.timeScale = 1f;

        slid_Score.maxValue = maxScore;
        slid_Score.value = maxScore - currScore;
        
        slid_Time.maxValue = setTime;
        slid_Time.value = setTime; // 100% 채워진 상태
    }
    
    void Update()
    {
        if (!isPlay) return;

        // 시간 감소 먼저!
        currTime -= Time.deltaTime;
        if (currTime < 0f) currTime = 0f;

        // 텍스트 업데이트
        scoreUI.text = $"점수:{currScore}";
        int seconds = Mathf.FloorToInt(currTime);
        int millis = Mathf.FloorToInt((currTime - seconds) * 100);
        playTimeUI.text = $"{seconds:00}:{millis:00}";

        // ✅ 슬라이더 갱신 순서를 여기서!
        slid_Score.value = maxScore - currScore;
        slid_Time.value = currTime;

        if (currTime <= 0f)
        {
            GameOverUI.gameObject.SetActive(true);
            isPlay = false;
            Time.timeScale = 0f;
        }
    }

    public static void ResetPlayUI()
    {
        currScore = 0;
        setTime = 15f;
    }
}