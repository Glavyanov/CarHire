namespace CarHire.Areas.Management.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Discount;
    using static CarHire.Infrastructure.Data.ValidationConstants;

    public class DiscountController : BaseController
    {
        private readonly IDiscountService discountService;
        private readonly IVehicleService vehicleService;

        public DiscountController(
            IDiscountService _discountService,
            IVehicleService _vehicleService)
        {
            discountService = _discountService;
            vehicleService = _vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var discounts = await discountService.GetAllAsync();

            return View(discounts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            DiscountAddModel model = new();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DiscountAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            var discounts = await discountService.GetAllAsync();

            if (discounts.Any(x => x.Name.ToLower() == model.Name.ToLower()))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageDiscountExist;

                return View(model);
            }

            await discountService.CreateDiscountAsync(model);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (!await discountService.ExistsbyIdAsync(id))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageDiscount;

                return RedirectToAction(nameof(Index));
            }

            var discount = (await discountService.GetAllAsync())
                .FirstOrDefault(x => x.Id == id);

            return View(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DiscountHomeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await discountService.ExistsbyIdAsync(model?.Id ?? string.Empty))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageDiscount;

                return RedirectToAction(nameof(Index));
            }

            var discounts = await discountService.GetAllAsync();

            Func<DiscountHomeModel, bool> checkDiscount = (DiscountHomeModel x) =>
            x.Name.ToLower() == model!.Name.ToLower() && x.DiscountSize == model.DiscountSize;

            if (discounts.Any(checkDiscount))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageDiscountExist;

                return View(model);
            }

            try
            {
                await discountService.EditDiscountAsync(model!);
            }
            catch (ArgumentException ex)
            {

                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AllVehicles()
        {
            var vehicles = await vehicleService.GetAllAsync();

            return View(vehicles);
        }

        [HttpGet]
        public async Task<IActionResult> AddToVehicle(string vehicleId)
        {
            if (!await vehicleService.ExistsAsync(vehicleId))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageVehicle;

                return RedirectToAction(nameof(AllVehicles));
            }

            var model = await discountService.GetVehicleAndDiscountsAsync(vehicleId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToVehicle(
            [FromForm(Name = "VehicleId")] string vehicleId,
            [FromForm(Name = "DiscountId")] string discountId)
        {
            if (await discountService.ExistDiscountOnVehicleAsync(vehicleId, discountId))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageDiscountOnVehicleExist;

                return RedirectToAction(nameof(AllVehicles));
            }

            if (!await vehicleService.ExistsAsync(vehicleId))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageVehicle;

                return RedirectToAction(nameof(AllVehicles));
            }

            if (!await discountService.ExistsbyIdAsync(discountId))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageDiscount;

                return RedirectToAction(nameof(AllVehicles));
            }

            await discountService.AddDiscountToVehicleAsync(vehicleId, discountId);

            TempData[MessageConstant.WarningMessage] = MessageConstant.WarningMessageDiscountAdded;

            return RedirectToAction("Details", "Vehicles", new { area = "", id = vehicleId });
        }

        [HttpPost]
        public async Task<IActionResult> Remove(
            [FromForm(Name = "VehicleId")] string vehicleId,
            [FromForm(Name = "DiscountId")] string discountId)
        {

            if (!await vehicleService.ExistsAsync(vehicleId))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageVehicle;

                return RedirectToAction(nameof(AllVehicles));
            }

            if (!await discountService.ExistsbyIdAsync(discountId))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageDiscount;

                return RedirectToAction(nameof(AllVehicles));
            }

            if (!await discountService.ExistDiscountOnVehicleAsync(vehicleId, discountId))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageDiscountOnVehicleNotExists;

                return RedirectToAction(nameof(AllVehicles));
            }

            try
            {
                await discountService.RemoveDiscountFromVehicleAsync(vehicleId, discountId);

                TempData[MessageConstant.WarningMessage] = MessageConstant.WarningMessageDiscountRemoved;
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }

            return RedirectToAction("Details", "Vehicles", new { area = "", id = vehicleId });
        }
    }
}
