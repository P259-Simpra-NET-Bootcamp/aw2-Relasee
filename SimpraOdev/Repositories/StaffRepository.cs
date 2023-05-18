using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpraOdev.Data;
using SimpraOdev.Models;

namespace SimpraOdev.Repositories
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public StaffRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public Staff GetByEmail(string email)
        {
            return _dbContext.Staffs.FirstOrDefault(s => s.Email == email);
        }
    }
}
