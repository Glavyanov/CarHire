namespace CarHire.Controllers
{
    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Vehicle;
    using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Index()
        {
            var vehicles = await vehicleService.GetAllAsync();

            return View(vehicles);
        }

        [HttpGet]
        public async Task<IActionResult> ByCategory(int categoryId)
        {
            if (await categoryService.ExistsbyIdAsync(categoryId) == false)
            {
                return View();
            }

            var vehicles = await vehicleService.GetVehiclesByCategoryAsync(categoryId);

            return View(vehicles);
        }
    }
}
