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

        public async Task<IEnumerable<CategoryHomeModel>> GetCategoriesAsync()
        {
            return await this.repository.AllReadonly<Category>()
                .Select(c => new CategoryHomeModel()
                {
                    Name = c.Name
                })
                .ToListAsync();
        }
    }
}
