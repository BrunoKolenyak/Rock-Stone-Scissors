using System;
using RockPaperScissors.Contexts;
using RockPaperScissors.Models;

namespace RockPaperScissors.Repositories
{
	public interface IGameRepository
	{
		public void Save(string result);
		public void ClearResults();
		public ICollection<Game> GetAllResults();
	}
}

