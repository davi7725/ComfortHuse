namespace Comforthuse.Models
{
    public interface ITechnicalSpecification
    {
        string Description { get; set; }
        bool Editable { get; set; }
    }
}