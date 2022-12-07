namespace CarHire.Core.Models.Comment
{
    public class CommentExposeModel
    {
        public string ImageUrl { get; set; } = null!;

        public IEnumerable<CommentByVehicleModel> Comments { get; set; } = Enumerable.Empty<CommentByVehicleModel>();
    }
}
