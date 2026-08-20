using Model;

using M = Model;

using V = Main.View;

namespace Main.Controller
{
  internal class MazeController
  {
    public M.MazeModel Model { get; set; }
    public V.MazeView View { get; set; }

    public MazeController()
    {
      Model = M.MazeFactory.MazeCreate("test");
      View = new V.MazeView();
    }

    public void Start()
    {
      //View.Display(Model, "Je suis amazing");
      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine(Model);
        Console.Write("Choisissez une direction (W-N-E-S): ");
        var test = Console.ReadLine()?.ToUpper()[0];
        MovementDirection direction = MovementDirection.North;
        if (test == 'W') direction = MovementDirection.West;
        if (test == 'N') direction = MovementDirection.North;
        if (test == 'E') direction = MovementDirection.East;
        if (test == 'S') direction = MovementDirection.South;
        Model.Move(direction);
        Console.Clear();
      }
    }
  }
}