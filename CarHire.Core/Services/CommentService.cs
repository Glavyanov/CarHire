namespace CarHire.Core.Services
{
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Comment;
    using CarHire.Infrastructure.Data.Common;
    using CarHire.Infrastructure.Data.Entities;
    

    public class CommentService : ICommentService
    {
        private readonly IRepository repo;

        public CommentService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task CreateCommentAsync(CommentHomeModel c)
        {
            var order =
                await repo.AllReadonly<Order>(o => o.VehicleId.ToString() == c.VehicleId && !o.IsDeleted)
                .FirstOrDefaultAsync();
            if (order == null)
            {
                throw new ArgumentException("The renter is not exist!");
            }

            Comment comment = new()
            {
                Date = DateTime.Now,
                VehicleId = new Guid(c.VehicleId),
                RenterId = order.RenterId
            };

            StringBuilder sb = new();
            sb.AppendLine($"{c.UserName}: ");
            sb.AppendLine($"{c.Description}");
            sb.AppendLine();
            sb.AppendLine(new string('-', 30));
            sb.AppendLine($"Date: {comment.Date}");

            comment.Description = sb.ToString().TrimEnd();

            await repo.AddAsync(comment);
            await repo.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(string commentId)
        {
            var comment = await repo.GetByIdAsync<Comment>(new Guid(commentId));
            comment.IsDeleted = true;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(string commentId)
        {
            return await repo.AllReadonly<Comment>(c => c.Id.ToString() == commentId && !c.IsDeleted)
                             .AnyAsync();
        }

        public async Task<IEnumerable<CommentViewModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Comment>(c => !c.IsDeleted)
                .Select(c => new CommentViewModel()
                {
                    Id = c.Id.ToString(),
                    Description = c.Description

                }).ToListAsync();
        }

        public async Task<CommentExposeModel> GetAllCommentsByVehicleIdAsync(string vehicleId)
        {
            IEnumerable<CommentByVehicleModel> comments = 
                await repo.AllReadonly<Comment>(c => c.VehicleId.ToString() == vehicleId && !c.IsDeleted)
                            .Select(c => new CommentByVehicleModel()
                            {
                                Description = c.Description

                            }).ToListAsync();

            var vehicle = await repo.GetByIdAsync<Vehicle>(new Guid(vehicleId));

            CommentExposeModel commentModel = new()
            {
                Comments = comments,
                ImageUrl = vehicle.ImageUrl
            };

            return commentModel;
        }
    }
}
