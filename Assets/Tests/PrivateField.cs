using System.Reflection;
using NUnit.Framework;

namespace Tests
{
    public static class PrivateField
    {
        public static void Set<T>(object target, string fieldName, T value)
        {
            var f = target.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(f, $"Field '{fieldName}' not found on {target.GetType().Name}");
            f.SetValue(target, value);
        }

        public static T Get<T>(object target, string fieldName)
        {
            var f = target.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(f, $"Field '{fieldName}' not found on {target.GetType().Name}");
            return (T)f.GetValue(target);
        }
    }
}