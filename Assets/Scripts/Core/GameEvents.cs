using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action<Vector2> OnShotFired;
    public static event Action<int, Vector3> OnPlateHit;
    public static event Action OnShotMissed;
    public static event Action<int, Vector3> OnPointsAwarded;
    public static event Action<int, int> OnComboChanged;
    public static event Action<int> OnScoreChanged;
    public static event Action<float> OnTimeChanged;
    public static event Action OnTimeUp;
    public static event Action<GameState> OnGameStateChanged;

    public static void RaiseShotFired(Vector2 pos) => OnShotFired?.Invoke(pos);
    public static void RaisePlateHit(int basePoints, Vector3 pos) => OnPlateHit?.Invoke(basePoints, pos);
    public static void RaiseShotMissed() => OnShotMissed?.Invoke();
    public static void RaisePointsAwarded(int points, Vector3 pos) => OnPointsAwarded?.Invoke(points, pos);
    public static void RaiseComboChanged(int streak, int multiplier) => OnComboChanged?.Invoke(streak, multiplier);
    public static void RaiseScoreChanged(int score) => OnScoreChanged?.Invoke(score);
    public static void RaiseTimeChanged(float remaining) => OnTimeChanged?.Invoke(remaining);
    public static void RaiseTimeUp() => OnTimeUp?.Invoke();
    public static void RaiseGameStateChanged(GameState state) => OnGameStateChanged?.Invoke(state);
}
