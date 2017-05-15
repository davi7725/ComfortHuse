using Comforthuse.Interfaces;

namespace Comforthuse.Models.SpecificationDerivatives
{
    public abstract class Specification : ISpecification
    {
        public bool Ticked { get; set; }
    }
}