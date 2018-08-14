using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Optional;

namespace PandaGame.Domain.HexGrids
{
  /// Utility methods for working with hexagonal grids. Uses axial coordinates from https://www.redblobgames.com/grids/hexagons with point-up orientation
  public static class HexGrids
  {
    // Unit vectors of the six hex directions, starting from "left" and going clockwise.
    private static readonly IEnumerable<HexIndex> AxialUnits = new HexIndex[] {
      (-1, 0),
      (0, -1),
      (1, -1),
      (1, 0),
      (0, 1),
      (-1, 1),
      (-1, 0)
    };

    public static IEnumerable<HexIndex> Neighbors(this HexIndex index) => AxialUnits.Select(unit => index + unit);

    public static IEnumerable<T> NeighborsOf<T>(this IDictionary<HexIndex, T> dict, HexIndex index)
    {
      foreach (var neighborIndex in index.Neighbors())
      {
        if (dict.TryGetValue(neighborIndex, out var value))
          yield return value;
      }
    }
  }
}