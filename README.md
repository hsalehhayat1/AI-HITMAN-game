# AI-HITMAN-Simulation

An AI-powered stealth action game developed in **Unity** that demonstrates intelligent enemy behavior using **Finite State Machines (FSM)**. Players take on the role of a professional hitman, completing assassination missions while avoiding detection by AI-controlled guards. The project focuses on game AI, navigation, stealth mechanics, and modular programming.

---

## 📖 Overview

The purpose of this project is to implement realistic enemy AI capable of making decisions based on the player's actions. Guards continuously patrol the environment, detect suspicious activity, chase the player when spotted, attack within range, search the last known position after losing sight, and eventually return to their patrol routes.

The entire AI system is designed using the **Finite State Machine (FSM)** architecture, making the behavior modular, scalable, and easy to maintain.

---

## ✨ Features

- 🕵️ Stealth-based gameplay
- 🤖 Intelligent enemy AI
- 🔄 Finite State Machine (FSM) architecture
- 🚶 Patrol system with waypoints
- 👀 Vision-based player detection
- 📍 Line-of-sight checking
- 🏃 Chase mechanics
- ⚔️ Enemy attack system
- 🔍 Search behavior after losing the player
- 🔁 Return-to-patrol functionality
- 🗺️ Unity NavMesh pathfinding
- 🎬 Animation state management
- 🎮 Smooth player movement and controls
- 📦 Modular and reusable C# scripts

---

## 🧠 AI State Machine

The enemy AI is implemented using a **Finite State Machine (FSM)** consisting of the following states:

| State | Description |
|--------|-------------|
| 🚶 Patrol | Enemy follows predefined waypoints while scanning the environment. |
| 👀 Detect | Enemy checks whether the player is visible using distance and line-of-sight. |
| 🏃 Chase | Enemy pursues the player using Unity NavMesh. |
| ⚔️ Attack | Enemy attacks once the player is within attack range. |
| 🔍 Search | Enemy investigates the player's last known position after losing sight. |
| 🔁 Return | Enemy resumes patrol after completing the search. |

---

## 🛠️ Technologies Used

- Unity
- C#
- Finite State Machines (FSM)
- Unity NavMesh
- Unity Animator
- Physics Raycasting
- Object-Oriented Programming (OOP)

---

## 📂 Project Structure

```text
Assets
├── Animations
├── Audio
├── Materials
├── Prefabs
├── Scenes
├── Scripts
│   ├── AI
│   ├── Player
│   ├── Managers
│   └── Utilities
├── UI
└── NavMesh
```

---

## 🎮 Gameplay Flow

1. Start the mission.
2. Guards patrol their assigned routes.
3. The player infiltrates the environment.
4. Guards detect the player if they enter the field of view.
5. Guards chase and attack the player.
6. If the player escapes, guards search the last known location.
7. Guards return to patrol if the player is not found.
8. The mission ends once the objective is completed.

---

---

## 🚀 Future Improvements

- Multiple enemy archetypes
- Dynamic mission objectives
- Sound and hearing detection
- Cover system
- Weapon switching
- Inventory system
- Save and load functionality
- Procedural level generation
- Multiplayer mode
- Behavior Tree implementation

---

---

## ⚙️ Installation

Clone the repository:

```bash
git clone https://github.com/your-username/AI-Hitman-Simulation.git
```

Open the project in **Unity Hub**, load the main scene, and press **Play**.

---

## 🎮 Controls

| Action | Key |
|--------|-----|
| Move | WASD |
| Fire | Left Mouse Button |
| Grenade | G |
| Interact | F |
| Pause | Esc |

---

## 📄 License

This project is intended for educational and portfolio purposes.

---

## 👨‍💻 Author

**Malik Hassan**

Software Engineering Student | Unity Game Developer |


This is standard **GitHub Flavored Markdown (GFM)**, so it will render correctly on GitHub with headings, tables, code blocks, emojis, and horizontal separators.
