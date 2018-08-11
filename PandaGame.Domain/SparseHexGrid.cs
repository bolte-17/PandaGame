using System;
using System.Collections;
using System.Collections.Generic;
using Optional;

namespace PandaGame.Domain
{
  public class SparseHexGrid<T> : IEnumerable<T>
  {
    private Dictionary<(int q, int r), T> map = new Dictionary<(int q, int r), T>();

    public Option<T> GetCubic(int q, int r, int s)
    {
      if (q + r + s != 0)
        throw new ArgumentException("Cubic coordinates must sum to 0");
      return GetAxial(q, s);
    }

    public Option<T> GetAxial(int q, int r)
    {
      return map.TryGetValue((q, r), out var value) ? Option.Some(value) : Option.None<T>();
    }

    public void Add(int q, int r, T value) => map.Add((q,r), value);
    public void Add((int q, int r) index, T value) => map.Add(index, value);


    public IEnumerator<T> GetEnumerator() => map.Values.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
  }
}
