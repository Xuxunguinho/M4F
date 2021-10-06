using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Assets.Scripts
{
    public static class ExtensionMethods
    {
        public static T CreateInstance<T>()
        {
            var obj = TypeDescriptor.CreateInstance(null, typeof(T), null, null);
            return (T)obj;
        }

        public static int ToInt(this string value)
        {
            var number = 0;
             int.TryParse(value, out number);
             return number;
        }

        public static LineAlgs GetFirst(this IEnumerable<LineAlgs> source, int target)
        {
            if (source == (null)) return default(LineAlgs);
            // ReSharper disable once PossibleNullReferenceException
            var lineAlgses = source as LineAlgs[] ?? source.ToArray();
            var xvalue = lineAlgses.FirstOrDefault(x => x.TargetIndex >= target - 1 || x.TargetIndex >= target);
            if (xvalue == null)
                xvalue = lineAlgses.FirstOrDefault(x => x.TargetIndex <= target);
                //if (xvalue == null)
                //if (lineAlgses.RightCount(xvalue) > 0 && target < lineAlgses.RightItem(xvalue).TargetIndex)
                //{
                //    var idx = lineAlgses.ToList().IndexOf(xvalue) + 1;
                //    xvalue = lineAlgses[1];
                //}


            var defaultvalue = lineAlgses.FirstOrDefault(x => x.TargetIndex == 1);
            return xvalue ?? defaultvalue;
        }
      
    }
}
