namespace CenterAuth.Constants
{
    public static class UserTypes
    {
        public static class Admin
        {
            public const int Id = 1;
            public const string HierarchyNode = "/1/";
        }

        public static class Staff
        {
            public const int Id = 2;
            public const string HierarchyNode = "/2/";

            public static class Management
            {
                public const int Id = 3;
                public const string HierarchyNode = "/2/1/";
            }

        }
    }
}
