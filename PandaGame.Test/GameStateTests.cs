using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaGame.Domain;
using PandaGame.Domain.Plots;
using PandaGame.Domain.Services;
using static PandaGame.Domain.Services.GameStateService;

namespace PandaGame.Test
{
  [TestClass]
  public class GameStateTests
  {
    
    private GameState initialGameState;

    [TestInitialize()]
    public void Initialize() {
    
      initialGameState = NewGame(new Random(1));
    }

    [TestMethod]
    public void TestInitialize()
    {
      Assert.IsTrue(initialGameState.IrrigationGrid.Contains((0, 1)));
      Assert.AreEqual(6, initialGameState.IrrigationGrid.Count);
      Assert.AreEqual(9, initialGameState.ImprovementChipPool.Count());
      Assert.AreEqual(27, initialGameState.PlotTileDeck.Count);
      Assert.AreEqual(0, initialGameState.PlotGrid.Count);
      
      Assert.AreEqual(new PlotTile(BambooColor.Pink, PlotImprovement.None), initialGameState.PlotTileDeck[0]);
      Assert.AreEqual(new PlotTile(BambooColor.Pink, PlotImprovement.Enclosure), initialGameState.PlotTileDeck[1]);
      Assert.AreEqual(7, initialGameState.PlotTileDeck.Count(x => x.Color == BambooColor.Pink));
      Assert.AreEqual(9, initialGameState.PlotTileDeck.Count(x => x.Color == BambooColor.Yellow));
      Assert.AreEqual(11, initialGameState.PlotTileDeck.Count(x => x.Color == BambooColor.Green));
    }

    [TestMethod]
    public void PlaceTile_Success()
    {
      var tile = new PlotTile(BambooColor.Green);
      var location = (0,1);
      var newState = GameStateService.PlaceTile(initialGameState, new PlotTile(BambooColor.Green), location);

      Assert.AreEqual(tile, newState.PlotGrid[location].Tile);
    }

    [TestMethod]
    public void PlaceTile_OriginFails()
    {
      var tile = new PlotTile(BambooColor.Green);
      var origin = (0,0);
      Assert.ThrowsException<ArgumentException>(() => initialGameState.PlaceTile(tile, origin));
    }

    [TestMethod]
    public void PlaceTile_OverwriteFails()
    {
      var tile = new PlotTile(BambooColor.Green, PlotImprovement.Enclosure);
      var location = (0, 1);
      var nextState = initialGameState.PlaceTile(tile, location);
      Assert.ThrowsException<ArgumentException>(() => nextState.PlaceTile(tile, location));
    }
  }
}