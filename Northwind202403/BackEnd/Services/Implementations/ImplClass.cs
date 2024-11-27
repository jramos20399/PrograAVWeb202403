using BackEnd.Services.Interfaces;

namespace BackEnd.Services.Implementations
{
    public class ImplClass: ISingleton, IScope, ITransient
    {
        public Guid Value { get; set; }

        public ImplClass()
        {
            Value = Guid.NewGuid();
        }

    }
}
