using IdentityCore.Entities;

namespace AccountApplication.Responses
{
    public class AccountResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        //public List<User> Owners { get; set; }
    }
}
