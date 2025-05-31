namespace Diploma.Domain.Users.AuthenticationTypes
{
    public class EmailAndPasswordAuthType
    {
        //Make User here
        public Guid UserId { get; init; }
        public string Email { get; init; }
        public string PasswordHash { get; set; }

        //EF
        public EmailAndPasswordAuthType() { }

        public EmailAndPasswordAuthType(
            Guid userId,
            string email, 
            string passwordHash)
        {
            ArgumentException.ThrowIfNullOrEmpty(email, nameof(email));
            ArgumentException.ThrowIfNullOrEmpty(passwordHash, nameof(passwordHash));

            UserId = userId;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
