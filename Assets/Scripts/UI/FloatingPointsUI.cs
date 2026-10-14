using UnityEngine;

public class FloatingPointsUI : MonoBehaviour
{
    [SerializeField] FloatingText popupPrefab;

    void OnEnable() => GameEvents.OnPointsAwarded += OnPointsAwarded;
    void OnDisable() => GameEvents.OnPointsAwarded -= OnPointsAwarded;

    void OnPointsAwarded(int points, Vector3 pos)
    {
        FloatingText popup = Instantiate(popupPrefab, pos, Quaternion.identity);
        popup.Show(points);
    }
}
