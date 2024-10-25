using IdentityCore.Entities;
namespace AccountCore.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string  Currency {  get; set; }
        //public List<User> Owners { get; set; }
    }
}
