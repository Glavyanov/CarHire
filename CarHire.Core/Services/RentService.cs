namespace CarHire.Core.Services
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Renter;
    using CarHire.Core.Models.Vehicle;
    using CarHire.Infrastructure.Data.Common;
    using CarHire.Infrastructure.Data.Entities;

    public class RentService : IRentService
    {
        private readonly IRepository repo;

        public RentService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<RenterHomeModel> GetRenterByIdAsync(string id)
        {
            var renter = await repo.GetByIdAsync<Renter>(new Guid(id));

            RenterHomeModel model = new()
            {
                Id = renter.Id.ToString()
            };

            return model;
        }

        public async Task<VehicleRentModel> GetVehicleRentByIdAsync(string id)
        {
            return await repo.All<Vehicle>(v => v.Id.ToString() == id && !v.IsDeleted)
                .Select(v => new VehicleRentModel()
                {
                    Id = v.Id.ToString(),
                    ImageUrl = v.ImageUrl,
                    IsRented = v.IsRented,

                }).FirstAsync();
        }
    }
}
