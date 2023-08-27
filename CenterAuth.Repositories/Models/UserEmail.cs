namespace CenterAuth.Repositories.Models
{
    public class UserEmail
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Email { get; set; }

        // This returns the user data when I get the email
        //public virtual User User { get; set; }
    }
}
