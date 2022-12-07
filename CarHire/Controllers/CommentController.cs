namespace CarHire.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using CarHire.Extensions;
    using CarHire.Core.Contracts;
    using CarHire.Core.Models.Comment;
    using static CarHire.Infrastructure.Data.ValidationConstants;
    using Microsoft.AspNetCore.Authorization;

    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;

        private readonly IVehicleService vehicleService;
        public CommentController(
            ICommentService _commentService,
            IVehicleService _vehicleService)
        {
            commentService = _commentService;
            vehicleService = _vehicleService;
        }

        [HttpGet]
        public IActionResult Index(string id)
        {
            CommentHomeModel comment = new()
            {
                VehicleId = id,
                UserId = User.Id()
            };
            return View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CommentHomeModel commentModel)
        {
            if (!ModelState.IsValid)
            {

                return View(commentModel);
            }
            try
            {
                await commentService.CreateCommentAsync(commentModel);
                TempData[MessageConstant.WarningMessage] = MessageConstant.FeedbackMessage;

                return RedirectToAction("Drop", "Rent", new { id = commentModel.VehicleId });

            }
            catch (ArgumentException ex)
            {

                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }


            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All(string vehicleId)
        {
            if (!await vehicleService.ExistsAsync(vehicleId))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageVehicle;

                return RedirectToAction("Index", "Home");
            }

            CommentExposeModel comments = await commentService.GetAllCommentsByVehicleIdAsync(vehicleId);

            return View(comments);
        }
    }
}
