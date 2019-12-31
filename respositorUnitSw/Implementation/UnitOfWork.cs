using respositorUnitSw.Interface;
using respositorUnitSw.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace respositorUnitSw.Implementation
{
    public class UnitOfWork : IUnitOfWork, System.IDisposable
    {
        //DatabaseContext
        private readonly DatabaseContext _context;
       

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        private IGenericRepository<Work> _WorkRepository;
        public IGenericRepository<Work> WorkRepository
        {
            get { return _WorkRepository ?? (_WorkRepository = new GenericRepository<Work>(_context)); }
        }
        private IGenericRepository<Person> _PersonRepository;
        public IGenericRepository<Person> PersonRepository
        {
            get { return _PersonRepository ?? (_PersonRepository = new GenericRepository<Person>(_context)); }
        }

        public IGenericRepository<Order> Order => throw new NotImplementedException();

        private IGenericRepository<Order> _OrderRepository;
        public IGenericRepository<Order> OrderRepository
        {
            get { return _OrderRepository ?? (_OrderRepository = new GenericRepository<Order>(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
