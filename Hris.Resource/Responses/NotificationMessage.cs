using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Resource.Responses
{
    public static class NotificationMessage
    {
        //LEAVE REQUEST MESSAGE 
        public static string LEAVE_REQUEST_TITLE_MANAGER_LEAD = "Leave Request for <Name> (<LeaveType>).";
        public static string LEAVE_REQUEST_TITLE_USER = "Leave Request for (<LeaveType>).";

        public static string LEAVE_REQUEST_MESSAGE_USER = "You applied for <LEAVETYPE>"
            + " from <FROM> to <TO>"
            + " for a duration of <DAYS>"
            + " due to <REASONS>.";


        public static string LEAVE_REQUEST_MESSAGE_MANAGER_LEAD = "<NAME> has applied for <LEAVETYPE>"
            + " from <FROM> to <TO>"
            + " for a duration of <DAYS>"
            + " due to <REASONS>.";

        public static string LEAVE_WITHDRAW_MESSAGE_MANAGER_LEAD = "<NAME> has withdrawn <GENDER> leave application (<LEAVETYPE>)"
            + " from <FROM> to <TO>.";
        public static string LEAVE_WITHDRAW_MESSAGE_USER = "You have withdrawn your leave application (<LEAVETYPE>)"
             + " from <FROM> to <TO>.";

        public static string LEAVE_LEAD_APPROVED_TEAMLED_MANAGER = "<NAME>'s leave application for <LEAVETYPE> from <FROM> to <TO> has been approved.";
        public static string LEAVE_LEAD_APPROVED_USER = "Your leave application for <LEAVETYPE> from <FROM> to <TO> has been approved by your <APPROVEDUSER>.";

        public static string LEAVE_REJECTED_MESSAGE_TEAMLEAD_MANAGER = "<NAME>'s leave application for <LEAVETYPE> from <FROM> to <TO> has been denied.";
        public static string LEAVE_REJECTED_MESSAGE_USER = "Your leave application for <LEAVETYPE> from <FROM> to <TO> has been denied.";

        public static string LEAVE_CANCELLED_APPROVAL_RESULT_MANAGER_TEAMLEAD = "<NAME>'s request for cancellation for (<LEAVETYPE>) from <FROM> to <TO> has been approved.";
        public static string LEAVE_CANCELLED_APPROVAL_RESULT_MANAGER_USER = "Your request for cancellation for (<LEAVETYPE>) from <FROM> to <TO> has been approved.";

        public static string LEAVE_CANCELLED_MESSAGE_MANAGER_TEAMLEAD = "<NAME>'s has requested for leave request cancellation (<LEAVETYPE>) from <FROM> to <TO>.";
        public static string LEAVE_CANCELLED_MESSAGE_MANAGER_USER = "You requested for leave cancellation (<LEAVETYPE>) from <FROM> to <TO>.";

        //TRACK MESSAGE 

        public static string TRACK_TITLE_USER = "Track Request";
        public static string TRACK_TITLE_MANAGER_LEAD = "Track Request for <NAME>";

        public static string TRACK_MESSAGE_MANUAL_INPUT_MANAGER = "<NAME> is requesting to add <GENDER> track record for <DATE> manually. (<STATUS>)";
        public static string TRACK_MESSAGE_MANUAL_INPUT_USER = "You are requesting to add your track record for <DATE> manually. (<STATUS>)";

        public static string TRACK_MESSAGE_TIME_UPDATE_MANAGER = "<NAME> is requesting to update <GENDER> TIME track record for <DATE>. (<STATUS>)";
        public static string TRACK_MESSAGE_TIME_UPDATE_USER = "You are requesting to update your TIME track record for <DATE>. (<STATUS>)";

        public static string TRACK_MESSAGE_DATE_UPDATE_MANAGER = "<NAME> is requesting to update <GENDER> DATE track record for <DATE>. (<STATUS>)";
        public static string TRACK_MESSAGE_DATE_UPDATE_USER = "You are requesting to update your DATE track record for <DATE>. (<STATUS>)";

        public static string TRACK_MESSAGE_APPROVED_MANAGER = "<NAME>'s track request for <DATE> has been approved.";
        public static string TRACK_MESSAGE_APPROVED_USER = "You track request for <DATE> has been approved.";

        public static string TRACK_MESSAGE_DECLINED_MANAGER = "<NAME>'s track request for <DATE> has been declined.";
        public static string TRACK_MESSAGE_DECLINED_USER = "You track request for <DATE> has been declined.";

        public static string NOTIFY_TITLE_LEAVEAPPLICATION = "Leave Request Application Pending";
        public static string NOTIFY_TITLE_TRACKREQUEST = "Track Request Pending";

        public static string NOTIFY_MESSAGE_LEAVEAPPLICATION = "The leave application of <NAME> is currently pending and requires review.";
        public static string NOTIFY_MESSAGE_TRACKREQUEST = "The track request of <NAME> is currently pending and requires review.";
    }
}
