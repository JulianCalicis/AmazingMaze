using Model.Interfaces;
using System.Collections;

namespace Model.Representations
{
  /// <summary>
  /// Represents the inventory of a character
  /// </summary>
  /// <remarks>
  /// Literally a list but it doesn't accept duplicates
  /// </remarks>
  public class Inventory : ICollection<IStorable>
  {
    public Inventory()
    {
      _bag = new List<IStorable>();
    }

    private List<IStorable> _bag;
    public int Count => _bag.Count;

    public bool IsReadOnly => false;

    public void Add(IStorable item)
    {
      if (Contains(item)) return;
      _bag.Add(item);
    }

    public void Clear()
    {
      _bag.Clear();
    }

    public bool Contains(IStorable item)
    {
      return _bag.Contains(item);
    }

    public void CopyTo(IStorable[] array, int arrayIndex)
    {
      _bag.CopyTo(array, arrayIndex);
    }

    public IEnumerator<IStorable> GetEnumerator()
    {
      return _bag.GetEnumerator();
    }

    public bool Remove(IStorable item)
    {
      return _bag.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}