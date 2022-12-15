namespace CarHire.Areas.Management.Controllers
{
    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Discount;
    using Microsoft.AspNetCore.Mvc;
    using static CarHire.Infrastructure.Data.ValidationConstants;

    public class DiscountController : BaseController
    {
        private readonly IDiscountService discountService;

        public DiscountController(IDiscountService _discountService)
        {
            discountService = _discountService;
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
    }
}
