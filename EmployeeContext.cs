using Microsoft.EntityFrameworkCore;
using lab4.ViewModels;

namespace lab4.DTO.Models
{
    public class EmployeeContext : DbContext
    {
        #region Constructors

        public EmployeeContext(DbContextOptions<EmployeeContext> connection) : base(connection)
        {
        }

        #endregion Constructors

        #region Properties

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<FullName> FullName { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<ProjectInfo> ProjectInfo { get; set; }

        public DbSet<lab4.ViewModels.EmployeeViewModel> EmployeeViewModel { get; set; }

        #endregion Properties

        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<lab4.ViewModels.AddressViewModel> AddressViewModel { get; set; }

        public DbSet<lab4.ViewModels.FullNameViewModel> FullNameViewModel { get; set; }

        public DbSet<lab4.ViewModels.PositionViewModel> PositionViewModel { get; set; }

        public DbSet<lab4.ViewModels.ProjectInfoViewModel> ProjectInfoViewModel { get; set; }

        #endregion Methods
    }
}