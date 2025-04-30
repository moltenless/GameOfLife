# 🌱 GameOfLife - Conway’s Cellular Automaton Simulator

**A simulation of Conway’s Game of Life — draw an initial pattern of living cells and watch them evolve endlessly through simple, mesmerizing rules.**

---

## 🧬 What Is It?

**Conway’s Game of Life** is a zero-player game — a cellular automaton devised by mathematician John Conway. Given an initial configuration of live cells, the simulation follows a simple set of rules to determine how the world evolves at each generation.

This application lets you:

- 🖌️ Draw an initial pattern of live cells
- ▶️ Start the simulation to let the grid evolve infinitely
- 📉 Watch emergent behavior from simple beginnings

---

## ⚙️ How It Works

Each generation, the grid updates based on these rules:

- 🟩 **Survival**: A live cell with 2 or 3 neighbors stays alive.
- 💀 **Death by Isolation or Overcrowding**: A live cell with fewer than 2 or more than 3 neighbors dies.
- 🌱 **Birth**: A dead cell with exactly 3 live neighbors becomes a live cell.

---

![Recording 2025-04-30 222203](https://github.com/user-attachments/assets/9435e40b-82a1-46dd-a934-5e688a180c28)
