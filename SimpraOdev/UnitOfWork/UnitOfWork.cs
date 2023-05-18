using SimpraOdev.Data;
using SimpraOdev.Repositories;
using System;
namespace SimpraOdev.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _dbContext;
        private IStaffRepository _staffRepository;

        public UnitOfWork(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IStaffRepository StaffRepository => _staffRepository ??= new StaffRepository(_dbContext);

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                throw; 
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
