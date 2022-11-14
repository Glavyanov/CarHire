namespace CarHire.Core.Contracts
{
    using CarHire.Core.Models.Category;
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryHomeModel>> GetCategoriesAsync();
    }
}
