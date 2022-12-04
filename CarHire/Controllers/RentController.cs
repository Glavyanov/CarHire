namespace CarHire.Controllers
{
    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Renter;
    using CarHire.Core.Models.Vehicle;
    using CarHire.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using static CarHire.Infrastructure.Data.ValidationConstants;

    public class RentController : BaseController
    {
        private readonly IVehicleService vehicleService;
        private readonly IRentService rentService;

        public RentController(
            IVehicleService _vehicleService,
            IRentService _rentService)
        {
            vehicleService = _vehicleService;
            rentService = _rentService;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            if (await vehicleService.ExistsAsync(id) == false)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageVehicle;

                return RedirectToAction("Index", "Home");
            }

            VehicleRentModel model = await rentService.GetVehicleRentByIdAsync(id);

            if (model.IsRented)
            {
                TempData[MessageConstant.WarningMessage] = MessageConstant.WarningMessageIsRented;

                return RedirectToAction("Index", "Vehicles");
            }

            TempData[id] = id;

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Index(VehicleRentModel model)
        {
            if (!TempData.ContainsKey(model.Id))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageVehicle;

                return RedirectToAction("Index", "Home");
            }

            int renterDiscount = RenterConstants.BasicRenterDiscount;
            decimal totalValue = Math.Round(
                    (model.PricePerDay * model.RentDays) * (decimal)(1 - (renterDiscount * 1.00 / 100)), 2);

            if (await rentService.ExistsByApplicationUserIdAsync(User.Id()))
            {
                renterDiscount = RenterConstants.ZeroDiscount;
                totalValue = model.PricePerDay * model.RentDays;
            }

            RenterHomeModel renterModel = new()
            {
                ApplicationUserId = User.Id(),
                DrivingLicenseNumber = model.DrivingLicense,
                RegisteredOn = DateTime.Now,
                RenterDiscount = renterDiscount,
                TotalValue = totalValue,
                VehicleId = model.Id,
                HiredCarPricePerDay = model.PricePerDay,
                RentDays = model.RentDays,
            };

            try
            {
                await rentService.CreateRenterAsync(renterModel);

            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;

                return View(model);
            }

            return RedirectToAction(nameof(MyRent));
        }

        [HttpGet]
        public async Task<IActionResult> MyRent()
        {
            var userId = User.Id();
            var vehicles = await rentService.GetVehiclesByRenterId(userId);

            if (!vehicles.Any())
            {
                TempData[MessageConstant.WarningMessage] = MessageConstant.WarningMessageMyRent;

                return RedirectToAction("Index", "Home");
            }

            return View(vehicles);
        }
    }
}
