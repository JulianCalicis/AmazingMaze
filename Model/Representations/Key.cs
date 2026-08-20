using Model.Interfaces;

namespace Model.Representations
{
  public class Key : IStorable
  {
    public MazeSymbol Representation => MazeSymbol.Key;
  }
}