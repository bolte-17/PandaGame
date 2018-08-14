using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MoreLinq;
using PandaGame.Domain.Plots;
using PandaGame.Domain.HexGrids;

namespace PandaGame.Domain.Services
{
  public static class GameStateService
  {
    public static readonly IDictionary<PlotTile, int> PlotTileCounts = new Dictionary<PlotTile, int>
    {
      [new PlotTile(BambooColor.Green, PlotImprovement.None)] = 5,
      [new PlotTile(BambooColor.Green, PlotImprovement.Enclosure)] = 2,
      [new PlotTile(BambooColor.Green, PlotImprovement.Fertilizer)] = 2,
      [new PlotTile(BambooColor.Green, PlotImprovement.Watershed)] = 2,
      [new PlotTile(BambooColor.Yellow, PlotImprovement.None)] = 6,
      [new PlotTile(BambooColor.Yellow, PlotImprovement.Enclosure)] = 1,
      [new PlotTile(BambooColor.Yellow, PlotImprovement.Fertilizer)] = 1,
      [new PlotTile(BambooColor.Yellow, PlotImprovement.Watershed)] = 1,
      [new PlotTile(BambooColor.Pink, PlotImprovement.None)] = 4,
      [new PlotTile(BambooColor.Pink, PlotImprovement.Enclosure)] = 1,
      [new PlotTile(BambooColor.Pink, PlotImprovement.Fertilizer)] = 1,
      [new PlotTile(BambooColor.Pink, PlotImprovement.Watershed)] = 1,
    };

    public static readonly IDictionary<PlotImprovement, int> ImprovementChipCounts = new Dictionary<PlotImprovement, int>
    {
      [PlotImprovement.Enclosure] = 3,
      [PlotImprovement.Fertilizer] = 3,
      [PlotImprovement.Watershed] = 3,
    };

    public static GameState NewGame(Random random = null)
    {
      return new GameState(
        PlotTileCounts.SelectMany(kv => Enumerable.Repeat(kv.Key, kv.Value))
          .OrderBy(x => x.Color).ThenBy(x => x.Improvement) // IDictionary
          .Shuffle(random ?? new Random()).ToImmutableList(),
        ImprovementChipCounts.SelectMany(kv => Enumerable.Repeat(kv.Key, kv.Value)).OrderBy(x => x),
        ImmutableDictionary<HexIndex, Plot>.Empty,
        HexIndex.Origin.Neighbors()
      );
    }

    public static GameState PlaceTile(this GameState gameState, PlotTile tile, HexIndex location) {
      if (location == (0,0))
        throw new ArgumentException("Cannot place tile at pond's location (0,0)", nameof(location));
      var newDeck = gameState.PlotTileDeck.Remove(tile);
      if (newDeck.Count == gameState.PlotTileDeck.Count)
        throw new ArgumentException("Tile not available in deck", nameof(tile));
      if (gameState.PlotGrid.ContainsKey(location))
        throw new ArgumentException("Plot already exists at location", nameof(location));

      return new GameState(
        newDeck,
        gameState.ImprovementChipPool,
        gameState.PlotGrid.Add(location, new Plot(tile)),
        gameState.IrrigationGrid
      );
    }
  }
}