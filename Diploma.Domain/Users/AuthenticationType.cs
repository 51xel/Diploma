namespace Diploma.Domain.Users
{
    [Flags]
    public enum AuthenticationType
    {
        None = 0,
        EmailAndPassword
    }
}
