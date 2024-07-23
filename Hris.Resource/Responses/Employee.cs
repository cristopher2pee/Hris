using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Resource.Responses
{
    public static class Employee
    {
        public static string EMPLOYEE = "Employee";
        public static string NOT_FOUND = EMPLOYEE + " not found";
        public static string ID_NOT_FOUND = EMPLOYEE + " ID not found.";
        public static string ID_REQUIRED = EMPLOYEE + " ID is required.";
        public static string EXISTING = EMPLOYEE + " already exist.";
    }

    public static class Position
    {
        public static string POSITION = "Position";
        public static string NOT_FOUND = POSITION + " not found";
        public static string ID_NOT_FOUND = POSITION + " ID not found.";
        public static string ID_REQUIRED = POSITION + " ID is required.";
    }

    public static class Team
    {
        public static string TEAM = "TEAM";
        public static string NOT_FOUND = TEAM + " not found";
        public static string ID_NOT_FOUND = TEAM + " ID not found.";
        public static string ID_REQUIRED = TEAM + " ID is required.";
    }

    public static class TeamMember
    {
        public static string TEAM_MEMBER = "Team Member";
        public static string NOT_FOUND = TEAM_MEMBER + " not found";
        public static string ID_NOT_FOUND = TEAM_MEMBER + " ID not found.";
        public static string ID_REQUIRED = TEAM_MEMBER + " ID is required.";
        public static string EXISTING = "Already a " + TEAM_MEMBER + ".";
    }
}
