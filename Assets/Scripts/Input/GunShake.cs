using System.Collections;
using UnityEngine;

public class GunShake : MonoBehaviour
{
    [SerializeField] float duration = 0.1f;
    [SerializeField] float strength = 0.1f;

    Vector3 startPos;
    Coroutine routine;

    void Awake() => startPos = transform.localPosition;

    void OnEnable() => GameEvents.OnShotFired += OnShotFired;
    void OnDisable() => GameEvents.OnShotFired -= OnShotFired;

    void OnShotFired(Vector2 pos)
    {
        if (routine != null) StopCoroutine(routine);
        routine = StartCoroutine(ShakeRoutine());
    }

    IEnumerator ShakeRoutine()
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localPosition = startPos + (Vector3)(Random.insideUnitCircle * strength);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = startPos;
        routine = null;
    }
}
