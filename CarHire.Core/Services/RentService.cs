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

        public async Task<string> CreateRenterAsync(RenterHomeModel model)
        {
            Guid vehicleId = Guid.Parse(model.VehicleId);
            Vehicle vehicle = 
                await repo.All<Vehicle>(v => v.Id == vehicleId)
                .Include(x => x.VehicleDiscounts)
                .ThenInclude(x => x.Discount)
                .FirstAsync();

            decimal checkVehiclePrice = await repo.All<Vehicle>(v => v.Id == vehicleId)
                .Include(x => x.VehicleDiscounts)
                .ThenInclude(x => x.Discount)
                .Select(x => x.VehicleDiscounts.Sum(s => s.Discount.DiscountSize) != 0
                    ? Math.Round(
                        x.PricePerDay *
                        (decimal)(1 - (x.VehicleDiscounts.Sum(s => s.Discount.DiscountSize) * 1.00 / 100)), 2)
                    : x.PricePerDay)
                .FirstAsync();

            if (checkVehiclePrice > model.HiredCarPricePerDay)
            {
                throw new ArgumentException("The price is manipulated!");
            }

            Renter renter = new()
            {
                ApplicationUserId = model.ApplicationUserId,
                RenterDiscount = model.RenterDiscount,
                DrivingLicenseNumber = model.DrivingLicenseNumber,
                RegisteredOn = model.RegisteredOn,
                TotalValue = model.TotalValue,
            };

            vehicle.IsRented = true;

            await repo.AddAsync<Renter>(renter);
            await repo.SaveChangesAsync();

            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(model.RentDays);

            int sumOfVehicleDiscounts = vehicle.VehicleDiscounts.Sum(s => s.Discount.DiscountSize);

            Order order = new()
            {
                RenterId = renter.Id,
                VehicleId = vehicleId,
                StartDate = startDate,
                EndDate = endDate,
                VehicleDiscount = sumOfVehicleDiscounts,
                TotalDays = model.RentDays,
                Price = vehicle.PricePerDay,
                TotalPriceWithDiscounts = model.TotalValue,
                IsDeleted = false
            };

            await repo.AddAsync<Order>(order);
            await repo.SaveChangesAsync();

            return renter.Id.ToString();
        }

        public async Task<bool> DeleteOrderAsync(string vehicleId, string applicationUserId)
        {
            Guid vehicleGuidId = Guid.Parse(vehicleId);

            var rentersIds = await repo.AllReadonly<Renter>(x => x.ApplicationUserId == applicationUserId)
                .Select(x => x.Id)
                .ToListAsync();

            var order = await repo.All<Order>( o => !o.IsDeleted &&
                            rentersIds.Contains(o.RenterId) && 
                            o.VehicleId == vehicleGuidId).FirstOrDefaultAsync();
            if (order != null)
            {
                order.IsDeleted = true;
                await repo.SaveChangesAsync();
            }

            return order?.IsDeleted ?? false;
        }

        public async Task<bool> ExistsByApplicationUserIdAsync(string id)
        {
            return await repo.All<Renter>(r => r.ApplicationUserId == id).AnyAsync();
        }

        public async Task<RenterHomeModel> GetRenterByIdAsync(string id)
        {
            Guid renterGuid = Guid.Parse(id);

            var renter = await repo.GetByIdAsync<Renter>(renterGuid);

            RenterHomeModel model = new()
            {
                Id = renter.Id.ToString()
            };

            return model;
        }

        public async Task<VehicleRentModel> GetVehicleRentByIdAsync(string id)
        {
            return await repo.All<Vehicle>(v => v.Id.ToString() == id && !v.IsDeleted)
                .Include(x => x.VehicleDiscounts)
                .ThenInclude(x => x.Discount)
                .Select(v => new VehicleRentModel()
                {
                    Id = v.Id.ToString(),
                    ImageUrl = v.ImageUrl,
                    IsRented = v.IsRented,
                    PricePerDay = v.VehicleDiscounts.Sum(s => s.Discount.DiscountSize) != 0 
                    ? Math.Round(
                        v.PricePerDay * 
                        (decimal)(1 - (v.VehicleDiscounts.Sum(s => s.Discount.DiscountSize) * 1.00 / 100)), 2)
                    : v.PricePerDay

                }).FirstAsync();
        }
        public async Task<List<VehicleHomeModel>> GetVehiclesByRenterIdAsync(string id)
        {
            var rentersIds = await repo.AllReadonly<Renter>(x => x.ApplicationUserId == id)
                .Select(x => x.Id)
                .ToListAsync();

            var vehiclesId = 
                await repo.AllReadonly<Order>(o => rentersIds.Contains(o.RenterId) && !o.IsDeleted)
                .Select(x => x.VehicleId)
                .ToListAsync();

            return await repo.AllReadonly<Vehicle>(
                x => vehiclesId.Contains(x.Id) && !x.IsDeleted && x.IsRented)
                    .Select(v => new VehicleHomeModel()
                    {
                        Id = v.Id.ToString(),
                        ImageUrl = v.ImageUrl
                    })
                    .ToListAsync();
        }
    }
}
