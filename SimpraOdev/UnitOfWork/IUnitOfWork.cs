using SimpraOdev.Repositories;
using System;
namespace SimpraOdev.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IStaffRepository StaffRepository { get; }
        void SaveChanges();
    }
}
