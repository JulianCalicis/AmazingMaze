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
        int row = 0, col = 0;
        for (int character = 0; character < text.Length; character++, col++)
        {
          //Skipping spaces, newlines and carriage returns CRLF
          while (text[character] == '\n' || text[character] == ' ')
          {
            if (text[character] == ' ')
            {
              character++;
              col++;
            }
            else if (text[character] == '\n')
            {
              character++;
              row++;
              col = 0;
            }
          }
          switch (text[character])
          {
            case (char)MazeSymbol.Wall:
              _builder.AddWall(row, col);
              break;

            case (char)MazeSymbol.Room:
              _builder.AddRoom(row, col);
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