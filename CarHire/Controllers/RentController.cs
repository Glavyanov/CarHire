namespace CarHire.Controllers
{
    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Vehicle;
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
        public IActionResult Index(VehicleRentModel model)
        {
            if (!TempData.ContainsKey(model.Id))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageVehicle;
                return RedirectToAction("Index", "Home");

            }

            //TODO:
            return View(model);
        }


        public IActionResult MyRent(string id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
