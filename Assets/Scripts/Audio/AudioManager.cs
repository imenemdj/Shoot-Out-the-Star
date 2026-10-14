using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioClip shot;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip penalty;
    [SerializeField] AudioClip comboUp;
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip lose;

    AudioSource source;
    int lastMultiplier = 1;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        if (Instance != this) return;
        GameEvents.OnShotFired += OnShotFired;
        GameEvents.OnPlateHit += OnPlateHit;
        GameEvents.OnComboChanged += OnComboChanged;
        GameEvents.OnGameStateChanged += OnStateChanged;
    }

    void OnDisable()
    {
        GameEvents.OnShotFired -= OnShotFired;
        GameEvents.OnPlateHit -= OnPlateHit;
        GameEvents.OnComboChanged -= OnComboChanged;
        GameEvents.OnGameStateChanged -= OnStateChanged;
    }

    void OnShotFired(Vector2 pos) => Play(shot);

    void OnPlateHit(int points, Vector3 pos) => Play(points < 0 ? penalty : hit);

    void OnComboChanged(int streak, int multiplier)
    {
        if (multiplier > lastMultiplier) Play(comboUp);
        lastMultiplier = multiplier;
    }

    void OnStateChanged(GameState state)
    {
        if (state == GameState.Won) Play(win);
        else if (state == GameState.Lost) Play(lose);
    }

    void Play(AudioClip clip)
    {
        if (clip != null) source.PlayOneShot(clip);
    }
}
