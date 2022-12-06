﻿namespace CarHire.Core.Services
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;

    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Vehicle;
    using CarHire.Infrastructure.Data.Common;
    using CarHire.Infrastructure.Data.Entities;
    using CarHire.Core.Models.Enum;
    using CarHire.Infrastructure.Data.Entities.Enums;

    public class VehicleService : IVehicleService
    {
        private readonly IRepository repo;

        public VehicleService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await repo.AllReadonly<Vehicle>(v => v.Id.ToString() == id && !v.IsDeleted).AnyAsync();
        }

        public async Task<IEnumerable<VehicleHomeModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Vehicle>(x => !x.IsDeleted)
                .OrderBy(v => v.CategoryId)
                .Select(v => new VehicleHomeModel()
                {
                    Id = v.Id.ToString(),
                    ImageUrl = v.ImageUrl,
                    IsRented = v.IsRented
                })
                .ToListAsync();
        }

        public async Task<VehicleDetailsModel> GetVehicleDetailsByIdAsync(string id)
        {
            return await repo.AllReadonly<Vehicle>(v => v.Id.ToString() == id && !v.IsDeleted)
                .Select(x => new VehicleDetailsModel()
                {
                    Id = x.Id.ToString(),
                    Make = x.Make,
                    Model = x.Model,
                    ImageUrl = x.ImageUrl,
                    Year = x.Year,
                    IsRented = x.IsRented,
                    Transmission = x.Transmission.ToString(),
                    Suspension = x.Suspension.ToString(),
                    FuelType = x.Fuel.ToString(),
                    AirCondition = x.AirConditioning,
                    NavigationSystem = x.NavigationSystem,
                    CategoryName = x.Category.Name,
                    Consumption = x.Consumption,
                    Doors = x.Doors,
                    PricePerDay = x.PricePerDay,
                    Seats = x.Seats,
                    TankCapacity = x.TankCapacity

                }).FirstAsync();
        }

        public async Task<IEnumerable<VehicleHomeModel>> GetVehiclesByCategoryAsync(int categoryId)
        {
            return await repo.AllReadonly<Vehicle>(x => !x.IsDeleted && !x.IsRented)
                .Where(v => v.CategoryId == categoryId)
                .Select(v => new VehicleHomeModel()
                {
                    Id = v.Id.ToString(),
                    ImageUrl = v.ImageUrl
                })
                .ToListAsync();
        }

        public async Task DropVehicleAsync(string id)
        {
            Guid vehicleId = Guid.Parse(id);

            var vehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);
            if (!vehicle.IsDeleted)
            {
                vehicle.IsRented = false;
                await repo.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<VehicleCategoryModel>> GetCategoriesAsync()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => new VehicleCategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public IEnumerable<TransmissionModel> GetTransmissions()
        {
            MemberInfo[] memberInfos = typeof(Transmission).GetMembers(BindingFlags.Public | BindingFlags.Static);
            List<TransmissionModel> transmissions = new();

            foreach (var item in memberInfos)
            {
                transmissions.Add(new TransmissionModel()
                {
                    TransmissionId = (int)Enum.Parse(typeof(Transmission), item.Name),
                    TransmissionType = item.Name
                });
            }

            return transmissions;
        }

        public IEnumerable<SuspensionModel> GetSuspensions()
        {
            MemberInfo[] memberInfos = typeof(Suspension).GetMembers(BindingFlags.Public | BindingFlags.Static);
            List<SuspensionModel> suspensions = new();

            foreach (var item in memberInfos)
            {
                suspensions.Add(new SuspensionModel()
                {
                    SuspensionId = (int)Enum.Parse(typeof(Suspension), item.Name),
                    SuspensionType = item.Name
                });
            }

            return suspensions;
        }

        public IEnumerable<FuelModel> GetFuels()
        {
            MemberInfo[] memberInfos = typeof(Fuel).GetMembers(BindingFlags.Public | BindingFlags.Static);
            List<FuelModel> fuels = new();

            foreach (var item in memberInfos)
            {
                fuels.Add(new FuelModel()
                {
                    FuelId = (int)Enum.Parse(typeof(Fuel), item.Name),
                    FuelType = item.Name
                });
            }

            return fuels;
        }

        public async Task CreateVehicleAsync(VehicleAddModel v)
        {
            Vehicle vehicle = new()
            {
                Make = v.Make,
                Model = v.Model,
                Year = v.Year,
                Kilometers = v.Kilometers,
                AirConditioning = v.AirCondition,
                NavigationSystem = v.NavigationSystem,
                Seats = v.Seats,
                Doors = v.Doors,
                Suspension = (Suspension)v.SuspensionId,
                Fuel = (Fuel)v.FuelId,
                Transmission = (Transmission)v.TransmissionId,
                CategoryId = v.CategoryId,
                ImageUrl = v.ImageUrl,
                TankCapacity = v.TankCapacity,
                Consumption = v.Consumption,
                PricePerDay = v.PricePerDay
            };

            await repo.AddAsync(vehicle);
            await repo.SaveChangesAsync();
        }
    }
}