
using System.Web.Services.Description;

namespace WebApplication2
{
    // Concrete factory for plant service
    //responsabila pentru crearea obiectelor specifice de serviciu pentru plante
    public class PlantServiceFactory : IServiceFactory
    {
        public object CreateService()
        {
            return new localhost1.plantServiceFull();
        }
    }
}