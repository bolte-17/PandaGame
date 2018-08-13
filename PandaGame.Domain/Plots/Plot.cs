namespace PandaGame.Domain.Plots
{
  /// Represents a plot tile in play, as opposed to a tile in the deck.
  /// 
  public class Plot
  {
    public PlotTile Tile { get; }
    public PlotImprovement ImprovementChip { get; }
    public PlotImprovement Improvement => Tile.Improvement != PlotImprovement.None ? Tile.Improvement : ImprovementChip;

    public bool IsIrrigated { get; }
    public int BambooCount { get; }

    public Plot(PlotTile tile, PlotImprovement improvementChip = PlotImprovement.None, bool isIrrigated = false, int bambooCount = 0) {
      Tile = tile;
      ImprovementChip = improvementChip;
      IsIrrigated = isIrrigated;
      BambooCount = bambooCount;
    }
  }
}