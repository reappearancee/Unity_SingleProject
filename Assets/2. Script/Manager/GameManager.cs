using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerStats playerStats;
    
    [Header("상태 바")]
    public TextMeshProUGUI playTimeUI;
    public TextMeshProUGUI scoreUI;
    public Slider slid_Score;
    public Slider slid_Time;
    
    [Header("화면 전환")]
    public GameObject gameoverUI;
    public GameObject stageclearUI;
    public GameObject beforestartUI;

    private static float setTime = 60f;
    private static float currTime;
    
    public static int targetScore = 50;
    public static int currScore;
    
    public static bool isPlay;

    void OnEnable()
    {
        Time.timeScale = 0f;
        isPlay = false;
    
        beforestartUI.SetActive(true);  // 게임 시작 전 UI 보여줌
    }

    void StartGame()
    {
        beforestartUI.SetActive(false);
        isPlay = true;
        Time.timeScale = 1f;
    }

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        
        currScore = 0;
        currTime = setTime;

        slid_Score.maxValue = targetScore;
        slid_Score.value = targetScore - currScore;
        
        slid_Time.maxValue = setTime;
        slid_Time.value = setTime; // 100% 채워진 상태
    }
    
    void Update()
    {
        // 게임 시작 전, 터치로 시작
        if (!isPlay)
        {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
            if (Input.GetMouseButtonDown(0))
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
#endif
            {
                StartGame();
            }
            return;
        }

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
        
        if (currTime <= 0f || playerStats.hp <= 0f)
        {
            gameoverUI.gameObject.SetActive(true);
            isPlay = false;
            Time.timeScale = 0f;
        }

        if (currScore >= targetScore)
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

        playerStats.hp += 2f;
        currTime += 30f;
        Time.timeScale = 1f;
    }
}