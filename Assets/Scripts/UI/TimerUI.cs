using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] Color warningColor = Color.red;
    [SerializeField] float warningTime = 10f;

    Color normalColor;

    void Awake() => normalColor = timerText.color;

    void OnEnable() => GameEvents.OnTimeChanged += Refresh;
    void OnDisable() => GameEvents.OnTimeChanged -= Refresh;

    void Refresh(float remaining)
    {
        timerText.text = Mathf.CeilToInt(remaining).ToString();
        timerText.color = remaining <= warningTime ? warningColor : normalColor;
    }
}
