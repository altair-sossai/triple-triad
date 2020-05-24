using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TripleTriad;
using TripleTriad.Commands;
using TripleTriad.Services;

namespace TripleTriadWebApplication.Controllers
{
    [ApiController, Route("[controller]")]
    public class GameController : ControllerBase
    {
        private static readonly Dictionary<Guid, Game> Games = new Dictionary<Guid, Game>();
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet, Route("{gameId}")]
        public IActionResult Get(Guid gameId)
        {
            if (!Games.ContainsKey(gameId))
                return NotFound();

            return Ok(Games[gameId]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewGameCommand command)
        {
            var game = _gameService.CreateNewGame(command);

            Games.Add(game.Id, game);

            return Ok(game);
        }

        [HttpPut, Route("{gameId}")]
        public IActionResult Put(Guid gameId, [FromBody] PlayCommand command)
        {
            if (!Games.ContainsKey(gameId))
                return NotFound();

            var game = Games[gameId];

            game.Play(command);

            return Ok(game);
        }
    }
}