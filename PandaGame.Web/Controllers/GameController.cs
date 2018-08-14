using Microsoft.AspNetCore.Mvc;
using PandaGame.Domain;
using PandaGame.Domain.HexGrids;
using PandaGame.Domain.Plots;
using PandaGame.Domain.Services;
using PandaGame.Infrastructure;

namespace PandaGame.Web.Controllers
{
  [ApiController, Route("api/[controller]")]
  public class GameController : ControllerBase
  {
    private readonly IGameRepository gameRepository;
    public GameController(IGameRepository gameRepository) => this.gameRepository = gameRepository;

    [Route("state")]
    public GameState GetGameState() => gameRepository.GameState ?? StartNewGame();

    [HttpPost, Route("newGame")]
    public GameState StartNewGame()
    {
      gameRepository.GameState = GameStateService.NewGame();
      return gameRepository.GameState;
    }

    [HttpPost, Route("tile")]
    public void PlaceTile(PlotTile tile, [FromQuery]HexIndex location) =>
      gameRepository.GameState = GameStateService.PlaceTile(gameRepository.GameState, tile, location);
  }
}
