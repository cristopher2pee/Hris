
using Hris.Business.Extensions;
using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.Common
{
    public class EnumService
    {
        public async Task<Dictionary<int,string>> GetEnumValues(string enumType)
        {
            Dictionary<int,string> enumDict = new Dictionary<int,string>();


            switch (enumType.ToUpper())
            {
                case "GENDER":
                    enumDict = typeof(Gender).ToDictionary();
                    break;
                case "CIVILSTATUS":
                    enumDict = typeof(CivilStatus).ToDictionary();
                    break;
                case "EMPLOYEESTATUS":
                    enumDict = typeof(EmployeeStatus).ToDictionary();
                    break;
                case "EDUCATIONALLEVEL":
                    enumDict = typeof(EducationLevel).ToDictionary();
                    break;
                case "LEAVESTATUS":
                    enumDict = typeof(LeaveStatus).ToDictionary();
                    break;
                case "ADDRESSTYPE":
                    enumDict = typeof(AddressType).ToDictionary();
                    break;
                case "RELATIONSHIP":
                case "RELATIONSHIPTYPE":
                    enumDict = typeof(RelationshipType).ToDictionary();
                    break;
                case "ALLOWANCE":
                case "ALLOWANCEPERIOD":
                    enumDict = typeof(PayrollPeriod).ToDictionary();
                    break;
                case "STATUTORY":
                case "STATUTORYTYPE":
                    enumDict = typeof(StatutoryType).ToDictionary();
                    break;
                case "BLOODTYPE":
                    enumDict = typeof(BloodType).ToDictionary();
                    break;
                case "POSITION":
                case "POSITIONLEVEL":
                    enumDict = typeof(PositionLevel).ToDictionary();
                    break;
                case "MODULES":
                    enumDict = typeof(Modules).ToDictionary();
                    break;
                case "ROLES":
                    enumDict = typeof(Roles).ToDictionary();
                    break;
                case "CHANGESTATUS":
                    enumDict = typeof(ChangeStatus).ToDictionary();
                    break;
            }


            return enumDict;

        }
    }
}
