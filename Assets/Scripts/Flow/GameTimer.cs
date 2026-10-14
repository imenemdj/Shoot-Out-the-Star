using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] GameConfig config;

    float remaining;
    bool running;

    void OnEnable() => GameEvents.OnGameStateChanged += OnStateChanged;
    void OnDisable() => GameEvents.OnGameStateChanged -= OnStateChanged;

    void Update()
    {
        if (!running) return;

        remaining -= Time.deltaTime;
        GameEvents.RaiseTimeChanged(Mathf.Max(remaining, 0f));

        if (remaining <= 0f)
        {
            running = false;
            GameEvents.RaiseTimeUp();
        }
    }

    void OnStateChanged(GameState state)
    {
        running = state == GameState.Playing;
        if (running) remaining = config.roundDuration;
    }
}
