using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameConfig config;

    GameState current;

    void OnEnable()
    {
        GameEvents.OnScoreChanged += OnScoreChanged;
        GameEvents.OnTimeUp += OnTimeUp;
    }

    void OnDisable()
    {
        GameEvents.OnScoreChanged -= OnScoreChanged;
        GameEvents.OnTimeUp -= OnTimeUp;
    }

    void Start() => SetState(GameState.Ready);

    public void StartGame() => SetState(GameState.Playing);

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    void OnScoreChanged(int score)
    {
        if (current == GameState.Playing && score >= config.targetScore)
            SetState(GameState.Won);
    }

    void OnTimeUp()
    {
        if (current == GameState.Playing)
            SetState(GameState.Lost);
    }

    void SetState(GameState state)
    {
        current = state;
        GameEvents.RaiseGameStateChanged(state);
    }
}
