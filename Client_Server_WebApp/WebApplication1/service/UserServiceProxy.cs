using System.Collections.Generic;
using WebApplication1.model;
using WebApplication1.service;

public class UserServiceProxy : IUserService
{
    private readonly IUserService _userService;

    public UserServiceProxy()
    {
        _userService = new userService(); // Assuming userService is the actual implementation
    }

    // Implement all methods of IUserService by delegating calls to the actual service
    public string HelloWorld() => _userService.HelloWorld();

    public void AddUser(string username, string password, string adminStatus) => _userService.AddUser(username, password, adminStatus);

    public void UpdateUser(string userId, string username, string password, string adminStatus) => _userService.UpdateUser(userId, username, password, adminStatus);

    public void DeleteUser(string userId) => _userService.DeleteUser(userId);

    public List<User> GetUsers() => _userService.GetUsers();

    public List<User> GetAdmins() => _userService.GetAdmins();

    public List<User> GetRegularUsers() => _userService.GetRegularUsers();

    public string Login(string username, string password) => _userService.Login(username, password);
}
