using Main.Controller;

namespace Main
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      MazeController controller = new MazeController();
      controller.Start();
    }
  }
}