namespace Diploma.Domain.Users
{
    public class User
    {
        public Guid Id { get; init; }
        public string UserName { get; set; }
        public AuthenticationType AuthenticationTypes { get; private set; }

        //EF
        public User() { }

        public User(
            string userName,
            AuthenticationType authenticationType,
            Guid? id = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(userName, nameof(userName));

            if (authenticationType == AuthenticationType.None)
            {
                throw new InvalidOperationException();
            }

            Id = id ?? Guid.NewGuid();
            UserName = userName;
            AuthenticationTypes = authenticationType;
        }

        public void AddAuthenticationType(AuthenticationType notificationChannel)
        {
            AuthenticationTypes |= notificationChannel;
        }

        public void RemoveAuthenticationType(AuthenticationType notificationChannel)
        {
            AuthenticationTypes &= ~notificationChannel;
        }
    }
}
