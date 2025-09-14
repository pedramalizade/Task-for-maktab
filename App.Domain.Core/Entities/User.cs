namespace App.Domain.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Duty>? Duties { get; set; }
    }
}
