using GlobalErrorApp.Models;

namespace GlobalErrorApp.Services
{
    public interface IDriverService
    {
        public Task<IEnumerable<Driver>> GetDrivers();
        public Task<Driver> GetDriverId(int id);
        public Task<Driver> AddDriver(Driver driver);
        public Task<Driver> UpdateDriver(Driver driver);
        public Task<bool> DeleteDriver(int id);

    }
}
