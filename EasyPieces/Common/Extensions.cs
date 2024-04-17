using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EasyPieces.Common
{
    public static class Extensions
    {
        #region Enums
        public static string GetDisplayName(this Enum @enum)
        {
            return @enum.GetType()
                .GetMember(@enum.ToString())
                .FirstOrDefault()
                ?.GetCustomAttribute<DisplayAttribute>()?.Name ?? @enum.ToString();
        }
        #endregion

        #region Collections
        public static void MoveItem<T>(this List<T> list, int fromIndex, int toIndex = 0)
        {
            T item = list[fromIndex];
            list.RemoveAt(fromIndex);
            list.Insert(toIndex, item);
        }
        #endregion

        #region Reflection
        public static void CopyPropertiesTo<T, U>(this T source, U dest, string[] propertiesToIgnore)
        {
            List<PropertyInfo> sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            List<PropertyInfo> destProps = typeof(U).GetProperties().Where(x => x.CanRead).ToList();

            foreach (PropertyInfo sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name && !propertiesToIgnore.Contains(sourceProp.Name)))
                {
                    PropertyInfo destProp = destProps.First(x => x.Name == sourceProp.Name);
                    if (destProp.CanWrite)
                    {
                        destProp.SetValue(dest, sourceProp.GetValue(source));
                    }
                }
            }
        }
        #endregion

        #region Calculations
        public static bool IsWithinTolerance(this double? actual, double expected, double tolerance = 0.000001) 
        { 
            if (actual.HasValue)
                return Math.Abs(actual.Value - expected) <= tolerance;

            return false;
        }
        #endregion
    }
}
