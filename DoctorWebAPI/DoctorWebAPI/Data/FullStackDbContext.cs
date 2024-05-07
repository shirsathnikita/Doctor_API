using DoctorWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWebAPI.Data
{

		public class FullStackDbContext : DbContext
		{
			public FullStackDbContext(DbContextOptions options) : base(options)
			{

			}
			public DbSet<Doctor> Doctors { get; set; }
		}
	}


