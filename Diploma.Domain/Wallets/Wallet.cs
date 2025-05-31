using Diploma.Domain.Users;

namespace Diploma.Domain.Wallets
{
    public class Wallet
    {
        public Guid UserId { get; init; }
        public virtual User User { get; init; }

        public Integration Integration { get; init; }
        public string EncryptedApiKey { get; set; }

        //EF
        public Wallet() { }

        public Wallet(
            Guid userId, 
            Integration integration,
            string encryptedApiKey)
        {
            ArgumentException.ThrowIfNullOrEmpty(encryptedApiKey);

            if (integration == Integration.None)
            {
                throw new InvalidOperationException();
            }

            UserId = userId;
            Integration = integration;
            EncryptedApiKey = encryptedApiKey;
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
