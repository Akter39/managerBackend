using System.Reflection;

namespace managerBackend.Helpers
{
    public static class TypeUtilities
    {
        public static List<T> GetPublicContants<T>(this Type type)
        {
            return type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(u => u.IsLiteral && !u.IsInitOnly && u.FieldType == typeof(T))
                .Select(u => (T)u.GetRawConstantValue()!)
                .ToList()!;
        }
    }
}
