using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    [SerializeField] GameConfig config;
    [SerializeField] Plate platePrefab;
    [SerializeField] PlateData[] plateTypes;
    [SerializeField] PlateRow[] rows;

    float timer;
    bool active;

    void OnEnable() => GameEvents.OnGameStateChanged += OnStateChanged;
    void OnDisable() => GameEvents.OnGameStateChanged -= OnStateChanged;

    void Update()
    {
        if (!active) return;

        timer += Time.deltaTime;
        if (timer >= config.spawnInterval)
        {
            timer = 0f;
            SpawnOne();
        }
    }

    void SpawnOne()
    {
        PlateRow row = rows[Random.Range(0, rows.Length)];
        row.Spawn(platePrefab, PickPlate(), config.plateSpeed);
    }

    PlateData PickPlate()
    {
        float total = 0f;
        foreach (PlateData type in plateTypes) total += type.spawnWeight;

        float roll = Random.Range(0f, total);
        foreach (PlateData type in plateTypes)
        {
            roll -= type.spawnWeight;
            if (roll <= 0f) return type;
        }
        return plateTypes[plateTypes.Length - 1];
    }

    void OnStateChanged(GameState state)
    {
        active = state == GameState.Playing;
        timer = 0f;
    }
}
