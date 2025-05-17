using Diploma.Domain.Users;

namespace Diploma.Domain.Wallets
{
    public class Wallet
    {
        public virtual User User { get; init; }
        public Integration Integration { get; init; }
        public string EncryptedApiKey { get; set; }

        //EF
        public Wallet() { }

        public Wallet(
            User user, 
            Integration integration,
            string encryptedApiKey)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));
            ArgumentException.ThrowIfNullOrEmpty(encryptedApiKey);

            if (integration == Integration.None)
            {
                throw new InvalidOperationException();
            }

            User = user;
            Integration = integration;
        }

        public override string ToString()
        {
            return Integration.ToString();
        }

        public static implicit operator string(Wallet? wallet)
        {
            return wallet?.ToString() ?? string.Empty;
        }
    }
}
