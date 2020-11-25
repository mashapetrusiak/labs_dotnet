using lab4.DTO.Interfaces;
using lab4.DTO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace lab4.DTO
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly EmployeeContext _context;

        private bool disposed = false;

        private IGenericRepository<int, Employee> _employeeRepository;

        private IGenericRepository<int, FullName> _fullNameRepository;

        private IGenericRepository<int, Position> _positionRepository;

        private IGenericRepository<int, Address> _addressRepository;

        private IGenericRepository<int, ProjectInfo> _projectInfoRepository;

        #endregion Fields

        #region Constructors

        public UnitOfWork(DbContextOptions<EmployeeContext> connection)
        {
            _context = new EmployeeContext(connection);
        }

        #endregion Constructors

        #region Properties

        public IGenericRepository<int, Employee> EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new GenericRepository<int, Employee>(_context);
                }
                return _employeeRepository;
            }
        }

        public IGenericRepository<int, FullName> FullNameRepository
        {
            get
            {
                if (_fullNameRepository == null)
                {
                    _fullNameRepository = new GenericRepository<int, FullName>(_context);
                }
                return _fullNameRepository;
            }
        }

        public IGenericRepository<int, Position> PositionRepository
        {
            get
            {
                if (_positionRepository == null)
                {
                    _positionRepository = new GenericRepository<int, Position>(_context);
                }
                return _positionRepository;
            }
        }

        public IGenericRepository<int, Address> AddressRepository
        {
            get
            {
                if (_addressRepository == null)
                {
                    _addressRepository = new GenericRepository<int, Address>(_context);
                }
                return _addressRepository;
            }
        }

        public IGenericRepository<int, ProjectInfo> ProjectInfoRepository
        {
            get
            {
                if (_projectInfoRepository == null)
                {
                    _projectInfoRepository = new GenericRepository<int, ProjectInfo>(_context);
                }
                return _projectInfoRepository;
            }
        }

        #endregion Properties

        #region Methods

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        #endregion Methods
    }
}