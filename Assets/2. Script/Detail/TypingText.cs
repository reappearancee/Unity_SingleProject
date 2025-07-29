using System.Collections;
using TMPro;
using UnityEngine;

public class TypingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private string currText = "더욱 노력해야 할 거다.";
    [SerializeField] private float typingspeed = 0.1f;

    void OnEnable()
    {
        textUI.text = string.Empty;
        StartCoroutine(TypingRoutine());
    }

    IEnumerator TypingRoutine()
    {
        int textCount = currText.Length;
        for (int i = 0; i < textCount; i++)
        {
            textUI.text += currText[i];
            yield return new WaitForSecondsRealtime(typingspeed);
        }
    }
}