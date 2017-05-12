namespace Comforthuse.Models
{
    public class TechnicalSpecification : Specification, ITechnicalSpecification
    {
        public TechnicalSpecification()
        {
            EditAble = true;
        }

        public TechnicalSpecification(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }

        public bool EditAble { get; set; }

    }
}