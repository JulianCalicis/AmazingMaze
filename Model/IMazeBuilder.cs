namespace Model
{
  public interface IMazeBuilder
  {
    void Start(string name);

    //TODO: Utiliser MazePosition : IComparable
    void AddRoom(int row, int column);

    void AddWall(int row, int column);

    void Finish();
  }
}