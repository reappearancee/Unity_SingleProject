using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playTimeUI;
    public TextMeshProUGUI scoreUI;

    public Slider slid_Score;
    public Slider slid_Time;
    
    public GameObject gameoverUI;
    public GameObject stageclearUI;

    private static float setTime = 60f;
    private static float currTime;
    
    public static int targetScore = 50;
    public static int currScore;
    
    public static bool isPlay;

    void Start()
    {
        currScore = 0;
        
        currTime = setTime;
        isPlay = true;
        Time.timeScale = 1f;

        slid_Score.maxValue = targetScore;
        slid_Score.value = targetScore - currScore;
        
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
        slid_Score.value = targetScore - currScore;
        slid_Time.value = currTime;

        if (currTime <= 0f)
        {
            gameoverUI.gameObject.SetActive(true);
            isPlay = false;
            Time.timeScale = 0f;
        }

        if (currScore == targetScore)
        {
            stageclearUI.gameObject.SetActive(true);
            isPlay = false;
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("2. Ingame");
    }

    public void ContinueGame()
    {
        gameoverUI.gameObject.SetActive(false);
        isPlay = true;

        currTime += 30f;
        Time.timeScale = 1f;
    }

    public static void ResetPlayUI()
    {
        currScore = 0;
        setTime = 15f;
    }
}