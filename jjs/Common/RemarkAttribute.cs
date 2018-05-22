using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace jjs.Common
{
    public class RemarkAttribute : Attribute
    {
        private string _remark;

        public RemarkAttribute()
        {
        }

        public RemarkAttribute(string _remark)
        {
            this._remark = _remark;
        }
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        public static string GetEnumRemark(System.Enum _enum)
        {

            Type type = _enum.GetType();
            FieldInfo fd = type.GetField(_enum.ToString());
            if (fd == null) return string.Empty;
            object[] attrs = fd.GetCustomAttributes(typeof(RemarkAttribute), false);
            string name = string.Empty;
            foreach (RemarkAttribute attr in attrs)
            {
                name = attr.Remark;
            }
            return name;
        }

    }
}