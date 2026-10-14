using UnityEngine;

public class ScreenUI : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;

    void OnEnable() => GameEvents.OnGameStateChanged += OnStateChanged;
    void OnDisable() => GameEvents.OnGameStateChanged -= OnStateChanged;

    void OnStateChanged(GameState state)
    {
        startPanel.SetActive(state == GameState.Ready);
        winPanel.SetActive(state == GameState.Won);
        losePanel.SetActive(state == GameState.Lost);
    }
}
