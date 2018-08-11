using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaGame.Domain;

namespace PandaGame.Test
{
  [TestClass]
  public class GridTests
  {
    [TestMethod]
    public void CreateHexGrid()
    {
      var testGrid = new SparseHexGrid<string>();
      Assert.AreEqual(0, testGrid.Count());
    }

    [TestMethod]
    public void AddValue_Single()
    {
      var testGrid = new SparseHexGrid<string>();
      
      testGrid.Add(0, 0, "TestElement");
      Assert.AreEqual(1, testGrid.Count());
    }

    [TestMethod]
    public void AddValue_Multiple()
    {
      var testGrid = new SparseHexGrid<string>();
      
      testGrid.Add(0, 0, "TestElement1");
      testGrid.Add(0, 1, "TestElement2");

      Assert.AreEqual(2, testGrid.Count());
    }

    [TestMethod]
    public void AddValue_NoOverwrite()
    {
      var testGrid = new SparseHexGrid<string>();
      
      testGrid.Add(0, 0, "TestElement1");
      
      Assert.ThrowsException<ArgumentException>(() => testGrid.Add(0, 0, "TestElement2"));
    }
  }
}
