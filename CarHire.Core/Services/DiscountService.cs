namespace CarHire.Core.Services
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Discount;
    using CarHire.Infrastructure.Data.Common;
    using CarHire.Infrastructure.Data.Entities;

    public class DiscountService : IDiscountService
    {
        private readonly IRepository repo;
        public DiscountService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task CreateDiscountAsync(DiscountAddModel model)
        {
            Discount discount = new()
            {
                DiscountSize = model.DiscountSize,
                Name = model.Name,
                ExpireOn = model.ExpireOn
            };

            await repo.AddAsync(discount);
            await repo.SaveChangesAsync();
        }

        public async Task EditDiscountAsync(DiscountHomeModel model)
        {
            if (Guid.TryParse(model.Id, out Guid guid))
            {
                var d = await repo.GetByIdAsync<Discount>(guid);
                d.Name = model.Name;
                d.ExpireOn = model.ExpireOn;
                d.DiscountSize = model.DiscountSize;

                await repo.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("No such discount found to edit!");
            }
            
        }

        public async Task<bool> ExistsbyIdAsync(string id) =>
            await repo.AllReadonly<Discount>(d => d.Id.ToString() == id).AnyAsync();

        public async Task<IEnumerable<DiscountHomeModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Discount>()
                .Select(d => new DiscountHomeModel()
                {
                    Id = d.Id.ToString(),
                    DiscountSize = d.DiscountSize,
                    ExpireOn = d.ExpireOn,
                    Name = d.Name

                }).ToListAsync();
        }
    }
}
