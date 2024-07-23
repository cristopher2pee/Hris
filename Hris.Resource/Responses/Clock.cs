using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Resource.Responses
{
    public static class Client
    {
        public static string CLIENT = "Client";
        public static string NOT_FOUND = CLIENT + " not found";
        public static string ID_NOT_FOUND = CLIENT + " ID not found.";
        public static string ID_REQUIRED = CLIENT + " ID is required.";
    }

    public static class Project
    {
        public static string PROJECT = "Project";
        public static string NOT_FOUND = PROJECT + " not found";
        public static string ID_NOT_FOUND = PROJECT + " ID not found.";
        public static string ID_REQUIRED = PROJECT + " ID is required.";
    }

    public static class ProjectTask
    {
        public static string PROJECT_TASK = "Project Task";
        public static string NOT_FOUND = PROJECT_TASK + " not found";
        public static string ID_NOT_FOUND = PROJECT_TASK + " ID not found.";
        public static string ID_REQUIRED = PROJECT_TASK + " ID is required.";
    }

    public static class AssignedProject
    {
        public static string ASSIGNED_PROJECT = "Assigned Project";
        public static string NOT_FOUND = ASSIGNED_PROJECT + " not found";
        public static string ID_NOT_FOUND = ASSIGNED_PROJECT + " ID not found.";
        public static string ID_REQUIRED = ASSIGNED_PROJECT + " ID is required.";
    }

    public static class Track
    {
        public static string TRACK = "Track";
        public static string NOT_FOUND = TRACK + " not found";
        public static string ID_NOT_FOUND = TRACK + " ID not found.";
        public static string ID_REQUIRED = TRACK + " ID is required.";
        public static string CHANGE_REQUEST = "Change Request";
        public static string REQUEST_NOT_FOUND = CHANGE_REQUEST + " not found";
        public static string CHANG_REQUEST_NO_PARENT = CHANGE_REQUEST + " has no Primary Track.";
        public static string UPDATE_ERROR = "Error in updating track";

    }
}
