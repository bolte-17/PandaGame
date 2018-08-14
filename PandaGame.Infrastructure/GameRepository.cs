using System;
using PandaGame.Domain;

namespace PandaGame.Infrastructure
{
  public interface IGameRepository
  {
    GameState GameState { get; set; }
  }
  public class SingleGameRepository : IGameRepository
  {
    public GameState GameState {
      get;
      set;
    }
  }
}
