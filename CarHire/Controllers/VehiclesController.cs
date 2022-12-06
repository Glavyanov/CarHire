namespace CarHire.Controllers
{
    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Vehicle;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static CarHire.Infrastructure.Data.ValidationConstants;

    public class VehiclesController : BaseController
    {
        private readonly IVehicleService vehicleService;
        private readonly ICategoryService categoryService;

        public VehiclesController(
            IVehicleService _vehicleService,
            ICategoryService _categoryService)
        {
            vehicleService = _vehicleService;
            categoryService = _categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var vehicles = await vehicleService.GetAllAsync();

            return View(vehicles);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ByCategory(int categoryId)
        {
            if (await categoryService.ExistsbyIdAsync(categoryId) == false)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageCategory;

                return RedirectToAction("Index", "Home");
            }

            var vehicles = await vehicleService.GetVehiclesByCategoryAsync(categoryId);
            if (!vehicles.Any())
            {
                TempData[MessageConstant.WarningMessage] = MessageConstant.WarningMessageCategory;

                return RedirectToAction("Index", "Home");
            }

            return View(vehicles);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (await vehicleService.ExistsAsync(id) == false)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageVehicle;

                return RedirectToAction("Index", "Home");
            }
            var model = await vehicleService.GetVehicleDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RolesConstants.Manager)]
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
        [Authorize(Roles = RolesConstants.Manager)]
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
