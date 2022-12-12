namespace CarHire.Core.Services
{
    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Category;
    using CarHire.Infrastructure.Data.Common;
    using CarHire.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository repository;

        public CategoryService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task EditCategoryAsync(CategoryHomeModel model)
        {
            var c = await repository.GetByIdAsync<Category>(model.CategoryId);
            c.Name = model.Name;

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsbyIdAsync(int categoryId)
        {
            return await repository.AllReadonly<Category>(c => c.Id == categoryId).AnyAsync();
        }

        public async Task<IEnumerable<CategoryHomeModel>> GetCategoriesAsync()
        {
            return await this.repository.AllReadonly<Category>()
                .Select(c => new CategoryHomeModel()
                {
                    CategoryId = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task CreateCategoryAsync(CategoryHomeModel model)
        {
            Category category = new()
            {
                Name = model.Name
            };

            await repository.AddAsync(category);
            await repository.SaveChangesAsync();
        }
    }
}
