namespace Project.Core
{
    public static class ExtensionsOfString
    {
        public static string Append(this string str, string append)
        {
            return string.Concat(str, append);
        }

        public static bool HasValue(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static string Prepend(this string str, string prepend)
        {
            return string.Concat(prepend, str);
        }
    }
}
