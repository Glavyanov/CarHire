namespace CarHire.Core.Contracts
{
    using CarHire.Core.Models.Comment;
    public interface ICommentService
    {
        Task CreateCommentAsync(CommentHomeModel comment);

        Task<CommentExposeModel> GetAllCommentsByVehicleIdAsync(string vehicleId);

        Task<IEnumerable<CommentViewModel>> GetAllAsync();

        Task DeleteByIdAsync(string commentId);

        Task<bool> ExistByIdAsync(string commentId);
    }
}
