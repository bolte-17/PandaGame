using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Optional;

namespace PandaGame.Domain.Util
{
  /// Utility methods for working with hexagonal grids. Uses axial coordinates from https://www.redblobgames.com/grids/hexagons with point-up orientation
  public static class HexGrids
  {
    /// Unit vectors of the six hex directions, starting from "left" and going clockwise.
    private static readonly IEnumerable<(int q, int r)> AxialUnits = new[] {
      (-1, 0),
      (0, -1),
      (1, -1),
      (1, 0),
      (0, 1),
      (-1, 1),
      (-1, 0)
    };

    public static IEnumerable<(int q, int r)> NeighborIndicesOf((int q, int r) index) => AxialUnits.Select(unit => (index.q + unit.q, index.r + unit.r));

    public static IEnumerable<T> NeighborsOf<T>(this IDictionary<(int q, int r), T> dict, (int q, int r) index)
    {
      foreach (var neighborIndex in NeighborIndicesOf(index))
      {
        if (dict.TryGetValue(neighborIndex, out var value))
          yield return value;
      }
    }
  }
}