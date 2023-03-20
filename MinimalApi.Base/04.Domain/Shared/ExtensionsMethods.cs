
using System.ComponentModel;
using System.Reflection;
using System.Xml.Linq;

namespace MinimalApi.Base.Domain.Shared
{
    public static class ExtensionsMethods
    {

        public static string GetDescription(this Enum enumType)
        {
            var type = enumType.GetType();

            var memInfo = type.GetMember(enumType.ToString());

            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return enumType.ToString();
        }
    }
}







/*
        public static string ConvertToString (this ResultStatus resultStatus){

            int value = (int)resultStatus;
            
            if (Enum.IsDefined(typeof(ResultStatus),value))
                return ((ResultStatus)value).ToString();
            else
                return "Invalid Value";

        }*/