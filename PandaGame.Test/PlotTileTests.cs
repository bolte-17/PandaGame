using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaGame.Domain;
using PandaGame.Domain.Plots;

namespace PandaGame.Test
{
  [TestClass]
  public class PlotTileTests
  {
    [TestMethod]
    public void PlotEquality()
    {
      var tile1 = new PlotTile(BambooColor.Green, PlotImprovement.Enclosure);
      var tile2 = new PlotTile(BambooColor.Green, PlotImprovement.Enclosure);

      Assert.AreEqual(tile1, tile2);
    }

    [TestMethod]
    public void PlotEquality_DifferentColorsNotEqual()
    {
      var tile1 = new PlotTile(BambooColor.Green);
      var tile2 = new PlotTile(BambooColor.Pink);

      Assert.AreNotEqual(tile1, tile2);
    }

    [TestMethod]
    public void PlotEquality_DifferentImprovementsNotEqual()
    {
      var tile1 = new PlotTile(BambooColor.Green, PlotImprovement.Enclosure);
      var tile2 = new PlotTile(BambooColor.Green, PlotImprovement.Fertilizer);

      Assert.AreNotEqual(tile1, tile2);
    }

    [TestMethod]
    public void PlotEquality_Nulls()
    {
      var tile1 = new PlotTile(BambooColor.Green, PlotImprovement.Enclosure);
      PlotTile nullTile1 = null;
      PlotTile nullTile2 = null;

      Assert.AreEqual(nullTile1, nullTile2);
      Assert.AreNotEqual(tile1, nullTile1);
      Assert.AreNotEqual(nullTile1, tile1);
    }

    [TestMethod]
    public void PlotEquality_HashCodes()
    {
      var tile1 = new PlotTile(BambooColor.Green, PlotImprovement.Enclosure);
      var tile2 = new PlotTile(BambooColor.Green, PlotImprovement.Enclosure);

      Assert.AreEqual(tile1.GetHashCode(), tile2.GetHashCode());

      var set = new HashSet<PlotTile>();
      set.Add(tile1);
      set.Add(tile2);
      
      Assert.AreEqual(1, set.Count);
    }
  }
}