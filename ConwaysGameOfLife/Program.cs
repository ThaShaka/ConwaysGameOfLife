namespace ConwaysGameOfLife;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        GameOfLife game = new GameOfLife(40, 40);

        game.SetLayoutSpaceship();
        Console.Clear();
        while (true)
        {
            game.Render();   // Draw current state
            game.Tick();     // Calculate next state
            
            Thread.Sleep(100); // Control the speed (100ms per frame)
        }
    }
}