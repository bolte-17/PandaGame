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
      Assert.AreEqual(new PlotTile(BambooColor.Green, PlotImprovement.Watershed), initialGameState.PlotTileDeck.First());
    }
  }
}