using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] GameConfig config;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Slider plushieProgress;

    void OnEnable() => GameEvents.OnScoreChanged += Refresh;
    void OnDisable() => GameEvents.OnScoreChanged -= Refresh;

    void Start()
    {
        plushieProgress.maxValue = config.targetScore;
        Refresh(0);
    }

    void Refresh(int score)
    {
        scoreText.text = $"{score} / {config.targetScore}";
        plushieProgress.value = score;
    }
}
