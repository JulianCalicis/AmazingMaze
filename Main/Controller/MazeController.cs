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
      //Model = MazeFactory.MazeCreate("The Amazing Maze");
      Model = new M.MazeModel("The Amazing Maze");
      View = new V.MazeView();
    }

    public void Start()
    {
      View.Display(Model, "Je suis amazing");
    }
  }
}