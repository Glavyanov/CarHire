namespace CarHire.Areas.Management.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Category;
    using static CarHire.Infrastructure.Data.ValidationConstants;
    using CarHire.Infrastructure.Data.Entities;

    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetCategoriesAsync();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new CategoryHomeModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryHomeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryService.CreateCategoryAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int categoryId)
        {
            if (!await categoryService.ExistsbyIdAsync(categoryId))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageCategory;

                return RedirectToAction(nameof(Index));
            }

            var category = (await categoryService.GetCategoriesAsync())
                .FirstOrDefault(x => x.CategoryId == categoryId);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryHomeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await categoryService.ExistsbyIdAsync(model.CategoryId))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageCategory;

                return RedirectToAction(nameof(Index));
            }

            await categoryService.EditCategoryAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
