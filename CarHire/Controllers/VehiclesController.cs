namespace CarHire.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using CarHire.Core.Contracts;
    using static CarHire.Infrastructure.Data.ValidationConstants.RolesConstants;


    public class VehiclesController : BaseController
    {
        private readonly IVehicleService vehicleService;

        public VehiclesController(IVehicleService _vehicleService)
        {
            vehicleService = _vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string category)
        {
            var vehicles = await vehicleService.GetVehiclesAsync(category);

            return View(vehicles);
        }
    }
}
