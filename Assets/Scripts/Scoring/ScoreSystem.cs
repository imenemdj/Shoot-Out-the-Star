using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    int score;

    void OnEnable()
    {
        GameEvents.OnPointsAwarded += OnPointsAwarded;
        GameEvents.OnGameStateChanged += OnStateChanged;
    }

    void OnDisable()
    {
        GameEvents.OnPointsAwarded -= OnPointsAwarded;
        GameEvents.OnGameStateChanged -= OnStateChanged;
    }

    void OnPointsAwarded(int points, Vector3 pos)
    {
        score = Mathf.Max(0, score + points);
        GameEvents.RaiseScoreChanged(score);
    }

    void OnStateChanged(GameState state)
    {
        if (state != GameState.Playing) return;
        score = 0;
        GameEvents.RaiseScoreChanged(score);
    }
}
