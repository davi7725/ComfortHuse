namespace Comforthuse.Models
{
    public class TechnicalSpecification : Specification, ITechnicalSpecification
    {

        public string Description { get; set; }

        public bool Editable { get; internal set; }

        public TechnicalSpecification()
        {
        }

        public TechnicalSpecification(string description)
        {
            this.Description = description;
        }


    }

    public interface ITechnicalSpecification
    {
        string Description { get; set; }
        bool Editable { get; }
    }
}