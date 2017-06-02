namespace Comforthuse.Models.SpecificationDerivatives
{
    public class TechnicalSpecification : Specification, ITechnicalSpecification
    {
        public string Description { get; set; }

        public bool Editable { get; set; }

        public TechnicalSpecification()
        {
            Editable = true;
        }

        public TechnicalSpecification(string description)
        {
            this.Description = description;
        }
    }
}