using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Resource.Responses
{
    public static class Common
    {
        // Extensions
        public static string EXT_NOT_FOUND = " not found";
        public static string EXT_ID_NOT_FOUND = " ID not found.";
        public static string EXT_ID_REQUIRED = " ID is required.";

        public static string USER_NOT_FOUND = "User not found";
        public static string USER_EXISTING = "User already exist.";

        public static string AUTH_INVITE_EXIST = "An active invatation already exist with this email.";
        public static string AUTH_INVITE_EXPIRED = "Invitation already expired, Please contact administrator for renewal.";
        public static string AUTH_INVITE_NOT_FOUND = "No invitation found, please contact administrator for invitation.";

        public static string FILE_NOT_FOUND = "File not found";
        public static string SOMETHING_WENT_WRONG = "Something went wrong.";

        public static string ARGUMENT_NULL_MESSAGE = "Object result cannot be null.";

        public static string ACCESS_DENIED = "Access Denied";
        public static string ACCESS_DENIED_MESSAGE = "You do not have permission to access this page. ";

        public static string ERROR = "Error";
        public static string SUCCESS = "Success";

        public static string REGISTER = "Register";
        public static string REGISTER_SUCCESS_MESSAGE = "New Employee has been successfully registered.";
        public static string REGISTER_FAILED_MESSAGE = "There was an issue registering the new employee. Please try again or contact support for assistance.";

        public static string ERROR_SAVE = "Saving data results in an error.";
        public static string ERROR_UPDATE = "Updating data result in an error.";
        public static string ERROR_DELETE = "Deleting data result in an error.";
        public static string ERROR_ACCESS = "Error in accessing data.";

        public static string OBJECT_NOT_EXIST = "Object does not exist.";
        public static string NOTFOUND = "Not Found";
    }

    public static class Settings
    {
        public static string DEFAULT_ADDON_PASS = "DefaultGemango.123";
    }


}
