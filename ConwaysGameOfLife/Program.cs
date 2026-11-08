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
            game.Render(); 
            game.Tick();     
            
            Thread.Sleep(100); 
        }
    }
}