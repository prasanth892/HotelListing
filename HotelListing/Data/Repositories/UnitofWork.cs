using HotelListing.Data.GenericRepository;
using HotelListing.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private DataContext _context;
        IGenericRepository<Country> _countries;
        IGenericRepository<Hotel> _hotels;

        public UnitofWork(DataContext context)
        {
            _context = context;
        }

        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);

        public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
