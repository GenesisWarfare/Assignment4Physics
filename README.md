# Asteroid Land

## Description
Asteroid Land is a challenging space landing game. You control a spaceship using the arrow keys, which apply force to move it. Your goal is to safely land the ship while avoiding hazards and surviving increasingly difficult levels.

- **Itch.io** [Play Asteroid Land](https://genesiswarfare.itch.io/asteroid-land)

---

## Assets
- Assets/
  - Prefabs/
    - Asteroid.prefab
    - Spaceship.prefab
    - Stone.prefab
  - Scenes/
    - level_1.unity
    - level_2.unity
    - level_3.unity
    - Win_Screen.unity
  - Scripts/
    - Asteroids/
      - AsteroidMovement.cs
      - AsteroidSpawner.cs
    - Menu/
      - MenuController.cs
    - Player/
      - LandingGoal.cs
      - SpaceshipCollision.cs
      - SpaceshipController.cs
    - Stones/
      - StoneMovement.cs
      - StoneSpawner.cs
  - Settings/
    - DefaultVolumeProfile.asset
    - UniversalRenderPipelineGlobalSettings.asset
  - Sprites/
    - Asteroid
    - background
    - Spaceship
    - Stone
---

## Gameplay
- **Controls:** Arrow keys to move the spaceship.
- **Hazards:**
  - **Asteroids:** Move around in space—you must avoid them.
  - **Stones:** Roll on the ground—you must dodge them.
- **Lives:** You have **3 lives**. If you crash, you lose a life. When all lives are gone, the level restarts.
- **Levels:**
  - **Level 1:** Wait **5 seconds** on land.
  - **Level 2:** Wait **7 seconds**.
  - **Level 3:** Wait **10 seconds**.
- **Difficulty:** Increases with each level.

## Win Condition
Successfully land the spaceship on all levels to see the **“You Win”** message.

