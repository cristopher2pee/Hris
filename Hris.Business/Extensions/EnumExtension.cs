using System.ComponentModel;

namespace Hris.Business.Extensions
{
    public static class EnumExtension
    {
        public static Dictionary<int,string> ToDictionary(this Type enumerationType)
        {
            Dictionary<int, string> RetVal = new Dictionary<int, string>();
            var AllItems = Enum.GetValues(enumerationType);
            foreach (var CurrentItem in AllItems)
            {
                DescriptionAttribute[] DescAttribute = (DescriptionAttribute[])enumerationType.GetField(CurrentItem.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                string? description = DescAttribute.Length > 0 ? DescAttribute[0].Description : CurrentItem.ToString();
                RetVal.Add((int)CurrentItem, description??string.Empty);
            }
            return RetVal;
        }

    }
}
