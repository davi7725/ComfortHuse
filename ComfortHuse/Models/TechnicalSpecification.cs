namespace Comforthuse.Models
{
    public class TechnicalSpecification : Specification
    {
        internal bool Editable { get; set; }
    }

    public abstract class Specification
    {
        public bool Ticked { get; set; }
    }
}