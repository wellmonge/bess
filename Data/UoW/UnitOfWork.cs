using Domain.Interfaces;
using Data.Context;

namespace Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SusiAppContext _context;

        public UnitOfWork(SusiAppContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
