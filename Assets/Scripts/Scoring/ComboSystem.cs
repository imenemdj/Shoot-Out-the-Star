using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    [SerializeField] GameConfig config;

    int streak;

    void OnEnable()
    {
        GameEvents.OnPlateHit += OnPlateHit;
        GameEvents.OnShotMissed += OnShotMissed;
        GameEvents.OnGameStateChanged += OnStateChanged;
    }

    void OnDisable()
    {
        GameEvents.OnPlateHit -= OnPlateHit;
        GameEvents.OnShotMissed -= OnShotMissed;
        GameEvents.OnGameStateChanged -= OnStateChanged;
    }

    void OnPlateHit(int basePoints, Vector3 pos)
    {
        if (basePoints < 0)
        {
            ResetCombo();
            GameEvents.RaisePointsAwarded(basePoints, pos);
            return;
        }

        streak++;
        int multiplier = CalcMultiplier();
        GameEvents.RaiseComboChanged(streak, multiplier);
        GameEvents.RaisePointsAwarded(basePoints * multiplier, pos);
    }

    void OnShotMissed() => ResetCombo();

    void OnStateChanged(GameState state)
    {
        if (state == GameState.Playing) ResetCombo();
    }

    void ResetCombo()
    {
        streak = 0;
        GameEvents.RaiseComboChanged(0, 1);
    }

    int CalcMultiplier()
    {
        return Mathf.Min(1 + streak / config.comboStep, config.maxMultiplier);
    }
}
