namespace CarHire.Infrastructure.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CarHire.Infrastructure.Data.Entities;
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasData(SeedVehicles());
        }

        private static List<Vehicle> SeedVehicles()
        {
            List<Vehicle> vehicles = new();

            Vehicle vehicle = new()
            {
                Id = new Guid("779bd522-2646-40b0-90a9-af4ddb9551a5"),
                Make = "Koenigsegg",
                Model = "RAW",
                Year = 2018,
                Transmission = Entities.Enums.Transmission.Automatic,
                AirConditioning = true,
                Seats = 2,
                ImageUrl = "https://mir-s3-cdn-cf.behance.net/project_modules/1400/9a84ff95800693.5e9ff770404b5.jpg",
                Doors = 2,
                Suspension = Entities.Enums.Suspension.Sport,
                NavigationSystem = true,
                TankCapacity = 80,
                Consumption = 20,
                Fuel = Entities.Enums.Fuel.Petrol,
                Kilometers = 10_000,
                PricePerDay = 250,
                CategoryId = 1
            };
            vehicles.Add(vehicle);

            vehicle = new()
            {
                Id = new Guid("f31db974-2830-410d-b435-66844298846a"),
                Make = "Chevrolet",
                Model = "Chevelle SS black panther",
                Year = 2014,
                Transmission = Entities.Enums.Transmission.Automatic,
                AirConditioning = true,
                Seats = 4,
                ImageUrl = "https://s1.cdn.autoevolution.com/images/news/gallery/chevrolet-chevelle-ss-black-panther-looks-wide-and-then-some_3.jpg",
                Doors = 2,
                Suspension = Entities.Enums.Suspension.Pneumatic,
                NavigationSystem = true,
                TankCapacity = 100,
                Consumption = 25,
                Fuel = Entities.Enums.Fuel.Petrol,
                Kilometers = 30_000,
                PricePerDay = 250,
                CategoryId = 1
            };
            vehicles.Add(vehicle);

            vehicle = new()
            {
                Id = new Guid("82ea3f6a-4782-41d0-bc2d-6ca2f7f9acea"),
                Make = "Nissan",
                Model = "NV200",
                Year = 2020,
                Transmission = Entities.Enums.Transmission.Automatic,
                AirConditioning = true,
                Seats = 7,
                ImageUrl = "http://3.bp.blogspot.com/-Tq37hVW0jJE/TlTJo5Q9q8I/AAAAAAAAANE/-I5-G8zgZ2w/s1600/Nissan-NV200-Concept-for-professional-photographers-1.jpg",
                Doors = 5,
                Suspension = Entities.Enums.Suspension.Pneumatic,
                NavigationSystem = true,
                TankCapacity = 40,
                Consumption = 4.3,
                Fuel = Entities.Enums.Fuel.Hybrid,
                Kilometers = 60_000,
                PricePerDay = 25,
                CategoryId = 2
            };
            vehicles.Add(vehicle);

            vehicle = new()
            {
                Id = new Guid("e0dec8e7-92c7-441e-ad75-55f8234fad59"),
                Make = "Mercedes-Benz",
                Model = "Actros",
                Year = 2015,
                Transmission = Entities.Enums.Transmission.Automatic,
                AirConditioning = true,
                Seats = 3,
                ImageUrl = "https://1.bp.blogspot.com/-rL5k8U1xzKY/VRGEpRQnY4I/AAAAAAAABmE/U66r0OBX5hw/s1600/MB%2BNew%2BActros%2B2014%2BExterior.jpg",
                Doors = 2,
                Suspension = Entities.Enums.Suspension.Pneumatic,
                NavigationSystem = true,
                TankCapacity = 1000,
                Consumption = 30,
                Fuel = Entities.Enums.Fuel.Diesel,
                Kilometers = 500_000,
                PricePerDay = 150,
                CategoryId = 3
            };
            vehicles.Add(vehicle);

            vehicle = new()
            {
                Id = new Guid("b544d7b1-7f17-4213-9823-90e82c66db2e"),
                Make = "Ford",
                Model = "F550 Executive Limo Bus",
                Year = 2020,
                Transmission = Entities.Enums.Transmission.Automatic,
                AirConditioning = true,
                Seats = 36,
                ImageUrl = "https://www.dekalblimo.com/assets/images/mini-charter-bus-825x550.jpg",
                Doors = 3,
                Suspension = Entities.Enums.Suspension.Pneumatic,
                NavigationSystem = true,
                TankCapacity = 500,
                Consumption = 20,
                Fuel = Entities.Enums.Fuel.Diesel,
                Kilometers = 200_000,
                PricePerDay = 150,
                CategoryId = 4
            };
            vehicles.Add(vehicle);

            return vehicles;
        }
    }
}
