using M = Model;

namespace Main.View
{
  internal class MazeView
  {
    public void Display(M.MazeModel model, string message)
    {
      Console.WriteLine($"{model.Name}: {message}");
    }
  }
}