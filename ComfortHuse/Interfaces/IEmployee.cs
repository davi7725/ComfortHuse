namespace Comforthuse
{
    public interface IEmployee
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string DisplayName { get; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
    }
}