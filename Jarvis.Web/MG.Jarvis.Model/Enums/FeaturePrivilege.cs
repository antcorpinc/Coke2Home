using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace MG.Jarvis.Model.Enums
{
    [Flags]

   public enum FeaturePrivilege
    {

        None = 0,
        View = 1,
        Create = 2,
        Approve = 4,

    }

    public static class FeaturePrivilegeExtensions
    {
        public static string GetPrivilegeKey (this FeaturePrivilege privilege)
        {
            switch (privilege)
            {
                case FeaturePrivilege.Approve:
                    return "AP";
                case FeaturePrivilege.Create:
                    return "CR";
                case FeaturePrivilege.View:
                    return "VW";
                default:
                    throw new ArgumentException();
            }

        }
    }

    public class FeaturePrivilegeConverter: TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
