# Shoot-Out-the-Star
Shoot the plates to score up and win a plushie :D (scene lost faaah-- don't run it)

the hierarchy of the code :

    Game
    ├── Core
    │   ├── GameState          the 4 states: Ready, Playing, Won, Lost
    │   ├── GameEvents         the event hub, every system talks through it
    │   └── GameConfig         tunable numbers (target score, time, speed, combo)
    ├── Input
    │   ├── ShootingInput      detects taps, checks if a plate was hit
    │   └── GunShake           shakes the gun sprite on each shot
    ├── Plates
    │   ├── PlateData          one plate type: points, sprite, spawn chance
    │   ├── Plate              moves across the screen, dies when hit
    │   ├── PlateRow           one lane, spawns plates and sets their direction
    │   └── PlateSpawner       picks a random row and plate type on a timer
    ├── Scoring
    │   ├── ComboSystem        tracks the streak, computes the multiplier
    │   └── ScoreSystem        holds the score, never below 0
    ├── Flow
    │   ├── GameTimer          counts down, announces when time is up
    │   └── GameStateManager   decides win or lose, handles start and restart
    ├── UI
    │   ├── ScoreUI            score text and plushie progress bar
    │   ├── ComboUI            shows streak and multiplier
    │   ├── TimerUI            shows the time, turns red when low
    │   ├── FloatingPointsUI   spawns a "+10" or "-5" popup where you hit
    │   │   └── FloatingText   the popup itself: rises, fades, disappears
    │   └── ScreenUI           shows the start, win or lose panel
    └── Audio
        └── AudioManager       plays sounds on events (singleton)


Hierarchy of the Publishers, Subscribers and the event names:

    Game
    ├── Core
    │   ├── GameState          (data)
    │   ├── GameEvents         [HUB] holds all 9 events
    │   └── GameConfig         (data)
    ├── Input
    │   ├── ShootingInput      [PUB] OnShotFired, OnShotMissed
    │   │                      [SUB] OnGameStateChanged
    │   └── GunShake           [SUB] OnShotFired
    ├── Plates
    │   ├── PlateData          (data)
    │   ├── Plate              [PUB] OnPlateHit
    │   │                      [SUB] OnGameStateChanged
    │   ├── PlateRow           (no events)
    │   └── PlateSpawner       [SUB] OnGameStateChanged
    ├── Scoring
    │   ├── ComboSystem        [PUB] OnComboChanged, OnPointsAwarded
    │   │                      [SUB] OnPlateHit, OnShotMissed, OnGameStateChanged
    │   └── ScoreSystem        [PUB] OnScoreChanged
    │                          [SUB] OnPointsAwarded, OnGameStateChanged
    ├── Flow
    │   ├── GameTimer          [PUB] OnTimeChanged, OnTimeUp
    │   │                      [SUB] OnGameStateChanged
    │   └── GameStateManager   [PUB] OnGameStateChanged
    │                          [SUB] OnScoreChanged, OnTimeUp
    ├── UI
    │   ├── ScoreUI            [SUB] OnScoreChanged
    │   ├── ComboUI            [SUB] OnComboChanged
    │   ├── TimerUI            [SUB] OnTimeChanged
    │   ├── FloatingPointsUI   [SUB] OnPointsAwarded
    │   │   └── FloatingText   (no events)
    │   └── ScreenUI           [SUB] OnGameStateChanged
    └── Audio
        └── AudioManager       [SUB] OnShotFired, OnPlateHit,
                            OnComboChanged, OnGameStateChanged
