namespace CenterAuth.Repositories.Models
{
    public class UserEmail
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Email { get; set; }

        public virtual User User { get; set; }
    }
}
