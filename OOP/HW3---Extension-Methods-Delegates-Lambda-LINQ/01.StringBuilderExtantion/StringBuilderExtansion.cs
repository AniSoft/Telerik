using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StringBuilderExtantion
{
    public static class StringBuilderExtension
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {            
            if (index > sb.Length)
            {
                throw new ArgumentOutOfRangeException("index can't be larger than lenght of Stringbuilder");
            }
            else if (index < 0)
            {
                throw new ArgumentOutOfRangeException("StartIndex cannot be less than zero.");
            }
            else if (length > sb.Length || index + length > sb.Length)
            {
                throw new ArgumentOutOfRangeException("Index and length must refer to a location within the string");
            }
            else if (length < 0)
            {
                throw new ArgumentOutOfRangeException("Length cannot be less than zero.");
            }
            else
            {
                StringBuilder result = new StringBuilder();
                for (int i = index; i < length + index; i++)
                {
                    result.Append(sb[i]);
                }
                return result;
            }
        }
        public static StringBuilder Substring(this StringBuilder sb, int index)
        {
            return sb.Substring(index, sb.Length - index);
        }
    }

}
