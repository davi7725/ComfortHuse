namespace Comforthuse.Models
{
    public class TechnicalSpecification : Specification
    {
        public TechnicalSpecification(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }


    }
}