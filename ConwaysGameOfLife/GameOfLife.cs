namespace ConwaysGameOfLife;

public class GameOfLife
{
    private Cell[,] board;

    private int width, height;

    public static int generationCount = 0;

    public GameOfLife(int width, int height)
    {
        this.width = width;
        this.height = height;
        board = new Cell[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                board[x, y] = new Cell(x, y);
                board[x, y].IsAlive = false;
            }
        }

    }

    public void SetLayoutGlider()
    {


        int startX = 10;
        int startY = 10;

        board[startX + 1, startY + 0].IsAlive = true;
        board[startX + 2, startY + 1].IsAlive = true;
        board[startX + 0, startY + 2].IsAlive = true;
        board[startX + 1, startY + 2].IsAlive = true;
        board[startX + 2, startY + 2].IsAlive = true;
    }
    
    public void SetLayoutSpaceship()
    {
        int startX = 5;
        int startY = height / 2;

        board[startX + 1, startY + 0].IsAlive = true;
        board[startX + 4, startY + 0].IsAlive = true;
        board[startX + 0, startY + 1].IsAlive = true;
        board[startX + 0, startY + 2].IsAlive = true;
        board[startX + 4, startY + 2].IsAlive = true;
        board[startX + 0, startY + 3].IsAlive = true;
        board[startX + 1, startY + 3].IsAlive = true;
        board[startX + 2, startY + 3].IsAlive = true;
        board[startX + 3, startY + 3].IsAlive = true;
    }

    public void Tick()
    {
        Cell[,] nextBoard = new Cell[width, height];

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                nextBoard[i, j] = new Cell(i, j);
                int n = GetNeighbourCount(board, i, j);

                bool isAliveNow = board[i, j].IsAlive;

                if (isAliveNow)
                {
                    if (n == 2 || n == 3)
                    {
                        nextBoard[i, j].IsAlive = true;
                    }
                    else
                    {
                        nextBoard[i, j].IsAlive = false; 
                    }
                }
                else
                {
                    if (n == 3)
                    {
                        nextBoard[i, j].IsAlive = true;
                    }
                    else
                    {
                        nextBoard[i, j].IsAlive = false;
                    }
                }    
            
            }
            
        }

        generationCount++;
        board = nextBoard;
    }
   
    public void SetLayoutBlinker()
    {
        int startX = 15;
        int startY = 10;

        board[startX - 1, startY].IsAlive = true;
        board[startX,     startY].IsAlive = true;
        board[startX + 1, startY].IsAlive = true;
    }
    public void Render()
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (board[x, y].IsAlive)
                {
                    Console.Write("██");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine(); 
        }

        Console.WriteLine($"Generation: {generationCount}   ");
    }
    
    
    
    private static int GetNeighbourCount(Cell[,] cells, int x, int y)
    {
        int neighbours = 0;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;

                int nX = (x + i + cells.GetLength(0)) % cells.GetLength(0);
                int nY = (y + j + cells.GetLength(1)) % cells.GetLength(1);

                if (nX >= 0 && nX < cells.GetLength(0) && nY >= 0 && nY < cells.GetLength(1))
                {
                    if (cells[nX, nY].IsAlive) neighbours++;
                }

            }
        }

        return neighbours;
    }

    
}