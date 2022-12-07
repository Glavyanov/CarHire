namespace CarHire.Areas.Management.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Vehicle;
    using static CarHire.Infrastructure.Data.ValidationConstants;

    public class HomeController : BaseController
    {
        private readonly IVehicleService vehicleService;

        public HomeController(IVehicleService _vehicleService)
        {
            vehicleService = _vehicleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditAll()
        {
            var vehicles = await vehicleService.GetAllAsync();

            return View(vehicles);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            VehicleEditModel model = new();
            if (await vehicleService.ExistsAsync(id))
            {
                model = await vehicleService.GetVehicleEditModelAsync(id);
                model.VehicleCategories = await vehicleService.GetCategoriesAsync();
                model.Transmissions = vehicleService.GetTransmissions();
                model.Fuels = vehicleService.GetFuels();
                model.Suspensions = vehicleService.GetSuspensions();
            }
            else
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageVehicle;
                return RedirectToAction(nameof(EditAll));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VehicleEditModel editModel)
        {
            if (!ModelState.IsValid || !await vehicleService.ExistsAsync(editModel.Id))
            {
                editModel.VehicleCategories = await vehicleService.GetCategoriesAsync();
                editModel.Transmissions = vehicleService.GetTransmissions();
                editModel.Fuels = vehicleService.GetFuels();
                editModel.Suspensions = vehicleService.GetSuspensions();

                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageAddVehicle;

                return View(editModel);
            }

            await vehicleService.EditVehicleAsync(editModel);

            TempData[MessageConstant.WarningMessage] = MessageConstant.WarningMessageEditVehicle;

            return RedirectToAction("Details", "Vehicles", new { area = "" , id = editModel.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            VehicleAddModel model = new()
            {
                VehicleCategories = await vehicleService.GetCategoriesAsync(),
                Transmissions = vehicleService.GetTransmissions(),
                Fuels = vehicleService.GetFuels(),
                Suspensions = vehicleService.GetSuspensions()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(VehicleAddModel postModel)
        {
            if (!ModelState.IsValid)
            {
                postModel.VehicleCategories = await vehicleService.GetCategoriesAsync();
                postModel.Transmissions = vehicleService.GetTransmissions();
                postModel.Fuels = vehicleService.GetFuels();
                postModel.Suspensions = vehicleService.GetSuspensions();

                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageAddVehicle;

                return View(postModel);
            }

            await vehicleService.CreateVehicleAsync(postModel);

            TempData[MessageConstant.WarningMessage] = MessageConstant.WarningMessageAddVehicle;

            return RedirectToAction(nameof(Index), "Vehicles", new { area = "" });
        }
    }
}
