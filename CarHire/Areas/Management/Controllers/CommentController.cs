namespace CarHire.Areas.Management.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using CarHire.Core.Contracts;
    using static CarHire.Infrastructure.Data.ValidationConstants;

    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService _commentService)
        {
            commentService = _commentService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var comments = await commentService.GetAllAsync();

            return View(comments);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string commentId)
        {
            if (!await commentService.ExistByIdAsync(commentId))
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageCommentExist;

                return RedirectToAction(nameof(Index));
            }

            await commentService.DeleteByIdAsync(commentId);
            TempData[MessageConstant.WarningMessage] = MessageConstant.WarningMessageDeleteComment;

            return RedirectToAction(nameof(Index));
        }
    }
}
