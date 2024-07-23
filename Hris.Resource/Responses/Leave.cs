using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Resource.Responses
{
    public static class Leave
    {
        public static string LEAVE_REQUEST = "Leave Request";
        public static string INVALID_LEAVE_REQUEST = "Invalid Leave Request";
        public static string INVALID_LEAVE_REQUEST_MESSAGE = "Not enough remaining balance to process leave application.";
    }

    public static class LeaveEmailNotifications
    {
        public static string LEAVE_REQUEST = $"<name> sent a {Leave.LEAVE_REQUEST} (<type>).";
        public static string LEAVE_REQUEST_WITHDRAW = $"<name> withdrawn a {Leave.LEAVE_REQUEST} (<type>).";
        public static string LEAVE_REQUEST_MANAGER_APPROVED = $"Manager approved {Leave.LEAVE_REQUEST} (<type>).";
        public static string LEAVE_REQUEST_LEAD_APPROVED = $"Lead approved {Leave.LEAVE_REQUEST} (<type>).";
        public static string LEAVE_REQUEST_REJECTED = $"{Leave.LEAVE_REQUEST} rejected (<type>).";
        public static string LEAVE_REQUEST_CANCELLATION_APPROVED = $"{Leave.LEAVE_REQUEST} cancellation request approved (<type>).";
        public static string LEAVE_REQUEST_CANCELLED = $"{Leave.LEAVE_REQUEST} cancelled (<type>).";
    }
}
