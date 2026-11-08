namespace ConwaysGameOfLife;

public class Cell
{
    public bool IsAlive { get;  set; }
    private int x, y;


    public Cell(int x, int y)
    {
        IsAlive = false;
        this.x = x;
        this.y = y;
    }

    public Cell( bool isAlive, int x, int y)
    {
        IsAlive = isAlive;
        this.x = x;
        this.y = y;
    }
}