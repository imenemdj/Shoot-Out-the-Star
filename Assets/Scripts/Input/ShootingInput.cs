using UnityEngine;

public class ShootingInput : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] LayerMask plateMask;

    bool canShoot;

    void Awake()
    {
        if (cam == null) cam = Camera.main;
    }

    void OnEnable() => GameEvents.OnGameStateChanged += OnStateChanged;
    void OnDisable() => GameEvents.OnGameStateChanged -= OnStateChanged;

    void Update()
    {
        if (!canShoot || !Input.GetMouseButtonDown(0)) return;

        Vector2 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        Shoot(worldPos);
    }

    void Shoot(Vector2 pos)
    {
        GameEvents.RaiseShotFired(pos);

        Collider2D hit = Physics2D.OverlapPoint(pos, plateMask);
        if (hit != null && hit.TryGetComponent(out Plate plate))
            plate.Hit();
        else
            GameEvents.RaiseShotMissed();
    }

    void OnStateChanged(GameState state) => canShoot = state == GameState.Playing;
}
