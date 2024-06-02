using gradinaTema1.Model.Repository;
using gradinaTema1.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace gradinaTema1.Teste
{
    public class UserRepositoryTest
    {
        [Test]
        public void AddUser_Success()
        {
            // Arrange
            UserRepository userRepository = new UserRepository("GradinaB");
            User user = new User("1", "1", "testUsername", "testPassword", "no");

            // Act
            bool result = userRepository.AddUser(user);

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void UpdateUser_Success()
        {
            // Arrange
            UserRepository userRepository = new UserRepository("GradinaB");
            User user = new User("1", "1", "updatedUsername", "updatedPassword", "yes");

            // Act
            bool result = userRepository.UpdateUser("1", user);

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void DeleteUser_Success()
        {
            // Arrange
            UserRepository userRepository = new UserRepository("GradinaB");

            // Act
            bool result = userRepository.DeleteUser("1");

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void SearchUser_Returns_User()
        {
            // Arrange
            UserRepository userRepository = new UserRepository("GradinaB");

            // Act
            User result = userRepository.SearchUser("2");

            // Assert
            ClassicAssert.IsNotNull(result);
        }

        [Test]
        public void UserList_Returns_ListOfUsers()
        {
            // Arrange
            UserRepository userRepository = new UserRepository("GradinaB");

            // Act
            var result = userRepository.UserList();

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsInstanceOf<List<User>>(result);
            ClassicAssert.Greater(result.Count, 0);
        }
    }
}
