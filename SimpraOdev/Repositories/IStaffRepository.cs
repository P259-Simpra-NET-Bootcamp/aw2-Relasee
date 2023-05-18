using SimpraOdev.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpraOdev.Repositories
{
    public interface IStaffRepository : IRepository<Staff>
    {
        Staff GetByEmail(string email);
    }
}
