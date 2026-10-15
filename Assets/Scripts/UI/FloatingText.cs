using System.Collections;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] TextMeshPro label;
    [SerializeField] Color positiveColor = Color.green;
    [SerializeField] Color negativeColor = Color.red;
    [SerializeField] float riseSpeed = 1.5f;
    [SerializeField] float lifetime = 0.8f;

    void Awake() => label.sortingOrder = 10;

    public void Show(int points)
    {
        label.text = points > 0 ? $"+{points}" : points.ToString();

        Color c = points >= 0 ? positiveColor : negativeColor;
        c.a = 1f;
        label.enableVertexGradient = false;
        label.color = c;

        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        float elapsed = 0f;
        while (elapsed < lifetime)
        {
            transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
            label.alpha = 1f - elapsed / lifetime;
            elapsed += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
