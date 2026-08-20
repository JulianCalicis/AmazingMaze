using Model.Representations;

namespace Main.View
{
  internal class MazeView
  {
    public void Display(MazeModel model, string message)
    {
      Console.WriteLine($"{model.Name}: {message}");
    }
  }
}