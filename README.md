# EndlessRunnerTest

This project is a basic endless runner game built in Unity. It's designed as a learning experiment to understand the core mechanics of endless runner games, featuring procedural platform generation, player progression, collectibles, and scoring.

## Core Features

### 1. Endless Platform Generation
- **Procedural Generation:** Platforms are spawned dynamically as the player moves forward, with random selection of platform types, heights, and distances.
- **Object Pooling:** Efficient platform instantiation and destruction using object pooling, ensuring smooth gameplay and performance.

### 2. Player Movement
- **Automatic Running:** The player character runs automatically to the right.
- **Jump & Double Jump:** Responsive controls for jumping and double-jumping, including variable jump heights for longer button holds.
- **Speed Progression:** Player speed increases after reaching certain distance milestones, ramping up difficulty as the game progresses.

### 3. Scoring System
- **Distance-Based Score:** Score increases over time as the player moves.
- **Collectibles:** Stars appear on platforms and can be collected to gain bonus points.
- **High Score Tracking:** The highest score is saved and displayed using Unity's PlayerPrefs.

### 4. Game State Management
- **Death & Restart:** Game ends when the player hits obstacles (death boxes); a death screen appears with an option to restart.
- **Full Reset:** Restarting the game resets player position, speed, score, and platforms for a fresh run.

### 5. Camera Control
- **Smooth Camera Tracking:** The camera smoothly follows the player horizontally for cohesive gameplay experience.

## Scripts Overview

- **GameManager.cs:** Central hub for controlling game states (start, restart, reset).
- **PlayerController.cs:** Handles all player movement and interaction logic.
- **PlatformGenerator.cs:** Responsible for procedural platform spawning.
- **PlatformDestroyer.cs:** Cleans up platforms that leave the camera view.
- **ScoreManager.cs:** Manages scoring, high score logic, and UI updates.
- **StarManager/StarGenerator.cs:** Handles spawning and collection of star collectibles.
- **DeathScreenManager.cs:** Manages the death screen UI and restart logic.
- **CameraController.cs:** Keeps the camera aligned with the player.

## How to Play

1. Run the scene in Unity.
2. The player automatically moves forward. Use SPACE or left mouse button to jump, and double jump when airborne.
3. Collect stars for bonus points.
4. Avoid falling or hitting obstacles.
5. Try to beat your high score!

---

Feel free to use, modify, and expand this project as a foundation for your own endless runner game!
