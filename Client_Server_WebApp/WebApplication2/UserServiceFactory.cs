namespace WebApplication2
{
    // Concrete factory for user service
    //responsabila pentru crearea obiectelor specifice de serviciu pentru users
    public class UserServiceFactory : IServiceFactory
    {
        public object CreateService()
        {
            return new localhostU.userService();
        }
    }
}