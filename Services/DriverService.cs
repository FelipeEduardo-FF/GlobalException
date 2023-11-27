using GlobalErrorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalErrorApp.Services
{
    public class DriverService : IDriverService
    {
        public readonly AppDbContext _context;

        public DriverService(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Driver> AddDriver(Driver driver)
        {
            var result =await _context.Drivers.AddAsync(driver);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> DeleteDriver(int id)
        {
            var driver =await GetDriverId(id);
              _context.Remove(driver);
            await _context.SaveChangesAsync();

            return driver!= null? true: false;
        }

        public async Task<Driver> GetDriverId(int id)
        {
            return await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Driver>> GetDrivers()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task<Driver> UpdateDriver(Driver driver)
        {
            var result =  _context.Drivers.Update(driver);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
