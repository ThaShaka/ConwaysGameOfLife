# Conway's Game of Life in C# (.NET)

A fully functional, flicker-free implementation of **Conway's Game of Life** written in C# for the console environment (optimized for IDEs like Rider and VS Code). This project features toroidal (Pac-Man style) grid wrapping for infinite-feeling movement, double-buffered state transitions, and custom pre-built patterns.

---

## Features

- **Toroidal Grid Wrapping:** Edges wrap around seamlessly, allowing patterns like spaceships and gliders to travel infinitely across the screen.
- **Flicker-Free Rendering:** Uses `Console.SetCursorPosition(0, 0)` to overwrite frames cleanly in place without scrolling text or screen flashes.
- **Classic Patterns Included:** Built-in layouts for Gliders, Blinker oscillators, and the long-lived *Acorn* methuselah.
- **Cross-Platform:** Built with modern .NET, running smoothly in standard terminal windows.

---

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/) installed (version 10.0 or compatible).
- An IDE or code editor like **JetBrains Rider** or **Visual Studio Code**.

---

## Getting Started

1. Clone or download this repository to your local machine.
2. Open the solution or folder in your preferred IDE (e.g., Rider).
3. Ensure your project structure contains the primary classes:
   - `Program.cs` (Execution entry point and animation loop)
   - `GameOfLife.cs` (Simulation logic, rendering, and layout patterns)
   - `Cell.cs` (Cell state management)

---

## Running the Simulation

In your terminal or IDE run configuration, execute:

```bash
dotnet run
```

### Example `Program.cs` Setup:

```csharp
using System;
using System.Threading;
using ConwaysGameOfLife;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.Clear();

        // Initialize grid dimensions (Width, Height)
        GameOfLife game = new GameOfLife(40, 20);

        // Choose your starting layout pattern
        game.SetLayoutSpaceship();

        // Main game loop
        while (true)
        {
            game.Render();
            game.Tick();
            Thread.Sleep(100); // Adjust speed here (milliseconds per frame)
        }
    }
}
```

---

## Available Layout Methods

You can invoke any of the following pattern initializers inside `GameOfLife`:

- `game.SetLayoutGlider();` — Spawns a moving diagonal glider.
- `game.SetLayoutBlinker();` — Spawns a stationary blinking oscillator.
- `game.SetLayoutSpaceship();` — Spawns a horizontal Lightweight Spaceship (LWSS).
- `game.SetLayoutAcorn();` — Spawns a chaotic methuselah that evolves through thousands of generations.

---

## Rules of the Game

1. **Underpopulation:** Any live cell with fewer than two live neighbours dies.
2. **Survival:** Any live cell with two or three live neighbours lives on to the next generation.
3. **Overpopulation:** Any live cell with more than three live neighbours dies.
4. **Reproduction:** Any dead cell with exactly three live neighbours becomes a live cell.
