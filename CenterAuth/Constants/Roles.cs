namespace CenterAuth.Constants
{
    [Flags]
    public enum Roles
    {
        Admin = 1,
        Staff = 2,
        Any = Admin | Staff,
    }
}
