namespace CarHire.Extensions
{
    using System.Security.Claims;
    public static class ClaimsPrincipalExtension
    {
        /// <summary>
        /// Custom extension on ClaimsPrincipal
        /// </summary>
        /// <param name="user"></param>
        /// <returns>string user Id</returns>
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
