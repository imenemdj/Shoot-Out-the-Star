using UnityEngine;

[CreateAssetMenu(menuName = "Game/PlateData")]
public class PlateData : ScriptableObject
{
    public int points;
    public Sprite sprite;
    public float spawnWeight = 1f;
}
