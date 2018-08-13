using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaGame.Domain;
using PandaGame.Domain.Plots;
using PandaGame.Domain.Services;

namespace PandaGame.Test
{
  [TestClass]
  public class GameStateTests
  {
    private GameStateService service;
    private GameState initialGameState;

    [TestInitialize()]
    public void Initialize() {
      service = new GameStateService();
      initialGameState = service.NewGame(new Random(1));
    }

    [TestMethod]
    public void TestInitialize()
    {
      Assert.IsTrue(initialGameState.IrrigationGrid[(0, 1)]);
      Assert.AreEqual(6, initialGameState.IrrigationGrid.Count);
      Assert.AreEqual(9, initialGameState.ImprovementChipPool.Values.Sum());
      Assert.AreEqual(27, initialGameState.PlotTileDeck.Count);
      Assert.AreEqual(0, initialGameState.PlotGrid.Count);
      
      Assert.AreEqual(new PlotTile(BambooColor.Pink, PlotImprovement.None), initialGameState.PlotTileDeck[0]);
      Assert.AreEqual(new PlotTile(BambooColor.Pink, PlotImprovement.Enclosure), initialGameState.PlotTileDeck[1]);
      Assert.AreEqual(7, initialGameState.PlotTileDeck.Count(x => x.Color == BambooColor.Pink));
      Assert.AreEqual(9, initialGameState.PlotTileDeck.Count(x => x.Color == BambooColor.Yellow));
      Assert.AreEqual(11, initialGameState.PlotTileDeck.Count(x => x.Color == BambooColor.Green));
      
    }
  }
}