using UnityEngine;

[CreateAssetMenu(menuName = "Game/GameConfig")]
public class GameConfig : ScriptableObject
{
    public int targetScore = 100;
    public float roundDuration = 45f;
    public float spawnInterval = 0.8f;
    public float plateSpeed = 3f;
    public int comboStep = 3;
    public int maxMultiplier = 4;
}
