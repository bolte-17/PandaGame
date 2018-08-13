using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using PandaGame.Domain.Plots;
using PandaGame.Domain.Util;

namespace PandaGame.Domain.Services
{
  public class GameStateService
  {
    public static readonly ImmutableDictionary<PlotTile, int> PlotTileCounts = new Dictionary<PlotTile, int>
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
    }.ToImmutableDictionary();

    public GameState NewGame()
    {
      return new GameState(
        PlotTileCounts.SelectMany(kv => Enumerable.Repeat(kv.Key, kv.Value)).ToImmutableList(),
        new[] { PlotImprovement.Enclosure, PlotImprovement.Fertilizer, PlotImprovement.Watershed }.ToImmutableDictionary(x => x, _ => 3),
        ImmutableDictionary<(int q, int r), Plot>.Empty,
        HexGrids.NeighborIndicesOf((0, 0)).ToImmutableDictionary(x => x, _ => true)
      );
    }

    public GameState PlaceTile(GameState gameState, PlotTile tile, (int q, int r) location) {
      return new GameState(
        gameState.PlotTileDeck.Remove(tile),
        gameState.ImprovementChipPool,
        gameState.PlotGrid.Add(location, new Plot(tile)),
        gameState.IrrigationGrid
      );
    }
  }
}