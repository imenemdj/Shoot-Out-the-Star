using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Plate : MonoBehaviour
{
    PlateData data;
    Vector2 direction;
    float speed;
    float endX;
    bool moving = true;

    void OnEnable() => GameEvents.OnGameStateChanged += OnStateChanged;
    void OnDisable() => GameEvents.OnGameStateChanged -= OnStateChanged;

    public void Init(PlateData plateData, Vector2 dir, float plateSpeed, float despawnX)
    {
        data = plateData;
        direction = dir;
        speed = plateSpeed;
        endX = despawnX;

        GetComponent<SpriteRenderer>().sprite = data.sprite;

        BoxCollider2D box = GetComponent<BoxCollider2D>();
        box.size = data.sprite.bounds.size;
        box.offset = data.sprite.bounds.center;
    }

    void Update()
    {
        if (!moving) return;

        transform.Translate(direction * speed * Time.deltaTime);

        bool pastEnd = direction.x > 0 ? transform.position.x > endX : transform.position.x < endX;
        if (pastEnd) Destroy(gameObject);
    }

    public void Hit()
    {
        GameEvents.RaisePlateHit(data.points, transform.position);
        Destroy(gameObject);
    }

    void OnStateChanged(GameState state) => moving = state == GameState.Playing;
}
