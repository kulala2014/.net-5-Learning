using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kulala.Learning.Common.Extension
{


    public static class EnumExtension
    {
        public static string GetRemark(this Enum value)
        {
            string remark = string.Empty;
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            if (fieldInfo.IsDefined(typeof(RemarkAttribute), false))
            {
                RemarkAttribute attribute = (RemarkAttribute)fieldInfo.GetCustomAttributes(typeof(RemarkAttribute), false).FirstOrDefault();
                remark = attribute.Remark;
            }
            else
            {
                remark = fieldInfo.Name;
            }
            return remark;
        }
    }

   public class RemarkAttribute : Attribute
    {
        private string _remark = string.Empty;
        public RemarkAttribute(string remark) => _remark = remark;

        public string Remark
        {
            get => _remark;
            set => _remark = value;
        }
    }
}
