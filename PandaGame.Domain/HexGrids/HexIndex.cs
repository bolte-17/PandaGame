using System;

namespace PandaGame.Domain.HexGrids
{
  public struct HexIndex : IEquatable<HexIndex>
  {
    public static readonly HexIndex Origin = new HexIndex((0, 0, 0));

    public int Q { get; }
    public int R { get; }
    public int S { get; }
    private (int Q, int R, int S) tupleValue;

    public HexIndex(int Q, int R) : this((Q, R, -Q - R)) { }
    public HexIndex((int Q, int R) tuple) : this((tuple.Q, tuple.R, -tuple.Q - tuple.R)) { }
    public HexIndex(int Q, int R, int S) : this((Q, R, S)) { }
    public HexIndex((int Q, int R, int S) tuple)
    {
      var (q, r, s) = tuple;
      if (q + r + s != 0)
        throw new ArgumentException("Cubic hex indices must sum to 0");
      Q = q;
      R = r;
      S = s;
      tupleValue = tuple;
    }

    public (int Q, int R, int S) AsTuple() => tupleValue;

    public static implicit operator HexIndex((int q, int r) tuple) => new HexIndex(tuple);
    public static implicit operator HexIndex((int q, int r, int s) tuple) => new HexIndex(tuple);

    public static HexIndex operator +(HexIndex first, HexIndex second) => new HexIndex(first.Q + second.Q, first.R + second.R, first.S + second.S);

    public static HexIndex operator -(HexIndex index) => new HexIndex(-index.Q, -index.R, -index.S);
    public static HexIndex operator -(HexIndex first, HexIndex second) => first + (-second);

    public override bool Equals(object obj) => obj is HexIndex && Equals((HexIndex)obj);
    public bool Equals(HexIndex other) => AsTuple() == other.AsTuple();

    public static bool operator ==(HexIndex index1, HexIndex index2) => index1.Equals(index2);
    public static bool operator !=(HexIndex index1, HexIndex index2) => !(index1 == index2);

    public override int GetHashCode() => AsTuple().GetHashCode();
    public override string ToString() => AsTuple().ToString();
  }
}
