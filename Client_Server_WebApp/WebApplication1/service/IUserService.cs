using System.Collections.Generic;
using WebApplication1.model;

public interface IUserService
{//contine metodele pe care consumatorul le poate apela

    string HelloWorld();
    void AddUser(string username, string password, string adminStatus);
    void UpdateUser(string userId, string username, string password, string adminStatus);
    void DeleteUser(string userId);
    List<User> GetUsers();
    List<User> GetAdmins();
    List<User> GetRegularUsers();
    string Login(string username, string password);
}
