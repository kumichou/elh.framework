using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ELH.Framework.Base
{
    public abstract class ValueConvertBase
    {
        protected T GetValue<T>(T nullValue, string keyValue)
        {
            T result = default(T);
            Type returnType = typeof(T);

            if (!string.IsNullOrEmpty(keyValue))
            {
                TypeConverter valueConverter = TypeDescriptor.GetConverter(returnType);

                if (valueConverter.CanConvertFrom(keyValue.GetType()))
                {
                    if (returnType.IsEnum)
                    {
                        if (Enum.IsDefined(returnType, keyValue))
                        {
                            result = (T)valueConverter.ConvertFrom(null, null, keyValue);
                        }
                    }
                    else if (returnType == typeof(bool))
                    {
                        if (IsNumeric(keyValue))
                        {
                            result = (T)valueConverter.ConvertFrom(null, null, Convert.ToBoolean(Convert.ToInt32(keyValue)).ToString());
                        }
                        else
                        {
                            if (keyValue.ToLower() == "false" || keyValue.ToLower() == "true")
                            {
                                result = (T)valueConverter.ConvertFrom(null, null, keyValue);
                            }
                        }
                    }
                    else
                    {
                        result = (T)valueConverter.ConvertFrom(null, null, keyValue);
                    }
                }
            }
            else
            {
                result = nullValue;
            }

            return result;
        }

        protected bool IsNumeric(string text)
        {           
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(text);            
        }
    }
}
