﻿namespace CarHire.Core.Contracts
{
    using CarHire.Core.Models.Category;
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryHomeModel>> GetCategoriesAsync();

        Task<bool> ExistsbyIdAsync(int categoryId);

        Task EditCategoryAsync(CategoryHomeModel model);

        Task CreateCategoryAsync(CategoryHomeModel model);
    }
}
