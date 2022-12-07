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
            public const string Manager = "Manager";
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

            public const int YearMinRange= 1929;
            public const int YearMaxRange = 2030;

            public const int SeatsMinRange = 1;
            public const int SeatsMaxRange = 100;

            public const int DoorsMinRange = 0;
            public const int DoorsMaxRange = 10;

            public const string PriceMinRange = "10";
            public const string PriceMaxRange = "10000";
        }

        public static class DiscountConstants
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }

        public static class RenterConstants
        {
            public const int MinRentDays = 1;
            public const int MaxRentDays = 30;

            public const int BasicRenterDiscount = 15;
            public const int ZeroDiscount = 0;

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
            public const string ErrorMessageVehicle = "The vehicle is not exists!";
            public const string ErrorMessageRenterExist = "You don\'t have permission";
            public const string ErrorMessageAddUserToRole = "User not added in role!";
            public const string ErrorMessageAddUserExistToRole = "The user already is in role!";
            public const string ErrorMessageAddVehicle = "The vehicle data is not correct!";
            public const string ErrorMessageCommentExist = "The comment is not exists!";

            public const string WarningMessage = "WarningMessage";
            public const string WarningMessageCategory = "Sorry we don\'t have any vehicles for this category!";
            public const string WarningMessageIsRented = "Sorry vehicle is rented!";
            public const string WarningMessageMyRent = "You have no rental vehicles!";
            public const string WarningMessageAddUserToRole = "The user has been successfully added to role!";
            public const string WarningMessageAddVehicle = "Vehicle successfully added!";
            public const string WarningMessageEditVehicle = "Vehicle successfully edited!";
            public const string WarningMessageDeleteComment = "Comment successfully deleted!";

            public const string SuccessMessage = "SuccessMessage";
            public const string FeedbackMessage = "Тhank you, your comment is important to us!";
        }
    }
}
