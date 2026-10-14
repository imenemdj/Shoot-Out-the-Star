using UnityEngine;

public class PlateRow : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform endPoint;

    public void Spawn(Plate prefab, PlateData data, float speed)
    {
        Plate plate = Instantiate(prefab, spawnPoint.position, Quaternion.identity, transform);
        Vector2 direction = endPoint.position.x > spawnPoint.position.x ? Vector2.right : Vector2.left;
        plate.Init(data, direction, speed, endPoint.position.x);
    }
}
