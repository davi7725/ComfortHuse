namespace Comforthuse.Models
{
    public class TechnicalSpecification : Specification, ITechnicalSpecification
    {
        public string Description { get; set; }

        public bool EditAble { get; set; }

        public TechnicalSpecification()
        {
            EditAble = true;
        }

        public TechnicalSpecification(string description)
        {
            this.Description = description;
        }
    }
}