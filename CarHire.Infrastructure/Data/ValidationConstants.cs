namespace CarHire.Infrastructure.Data
{
    public static class ValidationConstants
    {
        public static class ClaimsConstants
        {
            public const string FirstName = "first_name";
        }

        public static class RolesConstants
        {
            public const string Admin = "Admin";
        }

        public static class ApplicationUserConstants
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 30;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 60;

            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 30;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 30;
        }

        public static class CategoryConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 60;
        }

        public static class VehicleConstants
        {
            public const int ImageUrlMinLength = 10;
            public const int ImageUrlMaxLength = 3000;

            public const int MakeMinLength = 2;
            public const int MakeMaxLength = 100;

            public const int ModelMinLength = 1;
            public const int ModelMaxLength = 100;
        }

        public static class DiscountConstants
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }

        public static class RenterConstants
        {
            public const int DrivingLicenseNumberMinLength = 8;
            public const int DrivingLicenseNumberMaxLength = 100;
        }

        public static class CommentConstants
        {
            public const int DescriptionMinLength = 8;
            public const int DescriptionMaxLength = 5000;
        }

        public static class MessageConstant
        {
            public const string ErrorMessage = "ErrorMessage";
            public const string ErrorMessageCategory = "The category does not exists!";

            public const string WarningMessage = "WarningMessage";
            public const string WarningMessageCategory = "Sorry we don\'t have any vehicles for this category yet!";

            public const string SuccessMessage = "SuccessMessage";
        }
    }
}
