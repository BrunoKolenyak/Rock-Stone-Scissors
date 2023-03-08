using System;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Contexts;
using RockPaperScissors.Models;

namespace RockPaperScissors.Repositories
{
	public class GameRepository : IGameRepository
	{
        private readonly Context _context;

        public GameRepository(Context context)
		{
			_context = context;
		}

        public void Save(string result)
        {
            Game game;
            if (result == "Tie")
            {
                game = new Game(true);
            }
            else
            {
                game = new Game(false, result);
            }

            _context.Add(game);
            _context.SaveChanges();
        }

        public void ClearResults()
        {
            _context.Games.RemoveRange(_context.Games);
            _context.SaveChanges();
        }

        public ICollection<Game> GetAllResults()
        {
            return _context.Games.ToList();
        }
	}
}

