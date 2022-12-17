namespace CarHire.Core.Contracts
{
    using CarHire.Core.Models.Discount;

    public interface IDiscountService
    {
        Task<IEnumerable<DiscountHomeModel>> GetAllAsync();

        Task CreateDiscountAsync(DiscountAddModel model);

        Task<bool> ExistsbyIdAsync(string id);

        Task EditDiscountAsync(DiscountHomeModel model);

        Task<DiscountsVehicleModel> GetVehicleAndDiscountsAsync(string vehicleId);

        Task<bool> ExistDiscountOnVehicleAsync(string vehicleId, string discountId);

        Task AddDiscountToVehicleAsync(string vehicleId, string discountId);

        Task RemoveDiscountFromVehicleAsync(string vehicleId, string discountId);
    }
}
