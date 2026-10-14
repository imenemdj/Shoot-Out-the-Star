using TMPro;
using UnityEngine;

public class ComboUI : MonoBehaviour
{
    [SerializeField] TMP_Text comboText;

    void OnEnable() => GameEvents.OnComboChanged += Refresh;
    void OnDisable() => GameEvents.OnComboChanged -= Refresh;

    void Start() => comboText.text = "";

    void Refresh(int streak, int multiplier)
    {
        comboText.text = streak == 0 ? "" : $"Streak {streak}  x{multiplier}";
    }
}
