using ToweBones.Models;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;

namespace ToweBones.Data
{
	public class SkeleDAL
	{
		private ApplicationDbContext _context;
		public SkeleDAL(ApplicationDbContext context)
		{
			_context = context;
		}

		public void AddDevlog(Devlog devlog)
		{
			_context.Devlogs.Add(devlog);
			_context.SaveChanges();
		}

		public List<Devlog> GetAllDevlogs()
		{
			return _context.Devlogs.OrderByDescending(d=>d.Date).ToList();
		}

		public Task<List<Devlog>> GetAllDevlogsAsync()
		{
			return _context.Devlogs.OrderByDescending(d => d.Date).ToListAsync();
		}

		public List<User> GetAllUsers()
		{
			return _context.Users.ToList();
		}

		public IEnumerable<User> GetLeaderBoard()
		{
			return _context.Users.AsEnumerable().OrderByDescending(u => u.getScore());
		}
		public IEnumerable<User> GetLeaderBoardByDebt()
		{
			return _context.Users.AsEnumerable().OrderByDescending(u => u.HiDebt).AsEnumerable();
		}
		public IEnumerable<User> GetLeaderBoardByLevel()
		{
			return _context.Users.AsEnumerable().OrderByDescending(u => u.HiLevel).AsEnumerable();
		}
		

		public User GetUserById(string id)
		{
			return _context.Users.Find(id);
		}

		public User GetUserByUsername(string username)
		{
			return _context.Users.Where(u => u.Email == username).FirstOrDefault();
		}
	}
}
