using System;

namespace PandaGame.Domain.Plots
{
  public class PlotTile : IEquatable<PlotTile>
  {
    public BambooColor Color { get; }
    public PlotImprovement Improvement { get; }
    
    public PlotTile(BambooColor color, PlotImprovement improvement = PlotImprovement.None) 
    {
      Color = color;
      Improvement = improvement;
    }

    public override string ToString() => (Color, Improvement).ToString();

    public bool Equals(PlotTile other) => (Color, Improvement).Equals((other.Color, other.Improvement));
    public override bool Equals(object obj) => (obj is PlotTile pt) && Equals(pt);
    public override int GetHashCode() => (Color, Improvement).GetHashCode();

    public static bool operator ==(PlotTile p1, PlotTile p2) =>
      ReferenceEquals(p1, p2) ? true :
      p1 is null ? false :
      p1.Equals(p2);

    public static bool operator !=(PlotTile p1, PlotTile p2) => !(p1 == p2);
  }
}