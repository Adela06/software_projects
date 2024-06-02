using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.Teste
{
    public class RepositoryTest
    {
        [Test]
        public void ExecuteCommand_Insert_Success()
        {
            // Arrange
            string sql = $"INSERT INTO Users(person_id, username, password, admin_status) VALUES('1', 'usertest', 'test1', 'no');";
            Repository repository = new Repository("GradinaB");

            // Act
            bool result = repository.ExecuteCommand(sql);

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void GetTable_Returns_DataTable()
        {
            // Arrange
            string sql = "SELECT * FROM Users";
            Repository repository = new Repository("GradinaB");

            // Act
            var result = repository.GetTable(sql);

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsInstanceOf<DataTable>(result);
            ClassicAssert.Greater(result.Rows.Count, 0);
        }

    }
}
