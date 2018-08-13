using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Medallion;
using PandaGame.Domain.Plots;

namespace PandaGame.Domain
{
  public class GameState
  {
    public ImmutableList<PlotTile> PlotTileDeck { get; private set; }
    public ImmutableDictionary<PlotImprovement, int> ImprovementChipPool { get; private set; }
    public ImmutableDictionary<(int q, int r), Plot> PlotGrid { get; private set; }
    public ImmutableDictionary<(int q, int r), bool> IrrigationGrid { get; private set; }

    public GameState(
      ImmutableList<PlotTile> plotTileDeck,
      ImmutableDictionary<PlotImprovement, int> improvementChipPool,
      ImmutableDictionary<(int q, int r), Plot> plotGrid,
      ImmutableDictionary<(int q, int r), bool> irrigationGrid
      )
    {
      PlotTileDeck = plotTileDeck;
      ImprovementChipPool = improvementChipPool;
      PlotGrid = plotGrid;
      IrrigationGrid = irrigationGrid;
    }
  }
}