using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplication1.model.repository;
using WebApplication1.model;
using System.Drawing;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg;

namespace WebApplication1.service
{
    /// <summary>
    /// Summary description for userService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class userService : System.Web.Services.WebService, IUserService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public void AddUser(string username, string password, string adminStatus)
        {
            UserRepository userRepository = new UserRepository("GradinaB");

            User newUser = new User("", "", password, username, adminStatus);
            userRepository.AddUser(newUser);
        }

        [WebMethod]
        public void UpdateUser(string userId, string username, string password, string adminStatus)
        {
            UserRepository userRepository = new UserRepository("GradinaB");

            User updatedUser = new User(userId, "", password, username, adminStatus);
            userRepository.UpdateUser(userId, updatedUser);

            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Gradina Botanica", "adeliosif@yahoo.com"));
            email.To.Add(new MailboxAddress(updatedUser.Username, updatedUser.Username));

            email.Subject = "Login information changed";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = $"Hello,\n\nYour login information has been changed. Your new credentials are:\nUsername: {username}\nPassword: {password}\n\nBest regards,\nGradina Botanica"
            };
            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.mail.yahoo.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate("adeliosif@yahoo.com", "rwkuizuhgyhamyoo");

                smtp.Send(email);
                smtp.Disconnect(true);
            }

            sendWhatsappMessage(username, password);
        }

        private async Task sendWhatsappMessage(string username, string password)
        {
            var url = "https://graph.facebook.com/v19.0/284659184739150/messages";
            var bearerToken = "EAAUcViHRkucBO5pjf9In5z74xRWaaYJ1zXKNEdKhMvZAVSkEmn451MHFfZBZAqc5A43e28xDZB8PjWjolAI90dYXRTDzL0A5KXZBgxId6uOyZAhLXbUyepwkrSfo79hJuiXn3YUbi00VRJw3TBdSG1R1sXqYZAJCgIeH2gkK5aq7r4fn2bbEgILV29dyWnzTq1kDZA6lusyDBfR8mxPhE3sZD";
            var phoneNumber = "40752257889"; // Replace with the recipient's phone number

            var jsonPayload = new
            {
                messaging_product = "whatsapp",
                recipient_type = "individual",
                to = phoneNumber,
                type = "text",
                text = new
                {
                    preview_url = false,
                    body = $"Hello,\n\nYour login information has been changed. Your new credentials are:\nUsername: {username}\nPassword: {password}\n\nBest regards,\nGradina Botanica"
                }
            };

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
                var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(jsonPayload), Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    Console.WriteLine($"Status Code: {response.StatusCode}");
                    Console.WriteLine($"Response: {responseString}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }

        [WebMethod]
        public void DeleteUser(string userId)
        {
                if (!string.IsNullOrEmpty(userId))
                {
                    UserRepository userRepository = new UserRepository("GradinaB");
                    userRepository.DeleteUser(userId);
                }
        }

        [WebMethod]
        public List<User> GetUsers()
        {
            UserRepository userRepository = new UserRepository("GradinaB");
            return userRepository.UserList();
        }

        [WebMethod]
        public List<User> GetAdmins()
        {
            UserRepository userRepository = new UserRepository("GradinaB");
            return userRepository.UserList().Where(u => u.AdminStatus == "yes").ToList();
        }

        [WebMethod]
        public List<User> GetRegularUsers()
        {
            UserRepository userRepository = new UserRepository("GradinaB");
            return userRepository.UserList().Where(u => u.AdminStatus == "no").ToList();
        }

        [WebMethod]
        public string Login(string username, string password)
        {
            UserRepository userRepository = new UserRepository("GradinaB");
            User u = userRepository.SearchUserLogIn(username, password);

            return u.AdminStatus;
        }
    }
}
