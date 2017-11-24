namespace ASF.UI.WbSite.Constants
{
    using System;

    public static class CacheSetting
    {
        public static class SitemapNodes
        {
            public const string Key = "SitemapNodes";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromDays(1);
        }

        public static class Category
        {
            public const string Key = "Category";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromDays(1);
        }

        public static class Country
        {
            public const string Key = "Country";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromDays(1);
        }

        public static class Language
        {
            public const string Key = "Language";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromDays(1);
        }

        public static class LocaleResourceKey
        {
            public const string Key = "LocaleResourceKey";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromDays(1);
        }

        public static class LangDictionary
        {
            public const string key = "LangDictionary";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromDays(1);
        }
    }
}