namespace Comforthuse.Models
{
    public class TechnicalSpecification : Specification, ITechnicalSpecification
    {
        public TechnicalSpecification()
        {
        }

        public TechnicalSpecification(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }

        public bool EditAble { get; internal set; }

    }

    public interface ITechnicalSpecification
    {
        string Description { get; set; }
        bool EditAble { get; }
    }
}