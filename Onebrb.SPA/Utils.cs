namespace Onebrb.SPA
{
    public static class Utils
    {
        public static bool AllNull(params object[] objects)
        {
            return objects.All(s => s == null);
        }

        public static bool AllNotNull(params object[] objects)
        {
            return objects.All(s => s != null);
        }

        public static bool AtLeastOneNotNull(params object[] objects)
        {
            return objects.Any(s => s != null);
        }
    }
}
