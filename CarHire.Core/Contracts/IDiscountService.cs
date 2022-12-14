namespace CarHire.Core.Contracts
{
    using CarHire.Core.Models.Discount;

    public interface IDiscountService
    {
        Task<IEnumerable<DiscountHomeModel>> GetAllAsync();

        Task CreateDiscountAsync(DiscountAddModel model);

        Task<bool> ExistsbyIdAsync(string id);
        Task EditDiscountAsync(DiscountHomeModel model);
    }
}
