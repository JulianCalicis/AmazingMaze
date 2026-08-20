using System.Diagnostics;

namespace Model
{
  public class MazeReader
  {
    private MazeModelBuilder _builder;

    public MazeReader(MazeModelBuilder builder)
    {
      _builder = builder;
    }

    internal void Read(string mazeName)
    {
      try
      {
        _builder.Start(mazeName);

        using StreamReader reader = new StreamReader($"{mazeName}.maze");
        string text = reader.ReadToEnd();
        Debug.WriteLine(text);
        for (int character = 0, row = 0, col = 0; character < text.Length; character++, col++)
        {
          //Skipping spaces, newlines and carriage returns CRLF
          switch (text[character])
          {
            case '\n':
              row++;
              col = -1;
              break;

            case ' ':
              break;

            case (char)MazeSymbol.Wall:
              _builder.AddWall(row, col);
              break;

            case (char)MazeSymbol.Room:
              _builder.AddRoom(row, col);
              break;

            case (char)MazeSymbol.Character:
              _builder.AddPlayer(row, col);
              break;
            case (char)MazeSymbol.Key:
              _builder.AddKey(row, col);
              break;
          }
        }

        _builder.Finish();
      }
      catch (IOException e)
      {
        Debug.WriteLine("The file couldn't be read: ");
        Debug.WriteLine(e.Message);
      }
    }
  }
}