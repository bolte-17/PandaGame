using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using PandaGame.Domain.Plots;

namespace PandaGame.Domain
{
  public class GameState
  {
    public ImmutableList<PlotTile> PlotTileDeck { get; private set; }
    public ImmutableList<PlotImprovement> ImprovementChipPool { get; private set; }
    public ImmutableDictionary<(int q, int r), Plot> PlotGrid { get; private set; }
    public ImmutableSortedSet<(int q, int r)> IrrigationGrid { get; private set; }

    public GameState(
      IEnumerable<PlotTile> plotTileDeck,
      IEnumerable<PlotImprovement> improvementChipPool,
      IDictionary<(int q, int r), Plot> plotGrid,
      IEnumerable<(int q, int r)> irrigationGrid
      )
    {
      PlotTileDeck = plotTileDeck.ToImmutableList();
      ImprovementChipPool = improvementChipPool.ToImmutableList();
      PlotGrid = plotGrid.ToImmutableDictionary();
      IrrigationGrid = irrigationGrid.ToImmutableSortedSet();
    }
  }
}