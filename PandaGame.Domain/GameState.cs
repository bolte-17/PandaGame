using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using PandaGame.Domain.HexGrids;
using PandaGame.Domain.Plots;

namespace PandaGame.Domain
{
  public class GameState
  {
    public ImmutableList<PlotTile> PlotTileDeck { get; private set; }
    public ImmutableList<PlotImprovement> ImprovementChipPool { get; private set; }
    public ImmutableDictionary<HexIndex, Plot> PlotGrid { get; private set; }
    public ImmutableHashSet<HexIndex> IrrigationGrid { get; private set; }

    public GameState(
      IEnumerable<PlotTile> plotTileDeck,
      IEnumerable<PlotImprovement> improvementChipPool,
      IDictionary<HexIndex, Plot> plotGrid,
      IEnumerable<HexIndex> irrigationGrid
      )
    {
      PlotTileDeck = plotTileDeck.ToImmutableList();
      ImprovementChipPool = improvementChipPool.ToImmutableList();
      PlotGrid = plotGrid.ToImmutableDictionary();
      IrrigationGrid = irrigationGrid.ToImmutableHashSet();
    }
  }
}